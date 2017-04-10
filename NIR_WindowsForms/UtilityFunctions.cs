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

        private static double[,] areaCoh;

        private static double[,] areaCohMin;
        private static double[,] areaCohMax;

        private static double[,] density;

        public static void setInitialData(Bitmap image)
        {
            _width = image.Width;
            _height = image.Height;

            Picture.setDimensions(_width, _height);

            sourceImage = new double[_width, _height];

            //Load brightness of image pixels to matrix
            for (int i = 0; i < _width; i++) {
                for (int j = 0; j < _height; j++) {
                    sourceImage[i, j] = image.GetPixel(i, j).GetBrightness() * 255;
                }
            }

            pointModule = new double[_width, _height];
            pointAngle = new double[_width, _height];

            areaModule = new double[_width, _height];
            areaAngle = new double[_width, _height];

            areaCoh = new double[_width, _height];

            areaCohMin = new double[_width, _height];
            areaCohMax = new double[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    areaCohMin[x, y] = 1;
                }
            }

            density = new double[_width, _height];
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
                    //Coherence
                    if (sumModules == 0) { 
                        areaCoh[x, y] = 0; 
                    } else {
                        areaCoh[x, y] = areaModule[x, y] / sumModules;
                    }
                    
                    //areaAngle[x, y] = Trigon.atanInt((int)Math.Ceiling(sumY), (int)Math.Ceiling(sumX)) / 2;
                }
            }
        }

        /*Module and argument of gradient (at area)*/
        public static void minMaxCoh()
        {
            for (int size = 7; size < 19; size+=2) {
                int outer = (size + 1) / 2;
                
                for (int x = outer; x < _width - outer; x++)
                {
                    for (int y = outer; y < _height - outer; y++)
                    {
                        double var = cohArea(size, x, y);

                        if (var > areaCohMax[x, y]){
                            areaCohMax[x, y] = var;
                        }
                        if (var < areaCohMin[x, y]) {
                            areaCohMin[x, y] = var;
                        }
                    }
                }
            } 
        }

        public static double cohArea(int size, int x, int y) {
            double sumX = 0;
            double sumY = 0;
            double sumModules = 0;

            int area = (size - 1) / 2;

            for (int w = x - area; w < x + area; w++) {
                for (int z = y - area; z < y + area; z++) {
                    sumX += pointModule[w, z] * Trigon.cos(2 * pointAngle[w, z]);
                    sumY += pointModule[w, z] * Trigon.sin(2 * pointAngle[w, z]);

                    sumModules += pointModule[w, z];
                }
            }
            return (Math.Sqrt(sumX * sumX + sumY * sumY) / sumModules);
        }

        //public static double cohArea(int size, int x, int y) {
        //    double sumX = 0;
        //    double sumY = 0;
        //    double sumModules = 0;

        //    if (size % 2 == 0)
        //    {
        //        int area = size / 2;

        //        for (int w = x - area; w < x + area-1; w++)
        //        {
        //            for (int z = y - area; z < y + area-1; z++)
        //            {
        //                sumX += pointModule[w, z] * Trigon.cos(2 * pointAngle[w, z]);
        //                sumY += pointModule[w, z] * Trigon.sin(2 * pointAngle[w, z]);

        //                sumModules += pointModule[w, z];
        //            }
        //        }
        //    }
        //    else {
        //        int area = (size - 1) / 2;

        //        for (int w = x - area; w < x + area; w++)
        //        {
        //            for (int z = y - area; z < y + area; z++)
        //            {
        //                sumX += pointModule[w, z] * Trigon.cos(2 * pointAngle[w, z]);
        //                sumY += pointModule[w, z] * Trigon.sin(2 * pointAngle[w, z]);

        //                sumModules += pointModule[w, z];
        //            }
        //        }
        //    }
        //    //Coherence
        //    return (Math.Sqrt(sumX * sumX + sumY * sumY) / sumModules);
        //}

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
            return Picture.drawImage(areaCoh);
        }

        public static Bitmap aCohMin()
        {
            return Picture.drawImage(areaCohMin);
        }

        public static Bitmap aCohMax()
        {
            return Picture.drawImage(areaCohMax);
        }

        public static Bitmap aDencity()
        {
            return Picture.drawImage(density);
        }

        public static Bitmap directionField(){
            Bitmap image = new Bitmap(_width, _height);
            Pen blackPen = new Pen(Color.Black, 1);

            //Best view
            int length = 10;
            int area = 16;

            using (var graphics = Graphics.FromImage(image)){
                for (int x = area; x < _width - area; x += area){
                    for (int y = area; y < _height - area; y += area){
                        if (areaAngle[x, y] <= 180.0){
                            graphics.DrawLine(blackPen, 
                             Convert.ToInt32(x + Trigon.cos(areaAngle[x, y]) * length / 2),
                             Convert.ToInt32(y + Trigon.sin(areaAngle[x, y]) * length / 2),
                             Convert.ToInt32(x + Trigon.cos(areaAngle[x, y] + 180) * length / 2),
                             Convert.ToInt32(y + Trigon.sin(areaAngle[x, y] + 180) * length / 2));
                        }
                        else {
                            graphics.DrawLine(blackPen,
                             Convert.ToInt32(x + Trigon.cos(areaAngle[x, y]) * length / 2),
                             Convert.ToInt32(y + Trigon.sin(areaAngle[x, y]) * length / 2),
                             Convert.ToInt32(x + Trigon.cos(areaAngle[x, y]-180) * length / 2),
                             Convert.ToInt32(y + Trigon.sin(areaAngle[x, y]-180) * length / 2));
                        }
                    }
                }
            }

            return image;
        }

        public static Bitmap blur(Bitmap image, int[] filter)
        {
            Bitmap resultImage = new Bitmap(image);

            double equalizer = 0;

            for (int i = 0; i < filter.Length; i++)
            {
                equalizer += filter[i];
            }
            equalizer = 1 / equalizer;

                for (int x = 1; x < image.Width - 1; x++)
                {
                    for (int y = 1; y < image.Height - 1; y++)
                    {
                        double color = 0;

                        color += image.GetPixel(x - 1, y - 1).GetBrightness() * 255 * filter[0] * equalizer;
                        color += image.GetPixel(x - 1, y).GetBrightness() * 255 * filter[1] * equalizer;
                        color += image.GetPixel(x - 1, y + 1).GetBrightness() * 255 * filter[2] * equalizer;
                        color += image.GetPixel(x, y - 1).GetBrightness() * 255 * filter[3] * equalizer;
                        color += image.GetPixel(x, y).GetBrightness() * 255 * filter[4] * equalizer;
                        color += image.GetPixel(x, y + 1).GetBrightness() * 255 * filter[5] * equalizer;
                        color += image.GetPixel(x + 1, y - 1).GetBrightness() * 255 * filter[6] * equalizer;
                        color += image.GetPixel(x + 1, y).GetBrightness() * 255 * filter[7] * equalizer;
                        color += image.GetPixel(x + 1, y + 1).GetBrightness() * 255 * filter[8] * equalizer;

                        Color averageColor = Color.FromArgb(Convert.ToInt32(color), Convert.ToInt32(color), Convert.ToInt32(color));
                        resultImage.SetPixel(x, y, averageColor);
                    }
                }

            return resultImage;
        }

        public static void ridgeDensity(int lineLength) {

            for (int x = lineLength / 2; x < _width - lineLength / 2; x++) {
                for (int y = lineLength / 2; y < _height - lineLength / 2; y++) {
                    double angle = areaAngle[x, y];

                    List<Coord> lineCoordinates = new List<Coord>();

                    if (angle <= 180.0) {
                        lineCoordinates = getLine(
                         Convert.ToInt32(x + Trigon.cos(angle) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle) * lineLength / 2),
                         Convert.ToInt32(x + Trigon.cos(angle + 180) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle + 180) * lineLength / 2));
                    } else {
                        lineCoordinates = getLine(
                         Convert.ToInt32(x + Trigon.cos(angle) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle) * lineLength / 2),
                         Convert.ToInt32(x + Trigon.cos(angle - 180) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle - 180) * lineLength / 2));
                    }

                    List<int> maximas = new List<int>();

                    for (int i = 1; i < lineCoordinates.Count - 1; i++) {
                        double left = sourceImage[lineCoordinates[i - 1].getX(), lineCoordinates[i - 1].getY()];
                        double center = sourceImage[lineCoordinates[i].getX(), lineCoordinates[i].getY()];
                        double right = sourceImage[lineCoordinates[i + 1].getX(), lineCoordinates[i + 1].getY()];

                        if (center > left && center > right) {
                            maximas.Add(i);
                        }
                    }


                    int delimeter = maximas.Count - 1;
                    int divider = 0;

                    for (int i = 0; i < maximas.Count - 1; i++) {
                        divider += Math.Abs(maximas[i] - maximas[i + 1]);
                    }

                    double dencity = (double)delimeter / divider;
                    //Console.WriteLine(dencity);

                    if (divider == 0) { dencity = 1; }

                    density[x, y] = dencity;
                }
            }
        }

        //public static Bitmap oneRidgeDensity()
        //{
        //    int lineLength = 20;

        //    int x = 100;
        //    int y = 100;
        //    double angle = areaAngle[x, y];

        //    Bitmap b = Picture.drawImage(sourceImage);

        //    //for (int x = lineLength / 2; x < _width - lineLength / 2; x++)
        //    //{
        //    //    for (int y = lineLength / 2; y < _height - lineLength / 2; y++)
        //    //    {
                    
        //            List<Coord> lineCoordinates = new List<Coord>();

        //            if (angle <= 180.0)
        //            {
        //                lineCoordinates = getLine(
        //                 Convert.ToInt32(x + Trigon.cos(angle) * lineLength / 2),
        //                 Convert.ToInt32(y + Trigon.sin(angle) * lineLength / 2),
        //                 Convert.ToInt32(x + Trigon.cos(angle + 180) * lineLength / 2),
        //                 Convert.ToInt32(y + Trigon.sin(angle + 180) * lineLength / 2), b);
        //            }
        //            else
        //            {
        //                lineCoordinates = getLine(
        //                 Convert.ToInt32(x + Trigon.cos(angle) * lineLength / 2),
        //                 Convert.ToInt32(y + Trigon.sin(angle) * lineLength / 2),
        //                 Convert.ToInt32(x + Trigon.cos(angle - 180) * lineLength / 2),
        //                 Convert.ToInt32(y + Trigon.sin(angle - 180) * lineLength / 2), b);
        //            }

        //            foreach (Coord c in lineCoordinates) {
        //                Console.WriteLine("X: " + c.getX() + " Y: " + c.getY() + " BRIGHTNESS: " + sourceImage[c.getX(), c.getY()]);
        //            }

        //            List<int> maximas = new List<int>();

        //            for (int i = 1; i < lineCoordinates.Count - 1; i++)
        //            {
        //                double left = sourceImage[lineCoordinates[i - 1].getX(), lineCoordinates[i - 1].getY()];
        //                double center = sourceImage[lineCoordinates[i].getX(), lineCoordinates[i].getY()];
        //                double right = sourceImage[lineCoordinates[i + 1].getX(), lineCoordinates[i + 1].getY()];

        //                if (center > left && center > right)
        //                {
        //                    maximas.Add(i);
        //                    Console.WriteLine(center);
        //                }
        //            }

        //            foreach (var v in maximas)
        //            {
        //                Console.WriteLine("MAX: " + v);
        //            }


        //            int delimeter = maximas.Count - 1;
        //            int divider = 0;

        //            for (int i = 0; i < maximas.Count - 1; i++)
        //            {
        //                divider += Math.Abs(maximas[i] - maximas[i + 1]);
        //            }

        //            double dencity = (double)delimeter / divider;
                   
        //            if (divider == 0) { dencity = 1; }

        //            Console.WriteLine("delimeter" + delimeter);
        //            Console.WriteLine("divider" + divider);
        //            Console.WriteLine("result" + dencity);
                    

        //    //    }
        //    //}

        //            return b;
        //}

        //Bresenham's line algorithm
        private static List<Coord> getLine(int x1, int y1, int x2, int y2) {
            List<Coord> coordinates = new List<Coord>();

            Color red = Color.FromArgb(255, 0, 0);
            int deltaX = Math.Abs(x2 - x1);
            int deltaY = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            
            int error = deltaX - deltaY;
 
            while(x1 != x2 || y1 != y2) 
            {
                //image.SetPixel(x1, y1, red);
                coordinates.Add(new Coord(x1, y1));

                int error2 = error * 2;
                
                if(error2 > -deltaY) 
                {
                    error -= deltaY;
                    x1 += signX;
                }
                if(error2 < deltaX) 
                {
                    error += deltaX;
                    y1 += signY;
                }
            }

            //image.SetPixel(x2, y2, red);
            coordinates.Add(new Coord(x2, y2));

            return coordinates;
        }

        private class Coord { 
            private int x, y;

            public Coord(int x, int y){
                this.x = x;
                this.y = y;
            }

            public int getX(){
                return x;
            }

            public int getY(){
                return y;
            }
        }
    }
}