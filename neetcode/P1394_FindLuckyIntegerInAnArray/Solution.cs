namespace neetcode.P1394_FindLuckyIntegerInAnArray;

// https://leetcode.com/problems/find-lucky-integer-in-an-array/description/
// https://neetcode.io/problems/find-lucky-integer-in-an-array/question
// v1
/*
public class Solution
{
    public int FindLucky(int[] arr)
    {
        Array.Sort(arr);

        var frequencies = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            if (frequencies.ContainsKey(num))
            {
                frequencies[num]++;
            }
            else
            {
                frequencies.Add(num, 1);
            }
        }

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (frequencies[arr[i]] == arr[i])
            {
                return arr[i];
            }
        }

        return -1;
    }
}
*/
// v2
public class Solution
{
    public int FindLucky(int[] arr)
    {
        foreach (int num in arr)
        {
            int idx = num & ((1 << 10) - 1);
            if (idx <= arr.Length)
            {
                arr[idx - 1] += (1 << 10);
            }
        }

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int cnt = arr[i] >> 10;
            if (cnt == i + 1)
                return i + 1;
        }
        return -1;
    }
}
