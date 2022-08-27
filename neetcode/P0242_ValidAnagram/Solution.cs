namespace neetcode.P0242_ValidAnagram
{
    public class Solution
    {
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
    }
}
