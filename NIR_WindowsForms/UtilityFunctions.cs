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
        private static int _height;
        private static int _width;

        private static double[,] sourceImage;

        private static double[,] pointModule;
        private static double[,] pointAngle;

        private static double[,] areaModule;
        private static double[,] areaAngle;

        private static double[,] coh;

        public static void setInitialData(Bitmap image)
        {
            _width = image.Width;
            _height = image.Height;

            Picture.setDimensions(_width, _height);

            sourceImage = new double[_width, _height];

            for (int i = 0; i < _width; i++) {
                for (int j = 0; j < _height; j++) {
                    sourceImage[i, j] = image.GetPixel(i, j).GetBrightness() * 255;
                }
            }

            pointModule = new double[_width, _height];
            pointAngle = new double[_width, _height];

            areaModule = new double[_width, _height];
            areaAngle = new double[_width, _height];

            coh = new double[_width, _height];
        }

        /*Module and argument of gradient (at point)*/
        public static void pointGrad() {
            double z1, z2, z3, z4, z5, z6, z7, z8, z9;
            double gx, gy;

            for (int x = 1; x < _width - 1; x++) {
                for (int y = 1; y < _height - 1; y++) {
                    z1 = sourceImage[x - 1, y - 1];
                    z2 = sourceImage[x - 1, y];
                    z3 = sourceImage[x - 1, y + 1];
                    z4 = sourceImage[x, y - 1];
                    z5 = sourceImage[x, y];
                    z6 = sourceImage[x, y + 1];
                    z7 = sourceImage[x + 1, y - 1];
                    z8 = sourceImage[x + 1, y];
                    z9 = sourceImage[x + 1, y + 1];

                    /*Sobel operator*/
                    gx = (z7 + 2 * z8 + z9) - (z1 + 2 * z2 + z3);
                    gy = (z3 + 2 * z6 + z9) - (z1 + 2 * z4 + z7);

                    pointModule[x, y] = Math.Sqrt(gx * gx + gy * gy);
                    pointAngle[x, y] = Trigon.atanDouble(gy, gx);
                    //pointAngle[x, y] = Trigon.atanInt((int)Math.Ceiling(gy), (int)Math.Ceiling(gx));
                }
            }
        }

        /*Module and argument of gradient (at area)*/
        public static void areaGrad(int size) {
            int outer = (size + 1) / 2;
            int inner = (size - 1) / 2;

            for (int x = outer; x < _width - outer; x++) {
                for (int y = outer; y < _height - outer; y++) {
                    double sumX = 0;
                    double sumY = 0;

                    double sumModules = 0;
                    
                    for (int w = x - inner; w < x + inner; w++) {
                        for (int z = y - inner; z < y + inner; z++) {
                            sumX += pointModule[w, z] * Trigon.cos(2 * pointAngle[w, z]);
                            sumY += pointModule[w, z] * Trigon.sin(2 * pointAngle[w, z]);

                            sumModules += pointModule[w, z];
                        }
                    }

                    areaModule[x, y] = Math.Sqrt(sumX * sumX + sumY * sumY);
                    areaAngle[x, y] = Trigon.atanDouble(sumY, sumX) / 2;
                    coh[x, y] = areaModule[x, y] / sumModules;
                    //areaAngle[x, y] = Trigon.atanInt((int)Math.Ceiling(sumY), (int)Math.Ceiling(sumX)) / 2;
                }
            }
        }

        public static Bitmap pModule(){
            return Picture.drawImage(pointModule);
        }

        public static Bitmap pDirection(){
            return Picture.drawImage(pointAngle);
        }

        public static Bitmap aModule(){
            return Picture.drawImage(areaModule);
        }

        public static Bitmap aDirection(){
            return Picture.drawImage(areaAngle);
        }

        public static Bitmap aCoh(){
            return Picture.drawImage(coh);
        }

        public static Bitmap directionField(){
            Bitmap image = new Bitmap(_width, _height);
            Pen blackPen = new Pen(Color.Black, 1);

            int length = 9;
            int area = 20;

            using (var graphics = Graphics.FromImage(image)){
                for (int x = area; x < _width - area; x += area){
                    for (int y = area; y < _height - area; y += area){
                        graphics.DrawLine(blackPen, x, y,
                             Convert.ToInt32(x + Trigon.cos(areaAngle[x, y]) * length),
                             Convert.ToInt32(y + Trigon.sin(areaAngle[x, y]) * length));
                    }
                }
            }

            return image;
        }
    }
}