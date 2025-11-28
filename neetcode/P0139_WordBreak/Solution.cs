namespace neetcode.P0139_WordBreak;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children;
    public bool IsWord;

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsWord = false;
    }
}

public class Trie
{
    public TrieNode Root;

    public Trie()
    {
        Root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode node = Root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.IsWord = true;
    }

    public bool Search(string s, int i, int j)
    {
        TrieNode node = Root;
        for (int idx = i; idx <= j; idx++)
        {
            if (!node.Children.ContainsKey(s[idx]))
            {
                return false;
            }
            node = node.Children[s[idx]];
        }
        return node.IsWord;
    }
}

// https://leetcode.com/problems/word-break/description/
// https://neetcode.io/problems/word-break/question?list=blind75
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        Trie trie = new Trie();
        foreach (string word in wordDict)
        {
            trie.Insert(word);
        }

        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[n] = true;

        int maxLen = 0;
        foreach (string word in wordDict)
        {
            maxLen = Math.Max(maxLen, word.Length);
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = i; j < Math.Min(n, i + maxLen); j++)
            {
                if (trie.Search(s, i, j))
                {
                    dp[i] = dp[j + 1];
                    if (dp[i])
                        break;
                }
            }
        }

        return dp[0];
    }
}
