namespace leetcode.P1784_CheckIfBinaryString;

// https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/description/?envType=daily-question&envId=2026-03-06
public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        return !s.Contains("01");
    }
}
