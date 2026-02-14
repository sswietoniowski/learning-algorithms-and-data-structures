namespace leetcode.P0799_ChampagneTower;

// https://leetcode.com/problems/champagne-tower/description/?envType=daily-question&envId=2026-02-14
public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        double[,] tower = new double[102, 102];

        tower[0, 0] = (double)poured;

        for (int r = 0; r <= query_row; r++)
        {
            for (int c = 0; c <= r; c++)
            {
                double quantity = tower[r, c];
                if (quantity > 1.0)
                {
                    double excess = quantity - 1.0;
                    double halfExcess = excess / 2.0;
                    tower[r + 1, c] += halfExcess;
                    tower[r + 1, c + 1] += halfExcess;
                }
            }
        }

        return Math.Min(1.0, tower[query_row, query_glass]);
    }
}
