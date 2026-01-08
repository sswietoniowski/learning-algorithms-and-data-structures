namespace neetcode.P0929_UniqueEmailAddresses;

// https://leetcode.com/problems/unique-email-addresses/description/
// https://neetcode.io/problems/unique-email-addresses/question
public class Solution
{
    public int NumUniqueEmails(string[] emails)
    {
        var uniqueEmails = new HashSet<string>();
        var sb = new StringBuilder();

        foreach (string email in emails)
        {
            sb.Clear();
            int atIndex = email.IndexOf('@');

            for (int i = 0; i < atIndex; i++)
            {
                char c = email[i];
                if (c == '+')
                    break;
                if (c == '.')
                    continue;
                sb.Append(c);
            }

            sb.Append(email.AsSpan(atIndex));

            uniqueEmails.Add(sb.ToString());
        }

        return uniqueEmails.Count;
    }
}
