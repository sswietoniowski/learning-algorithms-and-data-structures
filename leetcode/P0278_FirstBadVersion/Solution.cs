namespace leetcode.P0278_FirstBadVersion;

// https://leetcode.com/problems/first-bad-version/description/
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
public class VersionControl
{
    protected bool IsBadVersion(int version)
    {
        // This is a placeholder for the actual implementation.
        return false;
    }
}

public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int left = 1;
        int right = n;
        int result = 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (IsBadVersion(mid))
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return result;
    }
}
