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

        public MainForm()
        {
            InitializeComponent();
            //init(Picture.generateTestImage(sourceImage.Width, sourceImage.Height), gauss);
            //init(sourceImage, gauss);
            init(sourceImage);
        }

        private void menuBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultImageBox.Image = Steps.step(menuBox.SelectedIndex);
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (filterComboBox.SelectedIndex) { 
                case 0:
                    init(sourceImage);
                    break;
                case 1:
                    init(sourceImage, equal);
                    break;
                case 2:
                    init(sourceImage, average);
                    break;
                default:
                    init(sourceImage, equal);
                    break;
            }
        }

        private void init(Bitmap source, int[] filter) {
            Bitmap temp = UtilityFunctions.blur(source, filter);
            sourceImageBox.Image = temp;
            UtilityFunctions.setInitialData(temp);
            setMatrix(filter);
            Steps.clear();
        }

        private void init(Bitmap source) {
            sourceImageBox.Image = source;
            UtilityFunctions.setInitialData(source);
            setMatrix();
            Steps.clear();
        }

        private void setMatrix() {
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            maskedTextBox3.Text = "0";
            maskedTextBox4.Text = "0";
            maskedTextBox5.Text = "0";
            maskedTextBox6.Text = "0";
            maskedTextBox7.Text = "0";
            maskedTextBox8.Text = "0";
            maskedTextBox9.Text = "0";
        }

        private void setMatrix(int[] filter) {
            maskedTextBox1.Text = filter[0].ToString();
            maskedTextBox2.Text = filter[1].ToString();
            maskedTextBox3.Text = filter[2].ToString();
            maskedTextBox4.Text = filter[3].ToString();
            maskedTextBox5.Text = filter[4].ToString();
            maskedTextBox6.Text = filter[5].ToString();
            maskedTextBox7.Text = filter[6].ToString();
            maskedTextBox8.Text = filter[7].ToString();
            maskedTextBox9.Text = filter[8].ToString();
        }

        private void blurButton_Click(object sender, EventArgs e) {
            int[] filter = { int.Parse(maskedTextBox1.Text),
                             int.Parse(maskedTextBox2.Text),
                             int.Parse(maskedTextBox3.Text),
                             int.Parse(maskedTextBox4.Text),
                             int.Parse(maskedTextBox5.Text),
                             int.Parse(maskedTextBox6.Text),
                             int.Parse(maskedTextBox7.Text),
                             int.Parse(maskedTextBox8.Text),
                             int.Parse(maskedTextBox9.Text),
                            };
            init(sourceImage, filter);
        }

        int[] equal = new int[] {
          1, 1, 1,
          1, 1, 1, 
          1, 1, 1
        };

        int[] average = new int[] {
          1, 2, 1,
          2, 4, 2, 
          1, 2, 1
        };
    }
}