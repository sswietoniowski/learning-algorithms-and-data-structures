using System.Text;

namespace neetcode.P1405_LongestHappyString;

// https://leetcode.com/problems/longest-happy-string/description/
// https://neetcode.io/problems/longest-happy-string/question
public class Solution
{
    public string LongestDiverseString(int a, int b, int c)
    {
        StringBuilder res = new StringBuilder();

        // Store counts and their respective characters in a list for easy sorting
        var counts = new List<(int count, char ch)> { (a, 'a'), (b, 'b'), (c, 'c') };

        while (true)
        {
            // 1. Sort by count descending so we always try the largest first
            counts.Sort((x, y) => y.count.CompareTo(x.count));

            bool added = false;

            for (int i = 0; i < 3; i++)
            {
                // If count is 0, we can't use this letter or any letter after it (since it's sorted)
                if (counts[i].count <= 0)
                    break;

                int n = res.Length;
                // 2. Check the "No Triple" rule:
                // If the last two characters in the string are the same as our current choice...
                if (n >= 2 && res[n - 1] == counts[i].ch && res[n - 2] == counts[i].ch)
                {
                    // ...we skip this character and try the next most frequent one.
                    continue;
                }

                // 3. If we pass the check, append the character and decrement the count
                res.Append(counts[i].ch);
                counts[i] = (counts[i].count - 1, counts[i].ch);
                added = true;
                break;
            }

            // 4. If we couldn't add any character in this pass, we are finished.
            if (!added)
                break;
        }

        return res.ToString();
    }
}
