using BloomFilter.Core.Entities;

namespace BloomFilter.Core.Interfaces;

public interface IMemberRepository
{
    Task<Member> GetMemberByIdAsync(Guid id);
}
