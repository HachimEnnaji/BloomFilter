using BloomFilter.Core.Interfaces;

namespace BloomFilter.Infrastructure;
public class SimpleHash : IHashFunction
{
    public int ComputeHash(string input, int maxValue)
    {
        return ((input.Length + maxValue) * 2) % maxValue;
    }
}
