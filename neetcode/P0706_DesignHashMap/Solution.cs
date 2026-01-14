namespace neetcode.P0706_DesignHashMap;

// https://leetcode.com/problems/design-hashmap/description/
// https://neetcode.io/problems/design-hashmap/question
public class MyHashMap
{
    private int[] map;

    public MyHashMap()
    {
        map = new int[1000001];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = -1;
        }
    }

    public void Put(int key, int value)
    {
        map[key] = value;
    }

    public int Get(int key)
    {
        return map[key];
    }

    public void Remove(int key)
    {
        map[key] = -1;
    }
}
