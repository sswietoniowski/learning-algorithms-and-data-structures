using System.Text;

namespace leetcode
{
    public class Solution
    {
        // https://leetcode.com/problems/longest-common-prefix/
        public string LongestCommonPrefix(string[] strs)
        {
            int n = strs.Length;

            if (n == 1)
            {
                return strs[0];
            }

            int maxLength = 200;
            foreach (var str in strs)
            {
                if (maxLength > str.Length)
                {
                    maxLength = str.Length;
                }
            }

            if (maxLength == 0)
            {
                return "";
            }

            StringBuilder sb = new();
            for (int i = 0; i < maxLength; i++)
            {
                char current = strs[0][i];
                bool isCommon = true;

                for (int j = 1; j < n; j++)
                {
                    if (strs[j][i] != current)
                    {
                        isCommon = false;
                        break;
                    }
                }

                if (!isCommon)
                {
                    break;
                }

                sb.Append(strs[0][i]);
            }

            return sb.ToString();
        }

        // https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        public int RemoveDuplicates(int[] nums)
        {
            int k = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[k] != nums[i])
                {
                    k++;
                    nums[k] = nums[i];
                }
            }
            return k + 1;
        }
    }
}
