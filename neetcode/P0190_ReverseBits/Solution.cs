namespace neetcode.P0190_ReverseBits;

public class Solution
{
    // https://leetcode.com/problems/reverse-bits/
    // https://youtu.be/UcoN6UjAI64
    // v1
    //public uint reverseBits(uint n)
    //{
    //    //uint result = 0;

    //    //uint inMask = 1;
    //    //uint outMask = (uint)1 << 31;
    //    //for (int i = 0; i < 32; i++)
    //    //{
    //    //    if ((n & inMask) != 0)
    //    //    {
    //    //        result |= outMask;
    //    //    }

    //    //    inMask <<= 1;
    //    //    outMask >>= 1;
    //    //}

    //    //return result;
    //}

    // v2
    private byte reverseByte(byte b)
    {
        return (byte)((((uint)b) * 0x0202020202 & 0x010884422010) % 1023);
    }

    public uint reverseBits(uint n)
    {
        uint result = 0;

        for (int i = 0; i < 4; i++)
        {
            byte b = (byte)((n >> (i * 8)) & 0xff);
            result += ((uint)reverseByte(b)) << ((3 - i) * 8);
        }

        return result;
    }
}