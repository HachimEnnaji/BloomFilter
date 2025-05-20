using BloomFilter.Application;
using Microsoft.AspNetCore.Mvc;

namespace BloomFilter.Api.Endpoints
{
    public static class MemberEndpoints
    {

        public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/member").WithTags("Members").WithOpenApi();

            //GET api/member/{id}

            group.MapGet("/{id:guid}", MemberEndpoint.GetMemberByIdAsync)
            .WithName("GetMember")
            .WithDescription("Get Member By ID")
            .Produces<MemberDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

            group.MapGet("/", MemberEndpoint.GetAllMembersAsync)
            .WithName("GetMembers")
            .WithDescription("Get All Members ")
            .Produces<MemberDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);



            return app;

        }
    }
}
