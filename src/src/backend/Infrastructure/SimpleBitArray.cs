using BloomFilter.Core.Interfaces;
using System.Collections;

namespace BloomFilter.Infrastructure;
public class SimpleBitArray(int capacity) : IBitArray
{
    private readonly BitArray _bitArray = new(capacity);
    public int Length => _bitArray.Length;

    public void Set(int index)
    {
        _bitArray.Set(index, true);
    }

    public bool Get(int index)
    {
        return _bitArray.Get(index);
    }
    public BitArray GetArray() => _bitArray;
}
