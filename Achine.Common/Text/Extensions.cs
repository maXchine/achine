namespace Achine.Common.Text {
    public static class Extensions {

        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        }

        public static bool NonEmpty(this string s)
        {
            return !s.IsEmpty();
        }
    }
}
