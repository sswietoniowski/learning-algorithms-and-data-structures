namespace neetcode.P0735_AsteroidCollision;

// https://leetcode.com/problems/asteroid-collision/description/
// https://neetcode.io/problems/asteroid-collision/question?list=allNC
public class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();
        foreach (var asteroid in asteroids)
        {
            if (asteroid > 0)
            {
                stack.Push(asteroid);
            }
            else
            {
                if (stack.Count == 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                }
                else
                {
                    bool destroyed = false;
                    while (stack.Count > 0 && stack.Peek() > 0)
                    {
                        if (stack.Peek() < Math.Abs(asteroid))
                        {
                            stack.Pop();
                            continue;
                        }
                        else if (stack.Peek() == Math.Abs(asteroid))
                        {
                            stack.Pop();
                            destroyed = true;
                            break;
                        }
                        else
                        {
                            destroyed = true;
                            break;
                        }
                    }

                    if (!destroyed)
                    {
                        stack.Push(asteroid);
                    }
                }
            }
        }

        int[] result = stack.ToArray();
        Array.Reverse(result);
        return result;
    }
}
