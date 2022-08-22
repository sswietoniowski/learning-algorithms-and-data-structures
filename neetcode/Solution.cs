namespace neetcode
{
    public class Solution
    {
        // https://leetcode.com/problems/contains-duplicate/
        // https://youtu.be/3OamzN90kPg
        public bool ContainsDuplicate(int[] nums)
        {
            // v1
            //bool result = false;

            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] == nums[j])
            //        {
            //            result = true;
            //            break;
            //        }
            //    }

            //    if (result)
            //    {
            //        break;
            //    }
            //}

            //return result;

            // v2
            //var numsSet = new HashSet<int>();

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (numsSet.Contains(nums[i]))
            //    {
            //        return true;
            //    }

            //    numsSet.Add(nums[i]);
            //}

            //return false;

            // v3
            //var numsDict = new Dictionary<int, int>();

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var exists = !numsDict.TryAdd(nums[i], 1);
            //    if (exists)
            //    {
            //        return true;
            //    }
            //}

            //return false;

            // v4
            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    return true;
                }
            }

            return false;
        }


        // https://leetcode.com/problems/group-anagrams/
        // https://youtu.be/vzdNOK2oB2E
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var wordsSet = new HashSet<string>();
            var anagramsDictionary = new Dictionary<string, IList<string>>();

            foreach (var word in strs)
            {
                char[] chars = word.ToCharArray();
                Array.Sort(chars);
                var key = new String(chars);
                if (!wordsSet.Contains(key))
                {
                    wordsSet.Add(key);
                    anagramsDictionary[key] = new List<string>();
                }

                anagramsDictionary[key].Add(word);
            }

            foreach (var kvp in anagramsDictionary)
            {
                result.Add(kvp.Value);
            }

            return result;
        }
    }
}
