using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NIR_WindowsForms
{
    class Picture
    {
        private static int width;
        private static int height;

        public static void setDimensions (int w, int h) {
            width = w;
            height = h;
        }

        /*Generate image from two dimensional array*/
        public static Bitmap drawImage(double[,] array) {
            Bitmap image = new Bitmap(width, height);
            double ratio = calcRatio(array);

            for (int x = 0; x < image.Width; x++) {
                for (int y = 0; y < image.Height; y++) {
                    int temp = Convert.ToInt32(array[x, y] / ratio);
                    image.SetPixel(x, y, Color.FromArgb(temp, temp, temp));
                }
            }

            return image;
        }

        private static double calcRatio(double[,] image) {
            double maxVal = 0;

            for (int x = 1; x < width - 1; x++) {
                for (int y = 1; y < height - 1; y++) {
                    if (image[x, y] > maxVal) {
                        maxVal = image[x, y];
                    }
                }
            }

            return maxVal / 255.0;

            //if (maxVal > 255.0)
            //{
            //    return maxVal / 255.0;
            //}
            //else {
            //    return 1;
            //}
        }

        /*Generate test image with black-white concentric circles*/
        public static Bitmap generateTestImage(int w, int h) {
            Bitmap image = new Bitmap(w, h);

            double xCen = image.Width / 2;
            double yCen = image.Height / 2;

            for (int x = 0; x < image.Width; x++) {
                for (int y = 0; y < image.Height; y++) {
                    double color = 127 + 128 * Math.Cos((Math.Sqrt((x - xCen) * (x - xCen) + (y - yCen) * (y - yCen)) / 4) / Math.PI);
                    int temp = (int)Math.Ceiling(color);
                    Color newColor = Color.FromArgb(temp, temp, temp);
                    image.SetPixel(x, y, newColor);
                }
            }

            return image;
        }
    }
}
