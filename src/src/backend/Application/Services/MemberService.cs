using BloomFilter.Application.Interfaces;
using BloomFilter.Core.Interfaces;

namespace BloomFilter.Application.Services;

public class MemberService(IMemberRepository memberRepository) : IMemberService
{

    private readonly IMemberRepository _repository = memberRepository;
    public async Task<MemberDto> GetMemberAsync(Guid id)
    {
        var member = await _repository.GetMemberByIdAsync(id);

        if (member is null)
        {
            throw new DirectoryNotFoundException($"Member with ID {id} not found");
        }

        return new MemberDto
        {
            Id = member.Id,
            Name = member.Name,
            LastName = member.Surname,
            Email = member.Email,
        };

    }
}
