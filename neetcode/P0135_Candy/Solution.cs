namespace neetcode.P0135_Candy;

// https://leetcode.com/problems/candy/description/
// https://neetcode.io/problems/candy/question?list=neetcode250
public class Solution
{
    public int Candy(int[] ratings)
    {
        int n = ratings.Length;
        if (n <= 1)
            return n;

        int[] candies = new int[n];

        // Step 1: Every child must have at least one candy.
        for (int i = 0; i < n; i++)
        {
            candies[i] = 1;
        }

        // Step 2: Left-to-Right Pass
        // Ensure children with higher ratings than their left neighbor get more.
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                candies[i] = candies[i - 1] + 1;
            }
        }

        // Step 3: Right-to-Left Pass
        // Ensure children with higher ratings than their right neighbor get more.
        // We use Math.Max to ensure we don't break the Left-to-Right requirement.
        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        // Step 4: Sum up the total candies.
        int totalCandies = 0;
        foreach (int candy in candies)
        {
            totalCandies += candy;
        }

        return totalCandies;
    }
}
