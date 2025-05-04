using BloomFilter.Application;
using BloomFilter.Application.CustomExceptions;
using BloomFilter.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloomFilter.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMemberService memberService) : ControllerBase
    {
        private readonly IMemberService _memberService = memberService;

        [HttpGet]
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var member = await _memberService.GetMemberAsync(id);
                return Ok(member);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
