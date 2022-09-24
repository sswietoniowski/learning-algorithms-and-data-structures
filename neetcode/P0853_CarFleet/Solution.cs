namespace neetcode.P0853_CarFleet;

// https://leetcode.com/problems/car-fleet/
// https://youtu.be/Pr6T-3yB9RM
public class Solution
{
    // v1
    //public int CarFleet(int target, int[] position, int[] speed)
    //{
    //    (int, int)[] combined = position.Zip(speed, (p, s) => (p, s)).ToArray(); // join position & speed into tuple
    //    Array.Sort(combined, (a, b) => b.Item1.CompareTo(a.Item1)); // sort descending

    //    int fleet = 0;
    //    double time = 0;

    //    foreach (var car in combined)
    //    {
    //        double t = (double)(target - car.Item1) / car.Item2;
    //        if (t > time)
    //        {
    //            fleet++;
    //            time = t;
    //        }
    //    }

    //    return fleet;
    //}

    // v2
    public int CarFleet(int target, int[] position, int[] speed)
    {
        (int, int)[] combined = position.Zip(speed, (p, s) => (p, s)).ToArray(); // join position & speed into tuple
        Array.Sort(combined, (a, b) => b.Item1.CompareTo(a.Item1)); // sort descending

        Stack<double> times = new();

        foreach (var car in combined)
        {
            double t = (double)(target - car.Item1) / car.Item2;
            if (times.Count == 0 || t > times.Peek())
            {
                times.Push(t);
            }
        }

        return times.Count;
    }
}