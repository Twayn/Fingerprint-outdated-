using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIR_WindowsForms
{
    public partial class MainForm : Form
    {
        private static Bitmap sourceImage = NIR_WindowsForms.Properties.Resources._2; //исходное изображение внедренное в ресурсы программы

        private static Bitmap tempImage;

        public MainForm()
        {
            InitializeComponent();
            tempImage = Picture.generateTestImage(sourceImage.Width, sourceImage.Height);

            sourceImageBox.Image = tempImage;
            UtilityFunctions.setInitialData(tempImage);
        }

        private void stepOneButton_Click(object sender, EventArgs e)
        {
            resultImageBox.Image = Steps.step(0);
        }

        private void stepTwoButton_Click(object sender, EventArgs e)
        {
            resultImageBox.Image = Steps.step(1);
        }

        private void stepThreeButton_Click(object sender, EventArgs e)
        {
            resultImageBox.Image = Steps.step(2);
        }

        private void stepFourButton_Click(object sender, EventArgs e)
        {
            resultImageBox.Image = Steps.step(3);
        }

        private void menuBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultImageBox.Image = Steps.step(menuBox.SelectedIndex);
        }
    }

    public static class Steps
    {
        private static Bitmap sourceImage = NIR_WindowsForms.Properties.Resources._2;

        private static Bitmap[] images = new Bitmap[50];

        private static Bitmap choose(int num){
            switch (num){
                case 0:
                    UtilityFunctions.pointGrad();
                    return UtilityFunctions.pModule();
                case 1:
                    return UtilityFunctions.pDirection();
                case 2:
                    UtilityFunctions.areaGrad(9);
                    return UtilityFunctions.aModule();
                case 3:
                    return UtilityFunctions.aDirection();
                default:
                    return new Bitmap(0, 0);
            }
        }

        public static Bitmap step(int st){
            if (st > 0) { step(st - 1); }
            if (images[st] == null){
                images[st] = choose(st);
                return images[st];
            }
            else{
                return images[st];
            }
        }
    }
}