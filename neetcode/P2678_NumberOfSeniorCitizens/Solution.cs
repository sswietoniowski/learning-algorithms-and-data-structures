namespace neetcode.P2678_NumberOfSeniorCitizens;

// https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/description/
// https://neetcode.io/problems/append-characters-to-string-to-make-subsequence/question?list=allNC
public class Solution
{
    public int CountSeniors(string[] details)
    {
        var seniorCount = 0;
        foreach (string entry in details)
        {
            ReadOnlySpan<char> ageSpan = entry.AsSpan(11, 2);
            int age = (entry[11] - '0') * 10 + (entry[12] - '0');
            if (age > 60)
            {
                seniorCount++;
            }
        }
        return seniorCount;
    }
}
