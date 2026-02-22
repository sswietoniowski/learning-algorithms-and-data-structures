namespace leetcode.P0868_BinaryGap;

// https://leetcode.com/problems/binary-gap/description/?envType=daily-question&envId=2026-02-22
public class Solution
{
    public int BinaryGap(int n)
    {
        int maxDistance = 0;
        int lastPos = -1;
        int currentPos = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                if (lastPos != -1)
                {
                    maxDistance = Math.Max(maxDistance, currentPos - lastPos);
                }
                lastPos = currentPos;
            }

            n >>= 1;
            currentPos++;
        }

        return maxDistance;
    }
}
