namespace neetcode.P0739_DailyTemperatures
{
    // https://leetcode.com/problems/daily-temperatures/
    // https://youtu.be/cTBiBSnjO3c
    public class Solution
    {
        // v1
        //public int[] DailyTemperatures(int[] temperatures)
        //{
        //    int[] result = new int[temperatures.Length];

        //    for (int i = 0; i < temperatures.Length; i++)
        //    {
        //        int j = i + 1;
        //        while (j < temperatures.Length)
        //        {
        //            if (temperatures[j] > temperatures[i])
        //            {
        //                result[i] = j - i;
        //                break;
        //            }
        //            j++;
        //        }
        //    }

        //    return result;
        //}

        // v2
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];

            Stack<int> stack = new();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int index = stack.Pop();
                    result[index] = i - index;
                }

                stack.Push(i);
            }

            return result;
        }
    }
}
