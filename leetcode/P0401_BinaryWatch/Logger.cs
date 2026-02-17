namespace leetcode.P0401_BinaryWatch;

using System.Numerics;

// https://leetcode.com/problems/binary-watch/description/?envType=daily-question&envId=2026-02-17
public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        IList<string> result = new List<string>();

        for (int h = 0; h < 12; h++)
        {
            for (int m = 0; m < 60; m++)
            {
                if (BitOperations.PopCount((uint)h) + BitOperations.PopCount((uint)m) == turnedOn)
                {
                    result.Add($"{h}:{m:D2}");
                }
            }
        }

        return result;
    }
}
