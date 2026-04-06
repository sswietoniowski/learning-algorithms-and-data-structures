namespace leetcode.P0874_WalkingRobotSimulation;

// https://leetcode.com/problems/walking-robot-simulation/description/?envType=daily-question&envId=2026-04-06
public class Solution
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        // 1. Define directions in clockwise order: North, East, South, West
        // This allows turning right with (i + 1) % 4 and left with (i + 3) % 4
        int[][] directions = new int[][]
        {
            new int[] { 0, 1 }, // North
            new int[] { 1, 0 }, // East
            new int[] { 0, -1 }, // South
            new int[] { -1, 0 }, // West
        };

        // 2. Use a HashSet for O(1) obstacle lookups.
        // We pack two 32-bit ints into one 64-bit long as a unique key.
        HashSet<long> obstacleSet = new HashSet<long>();
        foreach (var obstacle in obstacles)
        {
            long key = ((long)obstacle[0] << 32) | (uint)obstacle[1];
            obstacleSet.Add(key);
        }

        int x = 0,
            y = 0;
        int dirIndex = 0; // Starts facing North
        int maxSquaredDist = 0;

        foreach (int cmd in commands)
        {
            if (cmd == -1)
            {
                // Turn right 90 degrees
                dirIndex = (dirIndex + 1) % 4;
            }
            else if (cmd == -2)
            {
                // Turn left 90 degrees (same as turning right 270 degrees)
                dirIndex = (dirIndex + 3) % 4;
            }
            else
            {
                // Move forward k units
                for (int i = 0; i < cmd; i++)
                {
                    int nextX = x + directions[dirIndex][0];
                    int nextY = y + directions[dirIndex][1];

                    long nextKey = ((long)nextX << 32) | (uint)nextY;

                    if (!obstacleSet.Contains(nextKey))
                    {
                        x = nextX;
                        y = nextY;
                        // Update max distance at every step
                        maxSquaredDist = Math.Max(maxSquaredDist, x * x + y * y);
                    }
                    else
                    {
                        // Hit an obstacle, stop moving for this command
                        break;
                    }
                }
            }
        }

        return maxSquaredDist;
    }
}
