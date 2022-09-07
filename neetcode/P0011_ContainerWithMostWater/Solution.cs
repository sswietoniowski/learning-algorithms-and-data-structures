namespace neetcode.P0011_ContainerWithMostWater
{
    // https://leetcode.com/problems/container-with-most-water/
    // https://youtu.be/UuiTKBwPgAo
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int area = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                area = Math.Max(area, Math.Min(height[left], height[right]) * (right - left));

                if (height[left] < height[right])
                {
                    left++;
                }
                else if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return area;
        }
    }
}
