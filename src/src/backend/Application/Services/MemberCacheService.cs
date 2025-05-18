using BloomFilter.Application.Interfaces;
using BloomFilter.Core.Entities;
using BloomFilter.Core.Interfaces;

namespace BloomFilter.Application.Services;

public class MemberCacheService(IMemberService memberService, ICacheService<MemberDto> cache) : IMemberService
{
    private readonly ICacheService<MemberDto> _cache = cache;
    private readonly IMemberService _memberService = memberService;
    public async Task<MemberDto> GetMemberAsync(Guid id)
    {
        string key = id.ToString();
        var memberInCache = await _cache.GetAsync(key);
        if (memberInCache is not null)
            return memberInCache;
        var memberInDb = await _memberService.GetMemberAsync(id);

        await _cache.SetAsync(key, memberInDb);
        return memberInDb;
    }

    private MemberDto MapEntity(Member member)
    {
        return new MemberDto
        {
            Email = member.Email,
            LastName = member.Surname,
            Name = member.Name,
            Id = member.Id,
        };
    }
}
