namespace neetcode.P0121_BestTimeToBuyAndSellStock
{
    public class Solution
    {
        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        // https://youtu.be/1pkOgXD63yU
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int buyDay = 0;
            int sellDay = 1;

            while (sellDay < prices.Length)
            {
                if (prices[buyDay] >= prices[sellDay])
                {
                    buyDay = sellDay;
                    sellDay = buyDay + 1;
                }
                else
                {
                    if (prices[sellDay] - prices[buyDay] > maxProfit)
                    {
                        maxProfit = prices[sellDay] - prices[buyDay];
                    }

                    sellDay = sellDay + 1;
                }
            }

            return maxProfit;
        }
    }
}
