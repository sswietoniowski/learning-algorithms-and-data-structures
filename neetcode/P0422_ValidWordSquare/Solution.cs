namespace neetcode.P0422_ValidWordSquare;

// https://leetcode.com/problems/valid-word-square
// https://neetcode.io/problems/valid-word-square/question
public class Solution
{
    public bool ValidWordSquare(IList<string> words)
    {
        for (int wordNum = 0; wordNum < words.Count; wordNum++)
        {
            for (int charPos = 0; charPos < words[wordNum].Length; charPos++)
            {
                if (
                    charPos >= words.Count
                    || wordNum >= words[charPos].Length
                    || words[wordNum][charPos] != words[charPos][wordNum]
                )
                {
                    return false;
                }
            }
        }
        return true;
    }
}
