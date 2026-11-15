namespace neetcode.P0953_VerifyingAnAlienDictionary;

public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        Dictionary<char, int> orderIndex = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++)
        {
            orderIndex[order[i]] = i;
        }

        for (int i = 0; i < words.Length - 1; i++)
        {
            string w1 = words[i];
            string w2 = words[i + 1];

            for (int j = 0; j < w1.Length; j++)
            {
                if (j == w2.Length)
                {
                    return false;
                }

                if (w1[j] != w2[j])
                {
                    if (orderIndex[w1[j]] > orderIndex[w2[j]])
                    {
                        return false;
                    }
                    break;
                }
            }
        }

        return true;
    }
}
