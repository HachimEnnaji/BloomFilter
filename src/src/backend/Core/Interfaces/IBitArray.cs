namespace BloomFilter.Core.Interfaces;
public interface IBitArray
{
    void Set(int index);
    bool Get(int index);
    int Length { get; }
    //BitArray GetArray();
}
