namespace neetcode.P0211_DesignAddAndSearchWordsDataStructure;

// https://leetcode.com/problems/design-add-and-search-words-data-structure/
// https://youtu.be/BTf05gs_8iU
public class WordDictionary
{
    private class Node
    {
        public Dictionary<char, Node> Children { get; } = new();
        public bool IsCompleteWord { get; set; } = false;
    }

    private Node root = new();

    public WordDictionary() {}

    public void AddWord(string word)
    {
        var node = root;
        foreach (var character in word)
        {
            if (!node.Children.ContainsKey(character))
            {
                node.Children[character] = new Node();
            }
            node = node.Children[character];
        }
        node.IsCompleteWord = true;
    }

    private bool dfs(Node root, string word, int index)
    {
        var node = root;

        for (int i = index; i < word.Length; i++)
        {
            var character = word[i];
            if (character == '.')
            {
                foreach (var child in node.Children.Values)
                {
                    if (dfs(child, word, i + 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                if (!node.Children.ContainsKey(character))
                {
                    return false;
                }
                node = node.Children[character];
            }
        }

        return node is { IsCompleteWord: true };
    }

    public bool Search(string word)
    {
        return dfs(root, word, 0);
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */