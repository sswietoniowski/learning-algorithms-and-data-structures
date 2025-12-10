namespace neetcode.P1899_MergeTripletsToFormTargetTriplet;

// https://leetcode.com/problems/merge-triplets-to-form-target-triplet/description/
// https://neetcode.io/problems/merge-triplets-to-form-target/question?list=neetcode150
public class Solution
{
    public bool MergeTriplets(int[][] triplets, int[] target)
    {
        bool x = false,
            y = false,
            z = false;
        foreach (var t in triplets)
        {
            x |= (t[0] == target[0] && t[1] <= target[1] && t[2] <= target[2]);
            y |= (t[0] <= target[0] && t[1] == target[1] && t[2] <= target[2]);
            z |= (t[0] <= target[0] && t[1] <= target[1] && t[2] == target[2]);
            if (x && y && z)
                return true;
        }
        return false;
    }
}
