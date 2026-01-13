namespace neetcode.P0705_DesignHashSet;

// https://leetcode.com/problems/design-hashset/description/
// https://neetcode.io/problems/design-hashset/question
public class MyHashSet
{
    private int[] set;

    public MyHashSet()
    {
        // key is in the range [1, 1000000]
        // 31251 * 32 = 1000032
        set = new int[31251];
    }

    public void Add(int key)
    {
        set[key / 32] |= GetMask(key);
    }

    public void Remove(int key)
    {
        if (Contains(key))
        {
            set[key / 32] ^= GetMask(key);
        }
    }

    public bool Contains(int key)
    {
        return (set[key / 32] & GetMask(key)) != 0;
    }

    private int GetMask(int key)
    {
        return 1 << (key % 32);
    }
}
