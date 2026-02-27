namespace neetcode.P0076_MinimumWindowSubstring;

// https://leetcode.com/problems/minimum-window-substring/
// https://youtu.be/jSto0O4AJbM
public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
        {
            return string.Empty;
        }

        var countT = new Dictionary<char, int>();
        var window = new Dictionary<char, int>();

        foreach (var c in t)
        {
            if (countT.ContainsKey(c))
            {
                countT[c]++;
            }
            else
            {
                countT.Add(c, 1);
            }
        }

        var have = 0;
        var need = countT.Count;

        var result = new int[] { -1, -1 };
        var resultLength = int.MaxValue;

        var left = 0;

        for (int r = 0; r < s.Length; r++)
        {
            var c = s[r];
            if (countT.ContainsKey(c))
            {
                if (window.ContainsKey(c))
                {
                    window[c]++;
                }
                else
                {
                    window.Add(c, 1);
                }

                if (window[c] == countT[c])
                {
                    have++;
                }
            }

            while (have == need)
            {
                if (r - left + 1 < resultLength)
                {
                    result[0] = left;
                    result[1] = r;
                    resultLength = r - left + 1;
                }

                var cLeft = s[left];

                if (countT.ContainsKey(cLeft))
                {
                    window[cLeft]--;
                    if (window[cLeft] < countT[cLeft])
                    {
                        have--;
                    }
                }

                left++;
            }
        }

        return result[0] == -1 ? string.Empty : s.Substring(result[0], result[1] - result[0] + 1);
    }
}
