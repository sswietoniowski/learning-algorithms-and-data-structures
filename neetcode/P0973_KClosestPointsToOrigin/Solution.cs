namespace neetcode.P0973_KClosestPointsToOrigin;

// https://leetcode.com/problems/k-closest-points-to-origin/
// https://youtu.be/rI2EBUEMfTk
public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var heap = new PriorityQueue<int[], int>();

        foreach (var point in points)
        {
            var distance = point[0] * point[0] + point[1] * point[1];
            heap.Enqueue(point, distance);
        }

        var result = new int[k][];

        for (var i = 0; i < k; i++)
        {
            result[i] = heap.Dequeue();
        }

        return result;
    }
}