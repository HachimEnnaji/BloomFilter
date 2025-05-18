using BloomFilter.Application.CustomExceptions;
using BloomFilter.Application.Interfaces;
using BloomFilter.Core.Interfaces;

namespace BloomFilter.Application.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _repository;
    public MemberService(IMemberRepository memberRepository)
    {
        _repository = memberRepository;
    }

    public async Task<MemberDto> GetMemberAsync(Guid id)
    {
        var member = await _repository.GetMemberByIdAsync(id);

        if (member is null)
        {
            throw new NotFoundException($"Member with ID {id} not found");
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
