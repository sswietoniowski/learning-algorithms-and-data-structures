namespace neetcode.P0895_MaximumFrequencyStack;

// https://leetcode.com/problems/maximum-frequency-stack/description/
// https://neetcode.io/problems/maximum-frequency-stack/question?list=neetcode250
using System.Collections.Generic;

public class FreqStack
{
    private Dictionary<int, int> freq;
    private Dictionary<int, Stack<int>> group;
    private int maxFreq;

    public FreqStack()
    {
        freq = new Dictionary<int, int>();
        group = new Dictionary<int, Stack<int>>();
        maxFreq = 0;
    }

    public void Push(int val)
    {
        // 1. Update the frequency of the value
        if (!freq.ContainsKey(val))
            freq[val] = 0;
        int f = ++freq[val];

        // 2. Track the global maximum frequency
        if (f > maxFreq)
            maxFreq = f;

        // 3. Add the value to the stack corresponding to its current frequency
        if (!group.ContainsKey(f))
        {
            group[f] = new Stack<int>();
        }
        group[f].Push(val);
    }

    public int Pop()
    {
        // 1. Get the most frequent element from the highest frequency group
        int val = group[maxFreq].Pop();

        // 2. Update the frequency map for the value
        freq[val]--;

        // 3. If the highest frequency group is empty, decrement maxFreq
        if (group[maxFreq].Count == 0)
        {
            maxFreq--;
        }

        return val;
    }
}
