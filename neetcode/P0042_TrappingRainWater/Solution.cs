namespace neetcode.P0042_TrappingRainWater
{
    // https://leetcode.com/problems/trapping-rain-water/
    // https://youtu.be/ZI2z5pq0TqA
    public class Solution
    {
        public int Trap(int[] height)
        {
            int[] leftMax = new int[height.Length];
            int[] rightMax = new int[height.Length];

            int max = 0;
            leftMax[0] = 0;
            for (int i = 1; i < height.Length; i++)
            {
                if (height[i - 1] > max)
                {
                    max = height[i - 1];
                }
                leftMax[i] = max;
            }

            max = 0;
            rightMax[height.Length - 1] = 0;
            for (int i = height.Length - 2; i >= 0; i--)
            {
                if (height[i + 1] > max)
                {
                    max = height[i + 1];
                }
                rightMax[i] = max;
            }

            int water = 0;

            int[] amounts = new int[height.Length];

            for (int i = 0; i < height.Length; i++)
            {
                int amount = Math.Min(leftMax[i], rightMax[i]) - height[i];
                amounts[i] = amount;
                water += amount > 0 ? amount : 0;
            }

            return water;
        }
    }
}
