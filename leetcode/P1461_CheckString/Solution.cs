namespace leetcode.P1461_CheckString;

// https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/description/?envType=daily-question&envId=2026-02-23
public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        int totalRequired = 1 << k;
        if (s.Length < k + totalRequired - 1)
            return false;

        bool[] seen = new bool[totalRequired];
        int count = 0;
        int currentHash = 0;

        int mask = totalRequired - 1;

        for (int i = 0; i < s.Length; i++)
        {
            currentHash = ((currentHash << 1) | (s[i] - '0')) & mask;

            if (i >= k - 1)
            {
                if (!seen[currentHash])
                {
                    seen[currentHash] = true;
                    count++;

                    if (count == totalRequired)
                        return true;
                }
            }
        }

        return false;
    }
}
