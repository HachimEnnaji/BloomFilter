using BloomFilter.Application;
using BloomFilter.Application.CustomExceptions;
using BloomFilter.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BloomFilter.Api
{
    public static class MemberEndpoint
    {
        public static async Task<Results<Ok<MemberDto>, NotFound<ProblemDetails>>> GetMemberByIdAsync([FromRoute] Guid id, IMemberService memberService, [FromServices] ILogger<Object> logger)
        {
            try
            {
                var member = await memberService.GetMemberAsync(id);
                return TypedResults.Ok(member);
            }
            catch (NotFoundException ex)
            {
                logger.LogWarning(ex, "Member not found: {Message}", ex.Message);
                return TypedResults.NotFound(new ProblemDetails
                {
                    Title = "Member not found",
                    Detail = ex.Message,
                    Status = StatusCodes.Status404NotFound
                });
            }
        }



        public static async Task<Results<Ok<List<MemberDto>>, NotFound<ProblemDetails>>> GetAllMembersAsync(IMemberService memberService, ILogger<Object> logger)
        {
            {
                try
                {
                    var members = await memberService.GetAllMembersAsync();
                    return TypedResults.Ok(members);
                }
                catch (NotFoundException ex)
                {
                    logger.LogWarning(ex, "Members not found: {Message}", ex.Message);
                    return TypedResults.NotFound(new ProblemDetails
                    {
                        Title = "Member not found",
                        Detail = ex.Message,
                        Status = StatusCodes.Status404NotFound
                    });
                }
            }
        }
    }
}
