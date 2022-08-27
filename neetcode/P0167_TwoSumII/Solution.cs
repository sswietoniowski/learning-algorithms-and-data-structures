namespace neetcode.P0167_TwoSumII
{
    public class Solution
    {
        // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        // https://youtu.be/cQ1Oz4ckceM
        public int[] TwoSumII(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;

            while (true)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    return new int[] { i + 1, j + 1 };
                }
                else if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
        }
    }
}
