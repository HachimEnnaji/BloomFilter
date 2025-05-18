using BloomFilter.Application;
using BloomFilter.Application.CustomExceptions;
using BloomFilter.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BloomFilter.Api.Endpoints
{
    public static class MemberEndpoints
    {

        public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/member").WithTags("Members").WithOpenApi();

            //GET api/member/{id}

            group.MapGet("/", async Task<Results<Ok<MemberDto>, NotFound<ProblemDetails>>> (
                [FromQueryAttribute] Guid id, IMemberService memberService, ILogger<Program> logger) =>
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
            )
            .WithName("GetMember")
            .WithDescription("Get Member By ID")
            .Produces<MemberDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

            return app;

        }
    }
}
