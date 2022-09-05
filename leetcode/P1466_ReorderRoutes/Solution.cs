namespace neetcode
{
    public class Solution
    {
        private int dfs(int root, Dictionary<int, Dictionary<int, int>> edges)
        {
            if (!edges.ContainsKey(root))
            {
                return 0;
            }

            int result = 0;

            foreach (var kvp in edges[root])
            {
                if (kvp.Value != -1)
                {
                    result += kvp.Value;
                    edges[root][kvp.Key] = -1;
                    edges[kvp.Key][root] = -1;
                    result += dfs(kvp.Key, edges);
                }
            }

            return result;
        }

        public int MinReorder(int n, int[][] connections)
        {
            int result = 0;

            Dictionary<int, Dictionary<int, int>> edges = new();

            for (int i = 0; i < n; i++)
            {
                edges.Add(i, new Dictionary<int, int>());
            }

            foreach (var connection in connections)
            {
                edges[connection[0]].Add(connection[1], 1);
                edges[connection[1]].Add(connection[0], 0);
            }

            return dfs(0, edges);
        }
    }
}
