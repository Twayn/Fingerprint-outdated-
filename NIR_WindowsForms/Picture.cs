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
                    try
                    {
                        int temp = Convert.ToInt32(array[x, y] / ratio);
                        
                        image.SetPixel(x, y, Color.FromArgb(temp, temp, temp));
                    }
                    catch (System.OverflowException e)
                    {
                        Console.WriteLine("X: " + x);
                        Console.WriteLine("Y: " + y);
                        Console.WriteLine("array[x,y]: " + array[x, y]);
                        Console.WriteLine("ratio: " + ratio);
                    }
                    
                }
            }

            return image;
        }




        public static Bitmap drawImage1(double[,] array)
        {
            Bitmap image = new Bitmap(width, height);


            double minVal = 10000;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if (array[x, y] < minVal)
                    {
                        minVal = array[x, y];
                    }
                }
            }

           

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    array[x, y] += Math.Abs(minVal);
                }
            }


            double ratio = calcRatio(array);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    try
                    {
                        int temp = Convert.ToInt32(array[x, y] / ratio);
                        image.SetPixel(x, y, Color.FromArgb(temp, temp, temp));
                    }
                    catch (System.OverflowException e)
                    {
                        Console.WriteLine("X: " + x);
                        Console.WriteLine("Y: " + y);
                        Console.WriteLine("array[x,y]: " + array[x, y]);
                        Console.WriteLine("ratio: " + ratio);
                    }

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

        private static double[,] normalize(double[,] image)
        {
            double minVal = 10000;

            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    if (image[x, y] < minVal){
                        minVal = image[x, y];
                    }
                }
            }

            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    image[x, y] += minVal;
                }
            }

            return image;
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

        //Bresenham's line algorithm
        public static List<Coord> getLine(int x1, int y1, int x2, int y2) {
            List<Coord> coordinates = new List<Coord>();

            Color red = Color.FromArgb(255, 0, 0);
            int deltaX = Math.Abs(x2 - x1);
            int deltaY = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            
            int error = deltaX - deltaY;
 
            while(x1 != x2 || y1 != y2) {
                coordinates.Add(new Coord(x1, y1));

                int error2 = error * 2;
                
                if(error2 > -deltaY) {
                    error -= deltaY;
                    x1 += signX;
                }
                if(error2 < deltaX) {
                    error += deltaX;
                    y1 += signY;
                }
            }
            coordinates.Add(new Coord(x2, y2));

            return coordinates;
        }

        public static int[] hist(Bitmap image_arg) {
            Bitmap image = new Bitmap(image_arg);
            int[] hist = new int[256];

            int border = 15;

            for (int x = border; x < image.Width - border; x++) {
                for (int y = border; y < image.Height - border; y++) {
                    int i = Convert.ToInt32(image.GetPixel(x, y).GetBrightness() * 255);
                    hist[i]++;
                }
            }
            return hist;
        }

        public static Bitmap binary(Bitmap image, float division) {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            Color white = Color.FromArgb(255, 255, 255);
            Color black = Color.FromArgb(0, 0, 0);
            for (int x = 0; x < image.Width; x++) {
                for (int y = 0; y < image.Height; y++) {
                    if ((image.GetPixel(x, y).GetBrightness() * 255) > division) {
                        resultImage.SetPixel(x, y, white);
                    } else {
                        resultImage.SetPixel(x, y, black);
                    }
                }
            }
            return resultImage;
        }
    }
}
