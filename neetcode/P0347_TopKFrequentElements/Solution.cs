namespace neetcode.P0347_TopKFrequentElements;

// https://leetcode.com/problems/top-k-frequent-elements/
// https://youtu.be/YPTqKIgVk-k
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dict = new();
        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
        }

        PriorityQueue<int, int> priorityQueue = new();
        foreach (var (key, value) in dict)
        {
            priorityQueue.Enqueue(key, -value);
        }

        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = priorityQueue.Dequeue();
        }

        return result;
    }
}