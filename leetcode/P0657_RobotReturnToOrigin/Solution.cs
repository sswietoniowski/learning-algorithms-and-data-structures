namespace leetcode.P0657_RobotReturnToOrigin;

// https://leetcode.com/problems/robot-return-to-origin/description/?envType=daily-question&envId=2026-04-05
public class Solution
{
    public bool JudgeCircle(string moves)
    {
        int x = 0;
        int y = 0;

        foreach (char move in moves)
        {
            if (move == 'U')
            {
                y++;
            }
            else if (move == 'D')
            {
                y--;
            }
            else if (move == 'L')
            {
                x--;
            }
            else if (move == 'R')
            {
                x++;
            }
        }

        // The robot is back at (0,0) only if both displacements are zero
        return x == 0 && y == 0;
    }
}
