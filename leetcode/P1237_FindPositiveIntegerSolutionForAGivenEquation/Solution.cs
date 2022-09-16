namespace leetcode.P1237_FindPositiveIntegerSolutionForAGivenEquation;

public interface CustomFunction
{
    // Returns f(x, y) for any given positive integers x and y.
    // Note that f(x, y) is increasing with respect to both x and y.
    // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
    public int f(int x, int y);
};

// https://leetcode.com/problems/find-positive-integer-solution-for-a-given-equation/
public class Solution
{
    // v1
    //public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
    //{
    //    IList<IList<int>> result = new List<IList<int>>();

    //    for (int i = 1; i <= z; i++)
    //    {
    //        for (int j = 1; j <= z; j++)
    //        {
    //            if (customfunction.f(i, j) == z)
    //            {
    //                result.Add(new List<int>() { i, j });
    //            }
    //        }
    //    }

    //    return result;
    //}

    // v2
    public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
    {
        IList<IList<int>> result = new List<IList<int>>();

        int x = 1000;
        int y = 1;

        while (x >= 1 && y <= 1000)
        {
            if (customfunction.f(x, y) < z)
            {
                y++;
            } 
            else if (customfunction.f(x, y) > z)
            {
                x--;
            }
            else
            {
                result.Add(new List<int>() {x, y});
                x--;
                y++;
            }
        }

        return result;
    }

}