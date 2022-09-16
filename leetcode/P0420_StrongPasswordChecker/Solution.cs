namespace leetcode.P0420_StrongPasswordChecker;

// https://leetcode.com/problems/strong-password-checker/
public class Solution
{
    public int StrongPasswordChecker(string password)
    {
        int n = password.Length;
        List<int> groups = new();
        int lowerCaseCount = 0;
        int upperCaseCount = 0;
        int digitCount = 0;
        int count = 0;

        foreach (char c in password)
        {
            if (Char.IsLower(c))
            {
                lowerCaseCount = 1;
            }
            else if (Char.IsUpper(c))
            {
                upperCaseCount = 1;
            }
            else if (Char.IsDigit(c))
            {
                digitCount = 1;
            }
        }
        count = lowerCaseCount + upperCaseCount + digitCount;

        int l = 0;
        for (int i = 0; i <= n; i++)
        {
            if (i == n || password[i] != password[l])
            {
                groups.Add(i - l);
                l = i;
            }
        }

        int total = 0;
        if (n < 6)
        {
            while (n < 6 || count < 3 || groups.Max() >= 3)
            {
                bool found = false;

                for (int i = 0; i < groups.Count; i++)
                {
                    if (groups[i] >= 3)
                    {
                        groups[i] -= 2;
                        count++;
                        total++;
                        n++;
                        found = true;
                    }
                }

                if (!found)
                {
                    count++;
                    n++;
                    total++;
                }
            }
            return total;
        }
        else if (n >= 6 && n <= 20)
        {
            while (count < 3 || groups.Max() >= 3)
            {
                bool found = false;
                for (int i = 0; i < groups.Count; i++)
                {
                    if (groups[i] >= 3)
                    {
                        groups[i] -= 3;
                        count++;
                        total++;
                        found = true;
                    }
                }

                if (!found)
                {
                    count++;
                    total++;
                }
            }
        }
        else
        {
            for (int r = 0; r < 3; r++)
            {
                bool found = true;
                while (n > 20 && found)
                {
                    found = false;
                    for (int i = 0; i < groups.Count; i++)
                    {
                        if (groups[i] >= 3 && groups[i] % 3 == r && n > 20)
                        {
                            int operations = Math.Min(r + 1, n - 20);
                            groups[i] -= operations;
                            total += operations;
                            n -= operations;
                            found = true;
                        }
                    }
                }
            }

            if (n > 20)
            {
                total += n - 20;
                n = 20;
            }

            while (count < 3 || groups.Max() >= 3)
            {
                bool found = false;
                for (int i = 0; i < groups.Count; i++)
                {
                    if (groups[i] >= 3)
                    {
                        groups[i] -= 3;
                        count++;
                        total++;
                        found = true;
                    }
                }

                if (!found)
                {
                    count++;
                    total++;
                }
            }
        }
        return total;
    }
}