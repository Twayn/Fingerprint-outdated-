using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NIR_WindowsForms
{
    class Skeleton
    {
        static List<Coordinates> coordinates;

        private static int width;
        private static int height;

        public static Bitmap skeleton(Bitmap binaryImage)
        {
            int _width = binaryImage.Width;
            int _height = binaryImage.Height;

            width = _width;
            height = _height;

            double[,] binary = new double[_width, _height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    binary[i, j] = binaryImage.GetPixel(i, j).GetBrightness() * 255;
                }
            }

            bool flag = true;

            while (flag) {
                bool firstFlag = false;
                bool secondFlag = false;

                coordinates = firstStep(binary);
                binary = deletePixels(binary, coordinates);
                if (coordinates.Count == 0) firstFlag = true;

                coordinates = secondStep(binary);
                binary = deletePixels(binary, coordinates);

                if (coordinates.Count == 0) secondFlag = true;

                if (firstFlag && secondFlag)
                {
                    flag = false;
                }
            }

            binary = clearSides(binary);
            binary = delSinglePixels(binary);
            binary = to8(binary);
            binary = to8(binary);

            Bitmap image = drawImage(binary);

            image = markSpecialPoints(image);
            image = delBranches(image);

            return image;
            return drawImage(binary);
        }

        public static List<Coordinates> firstStep(double[,] binary)
        {
            coordinates = new List<Coordinates>();
            bool z1, z2, z3, z4, z5, z6, z7, z8, z9;

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    z1 = toBool(binary[x, y]);
                    z2 = toBool(binary[x, y - 1]);
                    z3 = toBool(binary[x + 1, y - 1]);
                    z4 = toBool(binary[x + 1, y]);
                    z5 = toBool(binary[x + 1, y + 1]);
                    z6 = toBool(binary[x, y + 1]);
                    z7 = toBool(binary[x - 1, y + 1]);
                    z8 = toBool(binary[x - 1, y]);
                    z9 = toBool(binary[x - 1, y - 1]);

                    bool[] mas = {/*z1,*/ z2, z3, z4, z5, z6, z7, z8, z9 };
                    if (z1 == false) //For area pixels
                    {
                        if (isBorderPixel(mas))
                        { //That's also border pixels
                            if (checkFirstStepRules(mas)) //If validate is succeed add them to list
                            {
                                coordinates.Add(new Coordinates(x, y));
                            }
                        }
                    }
                }
            }
            return coordinates;
        }

        public static List<Coordinates> secondStep(double[,] binary)
        {
            coordinates = new List<Coordinates>();

            bool z1, z2, z3, z4, z5, z6, z7, z8, z9;

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    z1 = toBool(binary[x, y]);
                    z2 = toBool(binary[x, y - 1]);
                    z3 = toBool(binary[x + 1, y - 1]);
                    z4 = toBool(binary[x + 1, y]);
                    z5 = toBool(binary[x + 1, y + 1]);
                    z6 = toBool(binary[x, y + 1]);
                    z7 = toBool(binary[x - 1, y + 1]);
                    z8 = toBool(binary[x - 1, y]);
                    z9 = toBool(binary[x - 1, y - 1]);

                    bool[] mas = {/*z1,*/ z2, z3, z4, z5, z6, z7, z8, z9 };
                    if (z1 == false)
                    {
                        if (isBorderPixel(mas))
                        {
                            if (checkSecondStepRules(mas))
                            {
                                coordinates.Add(new Coordinates(x, y));
                            }
                        }
                    }
                }
            }
            return coordinates;
        }

        private static double[,] deletePixels(double[,] binary, List<Coordinates> coordinates) {
            foreach (Coordinates c in coordinates) {
                binary[c.getX(), c.getY()] = 255;
            }
            return binary;
        }

        private static bool checkFirstStepRules(bool[] mas) {
            if (checkFirstRule(mas) &&
                checkSecondRule(mas) &&
                checkThirdRuleV1(mas) &&
                checkFourthRuleV1(mas)) {
                return true;
            }
            else return false;
        }

        private static bool checkSecondStepRules(bool[] mas) {
            if (checkFirstRule(mas) &&
                checkSecondRule(mas) &&
                checkThirdRuleV2(mas) &&
                checkFourthRuleV2(mas)) {
                return true;
            }
            else return false;
        }

        private static bool checkFirstRule(bool[] mas)
        {
            //Проверить число ненулевых элементов (черных)
            int areaCount = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == false) areaCount++;
            }
            if ((areaCount >= 2) && (areaCount <= 6))
            {
                return true;
            }
            else return false;
        }

        private static bool checkSecondRule(bool[] mas) {
            //Count number of jumps background -> area
            int jumpCount = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if ((mas[i] == true) && (mas[i + 1] == false))
                {
                    jumpCount++;
                }
            }
            if ((mas[mas.Length - 1] == true) && (mas[0] == false))
            {
                jumpCount++;
            }
            if (jumpCount == 1)
            {
                return true;
            }
            else return false;
        }
        private static bool checkThirdRuleV1(bool[] mas){
            if (mas[0] || mas[2] || mas[4]) return true;
            else return false;
        }
        private static bool checkFourthRuleV1(bool[] mas){
            if (mas[2] || mas[4] || mas[6]) return true;
            else return false;
        }
        private static bool checkThirdRuleV2(bool[] mas){
            if (mas[0] || mas[2] || mas[6]) return true;
            else return false;
        }
        private static bool checkFourthRuleV2(bool[] mas){
            if (mas[0] || mas[4] || mas[6]) return true;
            else return false;
        }

        private static bool toBool(double x){
            return x != 0.0d;
        }

        private static bool isBorderPixel(bool[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == true)
                {
                    return true;
                }
            }
            return false;
        }

        private static double[,] clearSides(double[,] binary)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((x == 0) || (y == 0) || (x == width - 1) || (y == height - 1))
                    {
                        binary[x, y] = 255;
                    }
                }
            }
            return binary;
        }

        private static double[,] delSinglePixels(double[,] binary)
        {
            bool z1, z2, z3, z4, z5, z6, z7, z8, z9;
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    z1 = toBool(binary[x, y]);
                    z2 = toBool(binary[x, y - 1]);
                    z3 = toBool(binary[x + 1, y - 1]);
                    z4 = toBool(binary[x + 1, y]);
                    z5 = toBool(binary[x + 1, y + 1]);
                    z6 = toBool(binary[x, y + 1]);
                    z7 = toBool(binary[x - 1, y + 1]);
                    z8 = toBool(binary[x - 1, y]);
                    z9 = toBool(binary[x - 1, y - 1]);

                    if ((z1 == false) && (z2 && z3 && z4 && z5 && z6 && z7 && z8 && z9))
                    {
                        binary[x, y] = 255;
                    }
                }
            }
            return binary;
        }

        private static Bitmap markSpecialPoints(Bitmap binaryImage)
        {
            float z1, z2, z3, z4, z5, z6, z7, z8, z9;
            Color white = Color.FromArgb(255, 255, 255);
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            for (int x = 1; x < binaryImage.Width - 1; x++)
            {
                for (int y = 1; y < binaryImage.Height - 1; y++)
                {
                    z1 = binaryImage.GetPixel(x, y).GetBrightness();
                    z2 = binaryImage.GetPixel(x, y - 1).GetBrightness();
                    z3 = binaryImage.GetPixel(x + 1, y - 1).GetBrightness();
                    z4 = binaryImage.GetPixel(x + 1, y).GetBrightness();
                    z5 = binaryImage.GetPixel(x + 1, y + 1).GetBrightness();
                    z6 = binaryImage.GetPixel(x, y + 1).GetBrightness();
                    z7 = binaryImage.GetPixel(x - 1, y + 1).GetBrightness();
                    z8 = binaryImage.GetPixel(x - 1, y).GetBrightness();
                    z9 = binaryImage.GetPixel(x - 1, y - 1).GetBrightness();

                    if ((z2 + z3 + z4 + z5 + z6 + z7 + z8 + z9 == 7) && (z1 == 0))
                    {
                        binaryImage.SetPixel(x, y, red); //Точки конца
                    }

                    if ((z2 + z3 + z4 + z5 + z6 + z7 + z8 + z9 == 5) && (z1 == 0))
                    {
                        binaryImage.SetPixel(x, y, green); //Точки ветвления
                    }
                }
            }
            return binaryImage;
        }

        private static double[,] to8(double[,] binary)
        {
            bool z1, z2, z3, z4, z5, z6, z7, z8, z9;

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    z1 = toBool(binary[x, y]);
                    z2 = toBool(binary[x, y - 1]);
                    z3 = toBool(binary[x + 1, y - 1]);
                    z4 = toBool(binary[x + 1, y]);
                    z5 = toBool(binary[x + 1, y + 1]);
                    z6 = toBool(binary[x, y + 1]);
                    z7 = toBool(binary[x - 1, y + 1]);
                    z8 = toBool(binary[x - 1, y]);
                    z9 = toBool(binary[x - 1, y - 1]);

                    bool[] mas = { z2, z3, z4, z5, z6, z7, z8, z9 };

                    if (z1 == false)
                    {
                        int number = getNumber(mas);
                        if ((number == 208) || (number == 22) || (number == 97) || (number == 52) || (number == 13) || (number == 88) || (number == 67) || (number == 133) || (number == 5) || (number == 20) || (number == 80) || (number == 65))
                            binary[x, y] = 255;
                    }
                }
            }
            return binary;
        }

        private static Bitmap delBranches(Bitmap binaryImage)
        {
            Color red = Color.FromArgb(255, 0, 0);
            for (int x = 1; x < binaryImage.Width - 1; x++)
            {
                for (int y = 1; y < binaryImage.Height - 1; y++)
                {
                    //Для каждого найденного красного пикселя (окончание линии)
                    if (binaryImage.GetPixel(x, y) == red)
                    {
                        findPath(x, y, binaryImage);
                    }
                }
            }
            return binaryImage;
        }

        private static Bitmap findPath(int redX, int redY, Bitmap binaryImage)
        {
            Color z2, z3, z4, z5, z6, z7, z8, z9;
            List<Coordinates> coord = new List<Coordinates>();
            coord.Add(new Coordinates(redX, redY)); //Запомнить координаты текущего пикселя

            Color white = Color.FromArgb(255, 255, 255);
            Color black = Color.FromArgb(0, 0, 0);
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            Color blue = Color.FromArgb(0, 0, 255);
            int count = 10;
            int x = redX;
            int y = redY;
            while (count > 0)
            {
                binaryImage.SetPixel(x, y, blue); //помечаем текущий пиксель голубым

                System.Diagnostics.Debug.WriteLine(x + " " + y);
                bool isBlack = false;

                z2 = binaryImage.GetPixel(x, y - 1);
                z3 = binaryImage.GetPixel(x + 1, y - 1);
                z4 = binaryImage.GetPixel(x + 1, y);
                z5 = binaryImage.GetPixel(x + 1, y + 1);
                z6 = binaryImage.GetPixel(x, y + 1);
                z7 = binaryImage.GetPixel(x - 1, y + 1);
                z8 = binaryImage.GetPixel(x - 1, y);
                z9 = binaryImage.GetPixel(x - 1, y - 1);
                Color[] mas = { z2, z3, z4, z5, z6, z7, z8, z9 };

                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] == green)
                    {
                        if (i == 0)
                        {
                            y = y - 1;
                        }
                        if (i == 1)
                        {
                            x = x + 1;
                            y = y - 1;
                        }
                        if (i == 2)
                        {
                            x = x + 1;
                        }
                        if (i == 3)
                        {
                            x = x + 1;
                            y = y + 1;
                        }
                        if (i == 4)
                        {
                            y = y + 1;
                        }
                        if (i == 5)
                        {
                            x = x - 1;
                            y = y + 1;
                        }
                        if (i == 6)
                        {
                            x = x - 1;
                        }
                        if (i == 7)
                        {
                            x = x - 1;
                            y = y - 1;
                        }
                        coord.Add(new Coordinates(x, y));
                        binaryImage = delPath(coord, binaryImage);
                        return binaryImage;
                    }
                }

                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] == red)
                    {
                        if (i == 0)
                        {
                            y = y - 1;
                        }
                        if (i == 1)
                        {
                            x = x + 1;
                            y = y - 1;
                        }
                        if (i == 2)
                        {
                            x = x + 1;
                        }
                        if (i == 3)
                        {
                            x = x + 1;
                            y = y + 1;
                        }
                        if (i == 4)
                        {
                            y = y + 1;
                        }
                        if (i == 5)
                        {
                            x = x - 1;
                            y = y + 1;
                        }
                        if (i == 6)
                        {
                            x = x - 1;
                        }
                        if (i == 7)
                        {
                            x = x - 1;
                            y = y - 1;
                        }
                        coord.Add(new Coordinates(x, y));
                        binaryImage = delPath(coord, binaryImage);
                        return binaryImage;
                    }
                }


                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] == black)
                    {
                        isBlack = true;
                        if (i == 0)
                        {
                            y = y - 1;
                        }
                        if (i == 1)
                        {
                            x = x + 1;
                            y = y - 1;
                        }
                        if (i == 2)
                        {
                            x = x + 1;
                        }
                        if (i == 3)
                        {
                            x = x + 1;
                            y = y + 1;
                        }
                        if (i == 4)
                        {
                            y = y + 1;
                        }
                        if (i == 5)
                        {
                            x = x - 1;
                            y = y + 1;
                        }
                        if (i == 6)
                        {
                            x = x - 1;
                        }
                        if (i == 7)
                        {
                            x = x - 1;
                            y = y - 1;
                        }
                        coord.Add(new Coordinates(x, y));
                        break;
                    }
                }
                if (!isBlack) { binaryImage = delPath(coord, binaryImage); }
                count--;
            }
            return binaryImage;
        }

        private static Bitmap delPath(List<Coordinates> coord, Bitmap binaryImage)
        {
            Color white = Color.FromArgb(255, 255, 255);
            foreach (Coordinates c in coord)
            {
                binaryImage.SetPixel(c.getX(), c.getY(), white);
            }
            return binaryImage;
        }

        private static int getNumber(bool[] mas)
        {
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == false)
                {
                    count = count += pow(i);
                }
            }
            return count;
        }

        private static int pow(int var)
        {
            if (var == 0) return 1;
            if (var == 1) return 2;
            if (var == 2) return 4;
            if (var == 3) return 8;
            if (var == 4) return 16;
            if (var == 5) return 32;
            if (var == 6) return 64;
            if (var == 7) return 128;
            if (var == 8) return 256;
            if (var == 9) return 512;
            return -1;
        }

        public class Coordinates
        {
            private int x;
            private int y;
            public Coordinates(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int getX()
            {
                return x;
            }
            public int getY()
            {
                return y;
            }
        }

        public static Bitmap drawImage(double[,] array)
        {
            Bitmap image = new Bitmap(width, height);
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

        private static double calcRatio(double[,] image)
        {
            double maxVal = 0;

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    if (image[x, y] > maxVal)
                    {
                        maxVal = image[x, y];
                    }
                }
            }

            return maxVal / 255.0;
        }
    }
}
