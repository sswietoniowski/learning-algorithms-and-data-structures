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

        // https://leetcode.com/problems/valid-anagram/
        // https://youtu.be/9UtInBqnCgA
        public bool IsAnagram(string s, string t)
        {
            // v1
            //if (s.Length != t.Length)
            //{
            //    return false;
            //}

            //int[] counters = new int[26];

            //for (int i = 0; i < s.Length; i++)
            //{
            //    counters[s[i] - 'a']++;
            //    counters[t[i] - 'a']--;
            //}

            //foreach (int counter in counters)
            //{
            //    if (counter != 0)
            //    {
            //        return false;
            //    }
            //}

            //return true;

            // v2
            var sArr = s.ToCharArray();
            Array.Sort(sArr);
            var tArr = t.ToCharArray();
            Array.Sort(tArr);
            return new String(sArr) == new String(tArr);
        }

        // https://leetcode.com/problems/two-sum/
        // https://youtu.be/KLlXCFG5TnA
        public int[] TwoSum(int[] nums, int target)
        {
            // v1
            //int[] result = new int[2];
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            result[0] = i;
            //            result[1] = j;
            //            return result;
            //        }
            //    }
            //}
            //return result;

            // v2
            Dictionary<int, int> mapping = new();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (mapping.ContainsKey(complement))
                {
                    return new int[] { mapping[complement], i };
                }

                if (!mapping.ContainsKey(nums[i]))
                {
                    mapping.Add(nums[i], i);
                }
            }

            return null;
        }
    }
}
