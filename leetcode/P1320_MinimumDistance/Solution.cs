namespace leetcode.P1320_MinimumDistance;

// https://leetcode.com/problems/minimum-distance-to-type-a-word-using-two-fingers/description/?envType=daily-question&envId=2026-04-12
public class Solution
{
    private int?[,] memo;
    private string word;

    public int MinimumDistance(string word)
    {
        this.word = word;
        // memo[wordIndex][otherFingerPosition]
        // otherFingerPosition 0-25 are A-Z, 26 represents "not yet placed"
        memo = new int?[word.Length, 27];

        // Start at index 0. Since the first move is always free,
        // we can treat it as moving Finger 1 from a "free" state (26).
        return GetMinDist(0, 26);
    }

    private int GetMinDist(int idx, int otherFinger)
    {
        // Base case: all letters typed
        if (idx == word.Length)
            return 0;

        if (memo[idx, otherFinger] != null)
            return memo[idx, otherFinger].Value;

        int currLetter = word[idx] - 'A';

        // At index 0, there is no "previous" letter.
        // We initialize the first finger's movement as 0 cost.
        int prevLetter = (idx == 0) ? 26 : word[idx - 1] - 'A';

        // Option 1: Move the finger that typed the previous letter (or Finger 1 if idx=0)
        int cost1 = GetDistance(prevLetter, currLetter) + GetMinDist(idx + 1, otherFinger);

        // Option 2: Move the "other" finger (Finger 2)
        int cost2 = GetDistance(otherFinger, currLetter) + GetMinDist(idx + 1, prevLetter);

        return (int)(memo[idx, otherFinger] = Math.Min(cost1, cost2));
    }

    private int GetDistance(int pos1, int pos2)
    {
        // If either finger is not yet placed, distance is free (0)
        if (pos1 == 26 || pos2 == 26)
            return 0;

        int x1 = pos1 / 6,
            y1 = pos1 % 6;
        int x2 = pos2 / 6,
            y2 = pos2 % 6;

        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}
