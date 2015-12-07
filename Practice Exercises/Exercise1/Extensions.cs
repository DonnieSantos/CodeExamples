namespace Exercise1
{
    public static class Extensions
    {
        public static bool isDivisibleBy(this int i, int number)
        {
            return i % number == 0;
        }
    }
}