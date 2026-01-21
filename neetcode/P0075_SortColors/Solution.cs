namespace neetcode.P0075_SortColors;

// https://leetcode.com/problems/sort-colors/submissions/1892224170/
// https://neetcode.io/problems/sort-colors/question
// v1
/*
public class Solution
{
    public void SortColors(int[] nums)
    {
        QuickSort(nums, 0, nums.Length - 1);
    }

    private void QuickSort(int[] array, int left, int right)
    {
        int i = left;
        int j = right;
        int pivot = array[(left + right) / 2];

        do
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
                i++;
                j--;
            }
        } while (i <= j);

        if (left < j)
        {
            QuickSort(array, left, j);
        }

        if (i < right)
        {
            QuickSort(array, i, right);
        }
    }
}
*/
// v2
/*
public class Solution
{
    public void SortColors(int[] nums)
    {
        int[] count = new int[3];
        foreach (int num in nums)
        {
            count[num]++;
        }

        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            while (count[i]-- > 0)
            {
                nums[index++] = i;
            }
        }
    }
}
*/
// v3
public class Solution
{
    public void SortColors(int[] nums)
    {
        int zero = 0,
            one = 0;

        for (int two = 0; two < nums.Length; two++)
        {
            int tmp = nums[two];
            nums[two] = 2;

            if (tmp < 2)
            {
                nums[one++] = 1;
            }
            if (tmp < 1)
            {
                nums[zero++] = 0;
            }
        }
    }
}
