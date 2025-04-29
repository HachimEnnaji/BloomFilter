using BloomFilter.Core.Interfaces;
using System.Collections;

namespace BloomFilter.Core.Implementations;
public class BloomFilters(IBitArray bitArray, IEnumerable<IHashFunction> hashFunctions) : IBloomFilter
{
    private readonly IBitArray _bitArray = bitArray;
    private readonly IList<IHashFunction> _hashedFunctions = new List<IHashFunction>(hashFunctions);
    public void Add(string input)
    {
        foreach (var hash in _hashedFunctions)
        {
            var index = hash.ComputeHash(input, _bitArray.Length);

            _bitArray.Set(index);
        }
    }

    public bool IsContaining(string input)
    {
        return _hashedFunctions.All(bit => _bitArray.Get(bit.ComputeHash(input, _bitArray.Length)));
    }

    public BitArray GetBitArray() => _bitArray.GetArray();
}
