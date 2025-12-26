namespace neetcode.P0332_ReconstructItinerary;

// https://leetcode.com/problems/reconstruct-itinerary/description/
// https://neetcode.io/problems/reconstruct-flight-path/question?list=neetcode150
public class Solution
{
    public List<string> FindItinerary(IList<IList<string>> tickets)
    {
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets.OrderByDescending(t => t[1]))
        {
            if (!adj.ContainsKey(ticket[0]))
            {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }

        var res = new List<string>();
        var stack = new Stack<string>();
        stack.Push("JFK");

        while (stack.Count > 0)
        {
            var curr = stack.Peek();
            if (!adj.ContainsKey(curr) || adj[curr].Count == 0)
            {
                res.Insert(0, stack.Pop());
            }
            else
            {
                var next = adj[curr][adj[curr].Count - 1];
                adj[curr].RemoveAt(adj[curr].Count - 1);
                stack.Push(next);
            }
        }

        return res;
    }
}
