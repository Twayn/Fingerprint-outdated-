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
        public static int[] filter;

        private static int _height;
        private static int _width;

        private static string path = @"C:\bbb\1.txt";
        private static System.IO.StreamWriter file = new System.IO.StreamWriter(path/*, true*/);

        private static double[,] sourceImage;

        private static double[,] pointModule;
        private static double[,] pointAngle;

        private static double[,] areaModule;
        private static double[,] areaAngle;

        private static double[,] areaCoh;

        private static double[,] areaCohMin;
        private static double[,] areaCohMax;

        private static double[,] density;
        private static double[,] averageDensity;
        private static double[,] qualityDencity;
        private static double[,] qualityAreaDencity;

        private static double[,] verBlur;

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

            for (int x = 0; x < _width; x++){
                for (int y = 0; y < _height; y++){
                    areaCohMin[x, y] = 1;
                }
            }

            density = new double[_width, _height]; 
            averageDensity = new double[_width, _height];
            qualityDencity = new double[_width, _height];
            qualityAreaDencity = new double[_width, _height];

            verBlur = new double[_width, _height];
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

        public static Bitmap pDencity()
        {
            return Picture.drawImage(density);
        }

        public static Bitmap aDencity()
        {
            return Picture.drawImage(averageDensity);
        }

        public static Bitmap qualityDenc()
        {
            return Picture.drawImage(qualityDencity);
        }

        public static Bitmap aQualityDenc()
        {
            return Picture.drawImage(qualityAreaDencity);
        }

        public static Bitmap hairVeronicaBlur()
        {
            return Picture.drawImage(verBlur);
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

            for (int x = 1; x < _width - 1; x++)
            {
                for (int y = 1; y < _height - 1; y++)
                {
                    double color = 0;

                    color += sourceImage[x - 1, y - 1] * filter[0] * equalizer;
                    color += sourceImage[x - 1, y] * filter[1] * equalizer;
                    color += sourceImage[x - 1, y + 1] * filter[2] * equalizer;
                    color += sourceImage[x, y - 1] * filter[3] * equalizer;
                    color += sourceImage[x, y] * filter[4] * equalizer;
                    color += sourceImage[x, y + 1] * filter[5] * equalizer;
                    color += sourceImage[x + 1, y - 1] * filter[6] * equalizer;
                    color += sourceImage[x + 1, y] * filter[7] * equalizer;
                    color += sourceImage[x + 1, y + 1] * filter[8] * equalizer;

                    Color averageColor = Color.FromArgb(Convert.ToInt32(color), Convert.ToInt32(color), Convert.ToInt32(color));
                    resultImage.SetPixel(x, y, averageColor);
                }
            }

            return resultImage;
        }

        public static void veronicaBlur(){
            double equalizer = 0;

            for (int i = 0; i < filter.Length; i++){
                equalizer += filter[i];
            }
            equalizer = 1 / equalizer;

            for (int x = 1; x < _width - 1; x++) {
                for (int y = 1; y < _height - 1; y++) {
                    double color = 0;

                    color += qualityAreaDencity[x - 1, y - 1] * filter[0] * equalizer;
                    color += qualityAreaDencity[x - 1, y] * filter[1] * equalizer;
                    color += qualityAreaDencity[x - 1, y + 1] * filter[2] * equalizer;
                    color += qualityAreaDencity[x, y - 1] * filter[3] * equalizer;
                    color += qualityAreaDencity[x, y] * filter[4] * equalizer;
                    color += qualityAreaDencity[x, y + 1] * filter[5] * equalizer;
                    color += qualityAreaDencity[x + 1, y - 1] * filter[6] * equalizer;
                    color += qualityAreaDencity[x + 1, y] * filter[7] * equalizer;
                    color += qualityAreaDencity[x + 1, y + 1] * filter[8] * equalizer;

                    verBlur[x, y] = color;
                }
            }
        }

        public static void ridgeDensity(int lineLength) {
            for (int x = lineLength / 2; x < _width - lineLength / 2; x++) {
                for (int y = lineLength / 2; y < _height - lineLength / 2; y++) {
                    double angle = areaAngle[x, y];
                    List<Coord> lineCoordinates = new List<Coord>();

                    if (angle <= 180.0) {
                        lineCoordinates = Picture.getLine(
                         Convert.ToInt32(x + Trigon.cos(angle) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle) * lineLength / 2),
                         Convert.ToInt32(x + Trigon.cos(angle + 180) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle + 180) * lineLength / 2));
                    }
                    else {
                        lineCoordinates = Picture.getLine(
                         Convert.ToInt32(x + Trigon.cos(angle) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle) * lineLength / 2),
                         Convert.ToInt32(x + Trigon.cos(angle - 180) * lineLength / 2),
                         Convert.ToInt32(y + Trigon.sin(angle - 180) * lineLength / 2));
                    }
                   
                    density[x, y] = calcDencity(lineCoordinates, x, y);
                    //file.WriteLine("X: " + x + "; Y: " + y + "; DENS: " + density[x, y]);
                }
            }
        }

        /*Average dencity (at area)*/
        public static void areaRidgeDencity(int size){

            int outer = (size + 1) / 2;
            int inner = (size - 1) / 2;

            for (int x = outer; x < _width - outer; x++){
                for (int y = outer; y < _height - outer; y++){
                    double averDencity = 0;

                    for (int w = x - inner; w < x + inner; w++){
                        for (int z = y - inner; z < y + inner; z++){
                            averDencity += density[w, z];
                        }
                    }
                    averageDensity[x, y] = averDencity/(size*size);
                }
            }
        }

        /*Max quality dencity (at area)*/
        public static void areaQualityDenc(int size) {
            int outer = (size + 1) / 2;
            int inner = (size - 1) / 2;

            for (int x = outer; x < _width - outer; x++)
            {
                for (int y = outer; y < _height - outer; y++)
                {
                    double maxQuality = 0;

                    for (int w = x - inner; w < x + inner; w++)
                    {
                        for (int z = y - inner; z < y + inner; z++)
                        {
                            if (qualityDencity[w, z] > maxQuality) {
                                maxQuality = qualityDencity[w, z];
                            }
                        }
                    }
                    qualityAreaDencity[x, y] = maxQuality;
                }
            }
        }

        private static double calcDencity(List<Coord> lineCoordinates, int x, int y){
            List<int> maximas = new List<int>();
            List<double> derivative = new List<double>();
            List<double> amplitude = new List<double>();

            for (int i = 1; i < lineCoordinates.Count - 1; i++)
            {
                double left = pointModule[lineCoordinates[i - 1].getX(), lineCoordinates[i - 1].getY()];
                double right = pointModule[lineCoordinates[i + 1].getX(), lineCoordinates[i + 1].getY()];

                derivative.Add(right-left);
            }

            //foreach (var v in derivative) {
            //    file.WriteLine("deriviative: " + v);
            //}

            for (int i = 1; i < derivative.Count - 1; i++)
            {
                double left = derivative[i - 1];
                double center = derivative[i];
                double right = derivative[i +1];

                if (center > left && center > right && center > 20)
                {
                    maximas.Add(i);
                    amplitude.Add(center);
                }
            }

            //foreach (var v in maximas)
            //{
            //    file.WriteLine("max: " + v);
            //}

            int delimeter = maximas.Count - 1;
            int divider = 0;

            for (int i = 0; i < maximas.Count - 1; i++) {
                divider += Math.Abs(maximas[i] - maximas[i + 1]);
            }

            double dencity = (double)delimeter / divider; //Frequency
           
            if (divider == 0) { dencity = 1; }

            //file.WriteLine("DENC: " + dencity);
            if (amplitude.Count != 0) {
                //file.WriteLine("AMPL MIN: " + amplitude.Min());
                qualityDencity[x,y] = amplitude.Min();
            }
            
            return dencity;
        }
    }
}