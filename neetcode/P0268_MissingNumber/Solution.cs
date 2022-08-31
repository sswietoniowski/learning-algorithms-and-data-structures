namespace neetcode.P0268_MissingNumber
{
    public class Solution
    {
        // https://leetcode.com/problems/missing-number/
        // https://youtu.be/WnPLSRLSANE
        public int MissingNumber(int[] nums)
        {
            // v1
            //_array.Sort(nums);
            //int number = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] != number)
            //    {
            //        return number;
            //    }
            //    number++;
            //}
            //return number;

            // v2
            int n = nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                n ^= i ^ nums[i];
            }

            return n;
        }
    }
}
