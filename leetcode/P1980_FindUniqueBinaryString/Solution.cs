using System.Text;

namespace leetcode.P1980_FindUniqueBinaryString;

// https://leetcode.com/problems/find-unique-binary-string/description/?envType=daily-question&envId=2026-03-08
public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        StringBuilder result = new StringBuilder();
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            // Get the i-th character of the i-th string
            char currentBit = nums[i][i];

            // Flip it: if it's '0', add '1'; if it's '1', add '0'
            result.Append(currentBit == '0' ? '1' : '0');
        }

        return result.ToString();
    }
}
