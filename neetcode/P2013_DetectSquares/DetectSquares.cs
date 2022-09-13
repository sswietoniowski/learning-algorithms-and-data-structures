using System.Security.Cryptography.X509Certificates;

namespace neetcode.P2013_DetectSquares
{
    // https://leetcode.com/problems/detect-squares/
    // https://youtu.be/bahebearrDc
    public class DetectSquares
    {
        private readonly Dictionary<(int, int), int> pointsMap;
        private readonly List<(int, int)> points;

        public DetectSquares()
        {
            points = new List<(int, int)>();
            pointsMap = new Dictionary<(int, int), int>();
        }

        public void Add(int[] point)
        {
            points.Add((point[0], point[1]));
            if (!pointsMap.ContainsKey((point[0], point[1])))
            {
                pointsMap.Add((point[0], point[1]), 0);
            }
            pointsMap[(point[0], point[1])] += 1;
        }

        public int Count(int[] point)
        {
            int result = 0;

            (int px, int py) = (point[0], point[1]);

            foreach ((int x, int y) in points)
            {
                if (Math.Abs(px - x) != Math.Abs(py - y) || px == x || py == y)
                {
                    continue;
                }

                if (pointsMap.ContainsKey((x, py)) && pointsMap.ContainsKey((px, y)))
                {
                    result += pointsMap[(x, py)] * pointsMap[(px, y)];
                }
            }
            
            return result;
        }
    }

    /**
     * Your DetectSquares object will be instantiated and called as such:
     * DetectSquares obj = new DetectSquares();
     * obj.Add(point);
     * int param_2 = obj.Count(point);
     */
}
