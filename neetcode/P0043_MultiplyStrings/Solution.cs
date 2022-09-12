using System.Text;

namespace neetcode.P0043_MultiplyStrings
{
    // https://leetcode.com/problems/multiply-strings/
    // https://youtu.be/1vZswirL8Y8
    public class Solution
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            var result = new int[num1.Length + num2.Length];

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    var mul = (num1[i] - '0') * (num2[j] - '0');
                    var p1 = i + j;
                    var p2 = i + j + 1;
                    var sum = mul + result[p2];

                    result[p1] += sum / 10;
                    result[p2] = sum % 10;
                }
            }

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                if (!(sb.Length == 0 && item == 0))
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}
