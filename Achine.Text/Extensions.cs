using System;

namespace Achine.Text {
    public static class Extensions {

        public static int ToInt(object arg, int defValue) {
            int.TryParse(arg.ToString(), out defValue);
            return defValue;
        }

        public static short ToInt16(object arg, short defValue) {
            short.TryParse(arg.ToString(), out defValue);
            return defValue;
        }

        public static int ToInt32(object arg, int defValue) {
            int.TryParse(arg.ToString(), out defValue);
            return defValue;
        }

        public static long ToInt64(object arg, long defValue) {
            long.TryParse(arg.ToString(), out defValue);
            return defValue;
        }

        public static float ToFloat(object arg, float defValue) {
            float.TryParse(arg.ToString(), out defValue);
            return defValue;
        }

        public static double ToDouble(object arg, double defValue) {
            double.TryParse(arg.ToString(), out defValue);
            return defValue;
        }
    }
}
