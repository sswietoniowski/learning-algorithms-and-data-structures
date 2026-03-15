namespace neetcode.P0473_MatchsticksToSquare;

// https://leetcode.com/problems/matchsticks-to-square/description/
// https://neetcode.io/problems/matchsticks-to-square/question
public class Solution
{
    public bool Makesquare(int[] matchsticks)
    {
        if (matchsticks == null || matchsticks.Length < 4)
            return false;

        int totalSum = 0;
        foreach (int s in matchsticks)
            totalSum += s;

        // A square must have 4 equal integer sides
        if (totalSum % 4 != 0)
            return false;

        int target = totalSum / 4;

        // Sort descending to fail fast on large sticks
        Array.Sort(matchsticks);
        Array.Reverse(matchsticks);

        // If the largest stick is longer than the target side, it's impossible
        if (matchsticks[0] > target)
            return false;

        int[] sides = new int[4];
        return Backtrack(matchsticks, sides, 0, target);
    }

    private bool Backtrack(int[] matchsticks, int[] sides, int index, int target)
    {
        // Base case: All matchsticks have been placed
        if (index == matchsticks.Length)
        {
            return sides[0] == target && sides[1] == target && sides[2] == target;
        }

        int currentStick = matchsticks[index];

        for (int i = 0; i < 4; i++)
        {
            // Optimization: If adding this stick exceeds the target, try the next side
            if (sides[i] + currentStick <= target)
            {
                // Optimization: If this side length is the same as a previous side we already tried
                // for this stick in this loop, skip it to avoid redundant calculations.
                bool alreadyTried = false;
                for (int j = 0; j < i; j++)
                {
                    if (sides[j] == sides[i])
                    {
                        alreadyTried = true;
                        break;
                    }
                }
                if (alreadyTried)
                    continue;

                // Place the stick
                sides[i] += currentStick;

                // Move to the next stick
                if (Backtrack(matchsticks, sides, index + 1, target))
                    return true;

                // Backtrack: Remove the stick and try the next side
                sides[i] -= currentStick;
            }
        }

        return false;
    }
}
