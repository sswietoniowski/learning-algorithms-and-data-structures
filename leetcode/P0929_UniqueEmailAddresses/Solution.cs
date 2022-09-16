using System.Text;

namespace leetcode.P0929_UniqueEmailAddresses;

public class Solution
{
    // https://leetcode.com/explore/interview/card/google/67/sql-2/3044/
    public int NumUniqueEmails(string[] emails)
    {
        var uniqueEmails = new HashSet<string>();

        foreach (var email in emails)
        {
            string[] parts = email.Split('@');
            string username = parts[0];
            string domain = parts[1];
            int plusPosition = username.IndexOf('+');
            if (plusPosition > 0)
            {
                username = username.Substring(0, plusPosition);
            }

            string rest = username;
            int dotPosition = rest.IndexOf('.');
            StringBuilder sb = new();
            while (dotPosition > 0)
            {
                sb.Append(rest.Substring(0, dotPosition));
                if (dotPosition < rest.Length - 1)
                {
                    rest = rest.Substring(dotPosition + 1, rest.Length - dotPosition - 1);
                }

                dotPosition = rest.IndexOf('.');
            }

            if (rest.Length > 0)
            {
                sb.Append(rest);
            }

            username = sb.ToString();
            uniqueEmails.Add($"{username}@{domain}");
        }

        return uniqueEmails.Count;
    }
}