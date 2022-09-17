namespace neetcode.P0739_DailyTemperatures
{
    // https://leetcode.com/problems/daily-temperatures/
    // https://youtu.be/cTBiBSnjO3c
    public class Solution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];

            for (int i = 0; i < temperatures.Length; i++)
            {
                int j = i + 1;
                while (j < temperatures.Length)
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        result[i] = j - i;
                        break;
                    }
                    j++;
                }
            }

            return result;
        }
    }
}
