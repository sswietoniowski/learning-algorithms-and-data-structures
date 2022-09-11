namespace neetcode.P0050_Pow
{
    // https://leetcode.com/problems/powx-n/
    // https://youtu.be/g9YQyYi4IQQ
    public class Solution
    {
        private double Pow(double x, int n)
        {
            if (x == 0) return 0;
            if (n == 0) return 1;

            double result = Pow(x * x, n / 2);

            return result * (n % 2 == 0 ? 1 : x);
        }

        public double MyPow(double x, int n)
        {
            return (n >= 0) ? Pow(x, n) : 1 / Pow(x, -n);
        }
    }
}
