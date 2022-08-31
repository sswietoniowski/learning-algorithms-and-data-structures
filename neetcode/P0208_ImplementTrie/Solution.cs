namespace neetcode.P0208_ImplementTrie
{
    public class Node
    {
        public Dictionary<char, Node> children = new();
        public bool isCompleteWord = false;
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
                if (!node.children.ContainsKey(character))
                {
                    node.children[character] = new Node();
                }
                node = node.children[character];
            }
            node.isCompleteWord = true;
        }

        public Node FindNode(string word)
        {
            var node = root;
            foreach (var character in word)
            {
                if (!node.children.ContainsKey(character))
                {
                    return null;
                }
                node = node.children[character];
            }
            return node;
        }

        public bool Search(string word)
        {
            return FindNode(word)?.isCompleteWord ?? false;
        }

        public bool StartsWith(string prefix)
        {
            return FindNode(prefix) != null;
        }
    }
}
