using System.Text;

namespace leetcode.P0067_AddBinary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            StringBuilder sb = new();

            int minLength = Math.Min(a.Length, b.Length);
            int maxLength = Math.Max(a.Length, b.Length);

            if (a.Length < b.Length)
            {
                a = new string('0', maxLength - minLength) + a;
            }
            else
            {
                b = new string('0', maxLength - minLength) + b;
            }

            bool carry = false;

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int count = (carry ? 1 : 0)
                            + (a[i] == '1' ? 1 : 0)
                            + (b[i] == '1' ? 1 : 0);

                carry = false;
                char digit = '0';
                if (count == 3)
                {
                    carry = true;
                    digit = '1';
                }
                else if (count == 2)
                {
                    digit = '0';
                    carry = true;
                }
                else if (count == 1)
                {
                    digit = '1';
                }
                sb.Insert(0, digit);
            }

            if (carry)
            {
                sb.Insert(0, '1');
            }

            return sb.ToString();
        }
    }
}
