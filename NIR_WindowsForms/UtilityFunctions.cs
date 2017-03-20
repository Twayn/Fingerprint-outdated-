using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace NIR_WindowsForms
{
    class UtilityFunctions
    {
        const float RAD2DEG = 180.0f / 3.14159f;
       
        private static int _height;
        private static int _width;

        private static double[,] sourceImage;

        private static double[,] arrayModule;
        private static double[,] arrayAngle;

        private static double[,] bigModule;
        private static double[,] bigAngle;

        public static void setInitialData(Bitmap image)
        {
            _width = image.Width;
            _height = image.Height;

            sourceImage = new double[_width, _height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    sourceImage[i, j] = image.GetPixel(i, j).GetBrightness() * 255;
                }
            }

            arrayModule = new double[_width, _height];
            arrayAngle = new double[_width, _height];

            bigModule = new double[_width, _height];
            bigAngle = new double[_width, _height];
        }

        private static Bitmap drawImage(double[,] array)
        {
            Bitmap image = new Bitmap(_width, _height);
            double ratio = calcRatio(array);
          
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int temp = Convert.ToInt32(array[x, y] / ratio);
                    image.SetPixel(x, y, Color.FromArgb(temp, temp, temp));
                }
            }

            return image;
        }

        private static double calcRatio(double[,] image)
        {
            double maxVal = 0;

            for (int x = 1; x < _width - 1; x++)
            {
                for (int y = 1; y < _height - 1; y++)
                {
                    if (image[x, y] > maxVal)
                    {
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

        public static Bitmap grad()
        {
            double z1, z2, z3, z4, z5, z6, z7, z8, z9;
            double gx, gy;

            for (int x = 1; x < _width - 1; x++)
            {
                for (int y = 1; y < _height - 1; y++)
                {
                    z1 = sourceImage[x - 1, y - 1];
                    z2 = sourceImage[x - 1, y];
                    z3 = sourceImage[x - 1, y + 1];
                    z4 = sourceImage[x, y - 1];
                    z5 = sourceImage[x, y];
                    z6 = sourceImage[x, y + 1];
                    z7 = sourceImage[x + 1, y - 1];
                    z8 = sourceImage[x + 1, y];
                    z9 = sourceImage[x + 1, y + 1];

                    gx = (z7 + 2 * z8 + z9) - (z1 + 2 * z2 + z3);
                    gy = (z3 + 2 * z6 + z9) - (z1 + 2 * z4 + z7);

                    arrayModule[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            }
            return drawImage(arrayModule);
        }

        public static Bitmap direction()
        {
            double z1, z2, z3, z4, z5, z6, z7, z8, z9;
            double gx, gy;
           
            for (int x = 1; x < _width - 1; x++)
            {
                for (int y = 1; y < _height - 1; y++)
                {
                    z1 = sourceImage[x - 1, y - 1];
                    z2 = sourceImage[x - 1, y];
                    z3 = sourceImage[x - 1, y + 1];
                    z4 = sourceImage[x, y - 1];
                    z5 = sourceImage[x, y];
                    z6 = sourceImage[x, y + 1];
                    z7 = sourceImage[x + 1, y - 1];
                    z8 = sourceImage[x + 1, y];
                    z9 = sourceImage[x + 1, y + 1];

                    gx = (z7 + 2 * z8 + z9) - (z1 + 2 * z2 + z3);
                    gy = (z3 + 2 * z6 + z9) - (z1 + 2 * z4 + z7);

                    /*
                    if (gx == 0)
                    {
                        if (gy == 0) angle = 0;
                        else if (gy > 0) angle = 90;
                        else angle = 270;
                    }
                    else
                    {
                        radians = Math.Atan(gy / gx);
                        angle = radians * (180 / Math.PI);  //получение значения в градусах

                        if ((gy > 0) && (gx < 0)) // вторая четверть
                            angle = angle + 180;
                        if ((gy < 0) && (gx < 0)) //третья четверть
                            angle = angle + 180;
                        if ((gy < 0) && (gx > 0)) //четвертая четверть
                            angle = angle + 360;
                    }*/

                    arrayAngle[x, y] = atan2(gy, gx);
                }
            }
            return drawImage(arrayAngle);
        }

        public static void gradient(int size)
        {
            int outer = (size+1)/2;
            int inner = (size-1)/2;
            for (int x = outer; x < _width - outer; x++)
            {
                for (int y = outer; y < _height - outer; y++)
                {
                    double sumX = 0;
                    double sumY = 0;
                    for (int w = x - inner; w < x + inner; w++)
                    {
                        for (int z = y - inner; z < y + inner; z++)
                        {
                            sumX += arrayModule[w, z] * cos(2 * arrayAngle[w, z]);
                            sumY += arrayModule[w, z] * sin(2 * arrayAngle[w, z]);
                        }
                    }

                    bigModule[x, y] = Math.Sqrt(sumX * sumX + sumY * sumY);
                    bigAngle[x, y] = atan2(sumY, sumX)/2;
                }
            }
        }

        public static Bitmap gModule()
        {
            return drawImage(bigModule);
        }

        public static Bitmap gDirection()
        {
            return drawImage(bigAngle);
        }

        private static double cos(double angle) {
            return Math.Cos(angle / RAD2DEG);
        }

        private static double sin(double angle) {
            return Math.Sin(angle / RAD2DEG);
        }

        private static double atan2(double y, double x) {
            double angle = Math.Atan2(y, x) * RAD2DEG;
            if (angle < 0) angle += 360.0;
            return angle;
        }

        public static Bitmap testImage(int w, int h)
        {
            Bitmap image = new Bitmap(w, h);

            double xCen = image.Width/2;
            double yCen = image.Height/2;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
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
