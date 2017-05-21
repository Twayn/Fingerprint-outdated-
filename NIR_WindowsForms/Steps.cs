using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace NIR_WindowsForms
{
    public class Steps {
        private static Bitmap[] images = new Bitmap[50];

        private static int areaGrad = 15;
        private static int areaDencity = 24;

        public static void setAreaGrad(int area) {
            areaGrad = area;
        }

        public static void setAreaDencity(int area) {
            areaDencity = area;
        }

        private static Bitmap choose(int num) {
            switch (num) {
                case 0://Gradient module at point
                    UtilityFunctions.pointGrad();
                    return UtilityFunctions.pModule();
                case 1://Gradient direction at point
                    return UtilityFunctions.pDirection();
                case 2://Gradient module at area
                    UtilityFunctions.areaGrad(areaGrad);
                    return UtilityFunctions.aModule();
                case 3://Gradient direction at point
                    return UtilityFunctions.aDirection();
                case 4://Direction at field
                    return UtilityFunctions.directionField();
                case 5://Coherence
                    return UtilityFunctions.aCoh();
                case 6:
                    //UtilityFunctions.minMaxCoh();
                    //return UtilityFunctions.aCohMin();
                    return new Bitmap(10, 10);
                case 7:
                    //return UtilityFunctions.aCohMax();
                    return new Bitmap(10, 10);
                case 8://Ridge dencity at point
                    UtilityFunctions.ridgeDensity(areaDencity);
                    return UtilityFunctions.pDencity();
                case 9://RidgeDencity at area (average dencity)
                    UtilityFunctions.areaRidgeDencity(5);
                    return UtilityFunctions.aDencity();
                case 10://Veronica's hair
                    return UtilityFunctions.qualityDenc();
                case 11:
                    UtilityFunctions.areaQualityDenc(3);
                    return UtilityFunctions.aQualityDenc();
                case 12:
                    UtilityFunctions.veronicaBlur();
                    return UtilityFunctions.hairVeronicaBlur();
                case 13:
                    UtilityFunctions.complexQ();
                    return UtilityFunctions.complexQuality();
                case 14:
                    return UtilityFunctions.aErrosia();
                case 15:
                    UtilityFunctions.gaborV2(7);
                    return UtilityFunctions.aGaborBlur();
                case 16:
                    UtilityFunctions.gaborV2Plus(13);
                    return UtilityFunctions.aGaborDiff();
                case 17:
                    UtilityFunctions.complexQ();
                    return UtilityFunctions.complexQuality();

                default:
                    return new Bitmap(10, 10);
            }
        }

        public static Bitmap step(int st) {
            if (st > 0) { step(st - 1); }
            if (images[st] == null) {
                images[st] = choose(st);
                return images[st];
            }
            else {
                return images[st];
            }
        }

        public static void clear() {
            images = new Bitmap[50];
        }
    }
}
