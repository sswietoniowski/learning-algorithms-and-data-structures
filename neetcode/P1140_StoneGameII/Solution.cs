namespace neetcode.P1140_StoneGameII;

// https://leetcode.com/problems/stone-game-ii/description/
// https://neetcode.io/problems/stone-game-ii/question?list=neetcode250
public class Solution
{
    private int[][] memo;
    private int[] suffixSum;
    private int n;

    public int StoneGameII(int[] piles)
    {
        n = piles.Length;
        // memo[i][m] stores the max stones the current player can get
        // starting at index 'i' with the current multiplier 'M'.
        // We use n + 1 for M because M can technically grow up to n.
        memo = new int[n][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[n + 1];
        }

        // suffixSum[i] = total stones from piles[i] to piles[n-1].
        suffixSum = new int[n];
        suffixSum[n - 1] = piles[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffixSum[i] = suffixSum[i + 1] + piles[i];
        }

        return Solve(0, 1);
    }

    private int Solve(int i, int M)
    {
        // Base Case: If the player can take all remaining piles in one go.
        if (i + 2 * M >= n)
        {
            return suffixSum[i];
        }

        // Return cached value if we have already solved this state.
        if (memo[i][M] != 0)
        {
            return memo[i][M];
        }

        int maxStones = 0;

        // Try taking X piles, where 1 <= X <= 2M.
        for (int X = 1; X <= 2 * M; X++)
        {
            // The value for Alice (or the current player) is:
            // (Total stones remaining) - (Max stones the NEXT player can get).
            int opponentScore = Solve(i + X, Math.Max(M, X));
            int currentScore = suffixSum[i] - opponentScore;

            maxStones = Math.Max(maxStones, currentScore);
        }

        memo[i][M] = maxStones;
        return maxStones;
    }
}
