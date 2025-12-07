using System.Text;

namespace neetcode.P0269_AlienDictionary;

public class Solution
{
    public string foreignDictionary(string[] words)
    {
        var adj = new Dictionary<char, HashSet<char>>();
        var indegree = new Dictionary<char, int>();

        foreach (var word in words)
        {
            foreach (var c in word)
            {
                if (!adj.ContainsKey(c))
                {
                    adj[c] = new HashSet<char>();
                }
                if (!indegree.ContainsKey(c))
                {
                    indegree[c] = 0;
                }
            }
        }

        for (int i = 0; i < words.Length - 1; i++)
        {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen))
            {
                return "";
            }
            for (int j = 0; j < minLen; j++)
            {
                if (w1[j] != w2[j])
                {
                    if (!adj[w1[j]].Contains(w2[j]))
                    {
                        adj[w1[j]].Add(w2[j]);
                        indegree[w2[j]]++;
                    }
                    break;
                }
            }
        }

        var q = new Queue<char>();
        foreach (var c in indegree.Keys)
        {
            if (indegree[c] == 0)
            {
                q.Enqueue(c);
            }
        }

        var res = new StringBuilder();
        while (q.Count > 0)
        {
            var char_ = q.Dequeue();
            res.Append(char_);
            foreach (var neighbor in adj[char_])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                {
                    q.Enqueue(neighbor);
                }
            }
        }

        if (res.Length != indegree.Count)
        {
            return "";
        }

        return res.ToString();
    }
}
