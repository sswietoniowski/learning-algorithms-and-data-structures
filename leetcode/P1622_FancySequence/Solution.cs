namespace leetcode.P1622_FancySequence;

using System.Collections.Generic;

// https://leetcode.com/problems/fancy-sequence/description/?envType=daily-question&envId=2026-03-15
public class Fancy
{
    private List<long> _nums;
    private long _a = 1; // Global Multiplier
    private long _b = 0; // Global Increment
    private const long Mod = 1_000_000_007;

    public Fancy()
    {
        _nums = new List<long>();
    }

    public void Append(int val)
    {
        // We need to store x such that (_a * x + _b) % Mod == val
        // Solve for x: x = (val - _b) * inv(_a) % Mod
        long invA = Power(_a, Mod - 2);
        long normalized = (val - _b + Mod) % Mod * invA % Mod;
        _nums.Add(normalized);
    }

    public void AddAll(int inc)
    {
        _b = (_b + inc) % Mod;
    }

    public void MultAll(int m)
    {
        _a = (_a * m) % Mod;
        _b = (_b * m) % Mod;
    }

    public int GetIndex(int idx)
    {
        if (idx >= _nums.Count)
            return -1;

        // Calculate the current value: (a * stored_x + b) % Mod
        long result = (_a * _nums[idx] + _b) % Mod;
        return (int)result;
    }

    // Modular Exponentiation: (base^exp) % Mod
    private long Power(long @base, long exp)
    {
        long res = 1;
        @base %= Mod;
        while (exp > 0)
        {
            if (exp % 2 == 1)
                res = (res * @base) % Mod;
            @base = (@base * @base) % Mod;
            exp /= 2;
        }
        return res;
    }
}

/**
 * Your Fancy object will be instantiated and called as such:
 * Fancy obj = new Fancy();
 * obj.Append(val);
 * obj.AddAll(inc);
 * obj.MultAll(m);
 * int param_4 = obj.GetIndex(idx);
 */
