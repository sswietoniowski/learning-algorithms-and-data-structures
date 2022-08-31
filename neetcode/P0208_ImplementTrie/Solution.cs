namespace neetcode.P0208_ImplementTrie
{
    public class Node
    {
        public Dictionary<char, Node> Children { get; } = new();
        public bool IsCompleteWord { get; set; } = false;
    }

    // https://leetcode.com/problems/implement-trie-prefix-tree/
    // https://youtu.be/oobqoCJlHA0
    public class Trie
    {
        private Node root = new();

        public Trie()
        {
        }

        public void Insert(string word)
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

        public Node FindNode(string word)
        {
            var node = root;
            foreach (var character in word)
            {
                if (!node.Children.ContainsKey(character))
                {
                    return null;
                }
                node = node.Children[character];
            }
            return node;
        }

        public bool Search(string word)
        {
            return FindNode(word)?.IsCompleteWord ?? false;
        }

        public bool StartsWith(string prefix)
        {
            return FindNode(prefix) != null;
        }
    }
}
