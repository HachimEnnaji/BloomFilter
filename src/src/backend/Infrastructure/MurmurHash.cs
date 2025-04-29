using BloomFilter.Core.Interfaces;

namespace BloomFilter.Infrastructure;

public class MurmurHash : IHashFunction
{
    public int ComputeHash(string input, int maxValue)
    {

        return Math.Abs(input.GetHashCode()) % maxValue;
    }

}
