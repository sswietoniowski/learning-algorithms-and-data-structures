namespace neetcode.P0875_KokoEatingBananas
{
    // https://leetcode.com/problems/koko-eating-bananas/
    // https://youtu.be/U2SozAs9RzA
    public class Solution
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1;
            int right = int.MaxValue;

            while (left < right)
            {
                int k = left + (right - left) / 2;
                int hours = 0;

                for (int i = 0; i < piles.Length; i++)
                {
                    hours += piles[i] / k + (piles[i] % k != 0 ? 1 : 0);
                }

                if (hours > h)
                {
                    left = k + 1;
                }
                else
                {
                    right = k;
                }
            }
            return left;
        }
    }
}
