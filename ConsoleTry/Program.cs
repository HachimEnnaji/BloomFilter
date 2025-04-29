using BloomFilter.Core.Implementations;
using BloomFilter.Core.Interfaces;
using BloomFilter.Infrastructure;

namespace ConsoleTry;
public class Program
{
    static void Main()
    {
        var array = new SimpleBitArray(1_000);
        var hashFunctionsList = new List<IHashFunction> { new SimpleHash(), new MurmurHash() };

        var bloomFilter = new BloomFilters(array, hashFunctionsList);
        bloomFilter.Add("cat");
        bloomFilter.Add("dog");
        bloomFilter.Add("snake");
        bloomFilter.Add("monkey");
        bloomFilter.Add("butterfly");


        var hasCat = bloomFilter.IsContaining("cat");
        var HasHorse = bloomFilter.IsContaining("horse");
        Console.WriteLine($"The cat is {(hasCat ? "present" : "not present")}");

        Console.WriteLine($"The horse is {(HasHorse ? "present" : "not present")}");

        //WIP

        var f = bloomFilter.GetBitArray();
        int i = 0;
        foreach (var bit in f)
        {
            Console.WriteLine($"{i} :\t{bit}");
            i++;
        }
    }
}