namespace leetcode.P2075_DecodeTheSlantedCiphertext;

// https://leetcode.com/problems/decode-the-slanted-ciphertext/description/?envType=daily-question&envId=2026-04-04
using System.Text;

public class Solution
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        // Edge case: if there's only one row, the text isn't shifted
        if (rows <= 1)
            return encodedText;

        int n = encodedText.Length;
        int cols = n / rows;
        StringBuilder original = new StringBuilder();

        // Each diagonal starts at a column 'j' in the first row (row 0)
        for (int j = 0; j < cols; j++)
        {
            // Traverse the diagonal starting from (0, j)
            for (int i = 0; i < rows; i++)
            {
                int currRow = i;
                int currCol = j + i; // The diagonal shift

                // If the diagonal moves past the last column, this diagonal is finished
                if (currCol >= cols)
                {
                    break;
                }

                // Convert 2D coordinates back to 1D index
                int index = (currRow * cols) + currCol;
                original.Append(encodedText[index]);
            }
        }

        // The problem states originalText does not have trailing spaces
        return original.ToString().TrimEnd();
    }
}
