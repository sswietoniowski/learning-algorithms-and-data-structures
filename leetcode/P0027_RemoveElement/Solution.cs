namespace leetcode.P0027_RemoveElement
{
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1 && nums[0] == val)
            {
                return 0;
            }

            int i = -1;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == val)
                {
                    continue;
                }
                i++;
                nums[i] = nums[j];
            }
            return i + 1;
        }
    }
}
