namespace BloomFilter.Core.Interfaces;

public interface IBloomFilter
{
    void Add(string input);
    bool IsContaining(string input);
}
