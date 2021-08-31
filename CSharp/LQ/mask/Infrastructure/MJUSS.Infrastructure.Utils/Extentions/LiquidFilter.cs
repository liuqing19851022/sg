namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class LiquidFilter
    {
        public static string Money(object input, long precision = 1)
        {
            return input.ToString().ToDecimal().ToRounding((int)precision).ToAutoRemoveZeroString();

        }

        public static string Discount(object input)
        {
            return input.ToString().ToDecimal().ToDiscountString();
        }

        public static decimal ToDecimal(string input,decimal def = 0) {
            return input.ToDecimal(def);
        }

        public static decimal ToInt(string input, int def = 0) {
            return input.ToInt(def);
        }

        public static string TimeLength(object min) {
            return min.ToString().ToInt().ToHourMinutes();
        }
    }
}
