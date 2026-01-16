namespace neetcode.P0496_NextGreaterElementI;

// https://leetcode.com/problems/next-greater-element-i/description/
// https://neetcode.io/problems/next-greater-element-i/question
// v1
/*
public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] output = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            int j = 0;
            int value = -1;
            for (j = 0; j < nums2.Length; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    break;
                }
            }

            while (j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    value = nums2[j];
                    break;
                }
                j++;
            }

            output[i] = value;
        }

        return output;
    }
}
*/
// v2
public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> nextGreaterMap = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();

        foreach (int num in nums2)
        {
            while (stack.Count > 0 && num > stack.Peek())
            {
                nextGreaterMap[stack.Pop()] = num;
            }
            stack.Push(num);
        }

        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = nextGreaterMap.GetValueOrDefault(nums1[i], -1);
        }

        return result;
    }
}
