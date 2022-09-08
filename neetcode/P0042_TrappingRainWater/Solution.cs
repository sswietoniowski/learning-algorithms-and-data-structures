namespace neetcode.P0042_TrappingRainWater
{
    // https://leetcode.com/problems/trapping-rain-water/
    // https://youtu.be/ZI2z5pq0TqA
    public class Solution
    {
        // v1 Time Complexity O(n), Space Complexity O(n)
        //public int Trap(int[] height)
        //{
        //    int[] leftMax = new int[height.Length];
        //    int[] rightMax = new int[height.Length];

        //    int max = 0;
        //    leftMax[0] = 0;
        //    for (int i = 1; i < height.Length; i++)
        //    {
        //        if (height[i - 1] > max)
        //        {
        //            max = height[i - 1];
        //        }
        //        leftMax[i] = max;
        //    }

        //    max = 0;
        //    rightMax[height.Length - 1] = 0;
        //    for (int i = height.Length - 2; i >= 0; i--)
        //    {
        //        if (height[i + 1] > max)
        //        {
        //            max = height[i + 1];
        //        }
        //        rightMax[i] = max;
        //    }

        //    int water = 0;

        //    for (int i = 0; i < height.Length; i++)
        //    {
        //        int amount = Math.Min(leftMax[i], rightMax[i]) - height[i];
        //        water += amount > 0 ? amount : 0;
        //    }

        //    return water;
        //}

        // v2 Time Complexity O(n), Space Complexity O(1)
        public int Trap(int[] height)
        {
            if (height.Length == 0)
            {
                return 0;
            }

            int left = 0;
            int right = height.Length - 1;
            int maxLeft = height[left];
            int maxRight = height[right];

            int water = 0;

            while (left < right)
            {
                if (maxLeft < maxRight)
                {
                    left++;
                    maxLeft = Math.Max(maxLeft, height[left]);
                    water += maxLeft - height[left];
                }
                else
                {
                    right--;
                    maxRight = Math.Max(maxRight, height[right]);
                    water += maxRight - height[right];
                }
            }
            
            return water;
        }

    }
}
