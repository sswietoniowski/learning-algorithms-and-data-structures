namespace leetcode.P1404_NumberOfSteps;

// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/description/?envType=daily-question&envId=2026-02-26
public class Solution
{
    public int NumSteps(string s)
    {
        int steps = 0;
        int carry = 0;

        for (int i = s.Length - 1; i > 0; i--)
        {
            if ((s[i] - '0') + carry == 1)
            {
                steps += 2;
                carry = 1;
            }
            else
            {
                steps += 1;
            }
        }

        return steps + carry;
    }
}
