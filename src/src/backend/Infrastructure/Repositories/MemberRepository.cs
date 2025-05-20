using BloomFilter.Core.Entities;
using BloomFilter.Core.Interfaces;
using BloomFilter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BloomFilter.Infrastructure.Repositories;

public class MemberRepository(ApplicationDbContext dbContext) : IMemberRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<List<Member>> GetAllMembersAsync()
    {
        var members = await _dbContext.Member.ToListAsync();
        return new List<Member>(members.Select(x => Member.Create(x.IdMember, x.Name, x.Surname, x.Email)));

    }

    public async Task<Member> GetMemberByIdAsync(Guid id)
    {
        var memberEntity = await _dbContext.Member.FirstOrDefaultAsync(x => x.IdMember == id);

        if (memberEntity == null)
        {
            return null;
        }

        return Member.Create(memberEntity.IdMember, memberEntity.Name, memberEntity.Surname, memberEntity.Email);
    }
}
