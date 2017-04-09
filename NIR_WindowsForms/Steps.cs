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

        private static Bitmap choose(int num) {
            switch (num) {
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
                case 4:
                    return UtilityFunctions.directionField();
                case 5:
                    return UtilityFunctions.aCoh();
                case 6:
                    //UtilityFunctions.minMaxCoh();
                    //return UtilityFunctions.aCohMin();
                    return new Bitmap(10, 10);
                case 7:
                    //return UtilityFunctions.aCohMax();
                    return new Bitmap(10, 10);
                case 8:
                    return UtilityFunctions.ridgeDensity();
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
