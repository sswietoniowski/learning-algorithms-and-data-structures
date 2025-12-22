public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord) || beginWord == endWord)
            return 0;
        int m = wordList[0].Length;
        HashSet<string> wordSet = new HashSet<string>(wordList);
        Queue<string> qb = new Queue<string>(),
            qe = new Queue<string>();
        Dictionary<string, int> fromBegin = new Dictionary<string, int>(),
            fromEnd = new Dictionary<string, int>();
        qb.Enqueue(beginWord);
        qe.Enqueue(endWord);
        fromBegin[beginWord] = 1;
        fromEnd[endWord] = 1;

        while (qb.Count > 0 && qe.Count > 0)
        {
            if (qb.Count > qe.Count)
            {
                var tempQ = qb;
                qb = qe;
                qe = tempQ;
                var tempMap = fromBegin;
                fromBegin = fromEnd;
                fromEnd = tempMap;
            }
            int size = qb.Count;
            for (int k = 0; k < size; k++)
            {
                string word = qb.Dequeue();
                int steps = fromBegin[word];
                for (int i = 0; i < m; i++)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c == word[i])
                            continue;
                        string nei = word.Substring(0, i) + c + word.Substring(i + 1);
                        if (!wordSet.Contains(nei))
                            continue;
                        if (fromEnd.ContainsKey(nei))
                            return steps + fromEnd[nei];
                        if (!fromBegin.ContainsKey(nei))
                        {
                            fromBegin[nei] = steps + 1;
                            qb.Enqueue(nei);
                        }
                    }
                }
            }
        }
        return 0;
    }
}
