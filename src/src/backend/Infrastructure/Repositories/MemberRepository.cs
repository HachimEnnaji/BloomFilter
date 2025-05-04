using BloomFilter.Core.Entities;
using BloomFilter.Core.Interfaces;
using BloomFilter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BloomFilter.Infrastructure.Repositories;

public class MemberRepository(ApplicationDbContext dbContext) : IMemberRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public async Task<Member> GetMemberByIdAsync(Guid id)
    {
        var memberEntity = await _dbContext.MemberEntity.FirstOrDefaultAsync(x => x.Id == id);

        if (memberEntity == null)
        {
            return null;
        }

        return Member.Create(memberEntity.Id, memberEntity.Name, memberEntity.Surname, memberEntity.Email);
    }
}
