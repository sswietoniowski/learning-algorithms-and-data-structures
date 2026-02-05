namespace leetcode.P2299_StrongPasswordCheckerII;

// https://leetcode.com/problems/strong-password-checker-ii/
public class Solution
{
    public bool StrongPasswordCheckerII(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }
        bool hasLowerCase = false;
        bool hasUpperCase = false;
        bool hasDigit = false;
        string specialCharacters = "!@#$%^&*()-+";
        bool hasSpecialCharacter = false;

        for (int i = 0; i < password.Length; i++)
        {
            if (Char.IsLower(password[i]))
            {
                hasLowerCase = true;
            }
            else if (Char.IsUpper(password[i]))
            {
                hasUpperCase = true;
            }
            else if (Char.IsDigit(password[i]))
            {
                hasDigit = true;
            }
            else if (specialCharacters.Contains(password[i]))
            {
                hasSpecialCharacter = true;
            }

            if (i > 0 && password[i] == password[i - 1])
            {
                return false;
            }
        }

        return hasLowerCase && hasUpperCase && hasDigit && hasSpecialCharacter;
    }
}
