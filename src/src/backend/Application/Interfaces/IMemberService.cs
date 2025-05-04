namespace BloomFilter.Application.Interfaces;
public interface IMemberService
{
    Task<MemberDto> GetMemberAsync(Guid id);
}