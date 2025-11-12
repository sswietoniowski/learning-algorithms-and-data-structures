namespace neetcode.P0084._LargestRectangleInHistogram;

// https://leetcode.com/problems/largest-rectangle-in-histogram/description/
// https://neetcode.io/problems/largest-rectangle-in-histogram?list=neetcode150
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        int maxArea = 0;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i <= n; i++)
        {
            while (stack.Count > 0 && (i == n || heights[stack.Peek()] >= heights[i]))
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }
        return maxArea;
    }
}
