namespace leetcode.P2751_RobotCollisions;

// https://leetcode.com/problems/robot-collisions/description/?envType=daily-question&envId=2026-04-01
public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        int n = positions.Length;

        // 1. Create an array of indices [0, 1, 2, ..., n-1]
        // We will sort this array instead of the original arrays to keep track of indices.
        int[] indices = new int[n];
        for (int i = 0; i < n; i++)
        {
            indices[i] = i;
        }

        // 2. Sort indices based on their positions (Left to Right)
        Array.Sort(indices, (a, b) => positions[a].CompareTo(positions[b]));

        // 3. Use a stack to track robots moving Right ('R')
        // The stack will store the original index of the robot.
        Stack<int> stack = new Stack<int>();

        foreach (int i in indices)
        {
            if (directions[i] == 'R')
            {
                stack.Push(i);
            }
            else
            {
                // Current robot is moving Left ('L')
                // It will potentially collide with all 'R' robots in the stack
                while (stack.Count > 0 && healths[i] > 0)
                {
                    int topIdx = stack.Peek();

                    if (healths[i] > healths[topIdx])
                    {
                        // Left robot is stronger: Right robot destroyed, Left health -1
                        healths[topIdx] = 0;
                        healths[i] -= 1;
                        stack.Pop();
                    }
                    else if (healths[i] < healths[topIdx])
                    {
                        // Right robot is stronger: Left robot destroyed, Right health -1
                        healths[i] = 0;
                        healths[topIdx] -= 1;
                        // Since Left robot is destroyed, break the while loop
                    }
                    else
                    {
                        // Both have equal health: both destroyed
                        healths[i] = 0;
                        healths[topIdx] = 0;
                        stack.Pop();
                    }
                }
            }
        }

        // 4. Collect surviving healths in the order of their original input index
        List<int> result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (healths[i] > 0)
            {
                result.Add(healths[i]);
            }
        }

        return result;
    }
}
