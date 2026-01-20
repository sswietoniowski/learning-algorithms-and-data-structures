namespace neetcode.P0912_SortAnArray;

// https://leetcode.com/problems/sort-an-array/description/
// https://neetcode.io/problems/sort-an-array/question?list=neetcode250
public class Solution
{
    public int[] SortArray(int[] nums)
    {
        if (nums == null || nums.Length <= 1)
            return nums;

        int[] auxiliary = new int[nums.Length];
        MergeSort(nums, auxiliary, 0, nums.Length - 1);
        return nums;
    }

    private void MergeSort(int[] array, int[] aux, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            // divide
            MergeSort(array, aux, left, mid);
            MergeSort(array, aux, mid + 1, right);

            // conquer
            Merge(array, aux, left, mid, right);
        }
    }

    private void Merge(int[] array, int[] aux, int left, int mid, int right)
    {
        for (int m = left; m <= right; m++)
        {
            aux[m] = array[m];
        }

        int i = left;
        int j = mid + 1;
        int k = left;

        while (i <= mid && j <= right)
        {
            if (aux[i] <= aux[j])
            {
                array[k] = aux[i];
                i++;
            }
            else
            {
                array[k] = aux[j];
                j++;
            }
            k++;
        }

        while (i <= mid)
        {
            array[k] = aux[i];
            i++;
            k++;
        }
    }
}
