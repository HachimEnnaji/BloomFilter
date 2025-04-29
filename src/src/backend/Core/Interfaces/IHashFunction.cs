namespace BloomFilter.Core.Interfaces;

public interface IHashFunction
{
    int ComputeHash(string input, int maxValue);
}
