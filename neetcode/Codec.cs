using System.Text;

namespace neetcode
{
    // https://leetcode.com/problems/encode-and-decode-strings/
    // https://youtu.be/B1k_sxOSgv8
    public class Codec
    {
        private readonly HashSet<char> escapedCharacters = new HashSet<char>()
    {
        '[', ']', '"', ',', '\\'
    };

        // Encodes a list of strings to a single string.
        public string encode(IList<string> strs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            bool addSeparator = false;
            foreach (var s in strs)
            {
                if (addSeparator)
                {
                    sb.Append(',');
                }

                sb.Append('"');

                foreach (var ch in s)
                {
                    if (escapedCharacters.Contains(ch))
                    {
                        sb.Append('\\');
                    }

                    sb.Append(ch);
                }

                sb.Append('"');

                addSeparator = true;
            }
            sb.Append(']');

            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public IList<string> decode(string s)
        {
            var result = new List<string>();

            if (s.StartsWith('['))
            {
                s = s.Substring(1);
            }

            if (s.EndsWith(']'))
            {
                s = s.Substring(0, s.Length - 1);
            }

            var inWord = false;
            var word = new StringBuilder();
            var escape = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!escape && s[i] == '\\')
                {
                    escape = true;
                    continue;
                }

                if (!inWord && s[i] == '"')
                {
                    inWord = true;
                    escape = false;
                    continue;
                }

                if (inWord && !escape && s[i] == '"')
                {
                    result.Add(word.ToString());
                    word.Clear();
                    escape = false;
                    inWord = false;
                    continue;
                }

                if (!inWord && s[i] == ',')
                {
                    continue;
                }

                word.Append(s[i]);
                escape = false;
            }

            return result;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(strs));
}
