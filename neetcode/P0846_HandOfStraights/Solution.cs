namespace neetcode.P0846_HandOfStraights;

// https://leetcode.com/problems/hand-of-straights/description/
// https://neetcode.io/problems/hand-of-straights/question?list=neetcode150
public class Solution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;

        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in hand)
        {
            if (!count.ContainsKey(num))
                count[num] = 0;
            count[num]++;
        }

        foreach (int num in hand)
        {
            int start = num;
            while (count.ContainsKey(start - 1) && count[start - 1] > 0)
            {
                start--;
            }
            while (start <= num)
            {
                while (count.ContainsKey(start) && count[start] > 0)
                {
                    for (int i = start; i < start + groupSize; i++)
                    {
                        if (!count.ContainsKey(i) || count[i] == 0)
                        {
                            return false;
                        }
                        count[i]--;
                    }
                }
                start++;
            }
        }
        return true;
    }
}
