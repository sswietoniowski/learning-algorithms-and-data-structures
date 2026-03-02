namespace neetcode.P1095_FindInMountainArray;

class MountainArray
{
    public int Get(int index)
    {
        throw new NotImplementedException();
    }

    public int Length()
    {
        throw new NotImplementedException();
    }
}

// https://leetcode.com/problems/find-in-mountain-array/description/
// https://neetcode.io/problems/find-in-mountain-array/question?list=neetcode250
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 * public int Get(int index) {}
 * public int Length() {}
 * }
 */

class Solution
{
    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        int n = mountainArr.Length();

        // 1. Find the peak index
        int peak = FindPeak(mountainArr, n);

        // 2. Search in the increasing part (0 to peak)
        int index = BinarySearch(mountainArr, target, 0, peak, true);
        if (index != -1)
            return index;

        // 3. Search in the decreasing part (peak + 1 to n - 1)
        return BinarySearch(mountainArr, target, peak + 1, n - 1, false);
    }

    private int FindPeak(MountainArray mountainArr, int n)
    {
        int low = 0,
            high = n - 1;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
            {
                low = mid + 1; // We are on the uphill slope
            }
            else
            {
                high = mid; // We are on the downhill slope or at the peak
            }
        }
        return low;
    }

    private int BinarySearch(
        MountainArray mountainArr,
        int target,
        int low,
        int high,
        bool isIncreasing
    )
    {
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int midVal = mountainArr.Get(mid);

            if (midVal == target)
                return mid;

            if (isIncreasing)
            {
                if (midVal < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            else
            {
                // For the decreasing side, the logic is flipped
                if (midVal > target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
        }
        return -1;
    }
}
