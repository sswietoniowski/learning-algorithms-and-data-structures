namespace neetcode.P0309_BestTimeToBuyAndSellStockWithCooldown;

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
// https://neetcode.io/problems/buy-and-sell-crypto-with-cooldown/question?list=neetcode150
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        int dp1_buy = 0,
            dp1_sell = 0;
        int dp2_buy = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            int dp_buy = Math.Max(dp1_sell - prices[i], dp1_buy);
            int dp_sell = Math.Max(dp2_buy + prices[i], dp1_sell);
            dp2_buy = dp1_buy;
            dp1_buy = dp_buy;
            dp1_sell = dp_sell;
        }

        return dp1_buy;
    }
}
