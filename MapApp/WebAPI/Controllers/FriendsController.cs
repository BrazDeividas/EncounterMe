using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EncounterMe;
using WebAPI.Services;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : Controller
    {
        private readonly IFriendService _friendService;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("userId={id}")]
        public async Task<ActionResult<IEnumerable<FriendDto>>> GetFriendsAsync(int id)
        {
            var friends = await _friendService.GetFriendsByUserId(id);

            if (friends != null)
            {
                return Ok(friends);
            }

            return NotFound();
        }

        [HttpGet("requests/received/userId={id}")]
        public async Task<ActionResult<IEnumerable<FriendRequest>>> GetReceivedFriendRequests(int id)
        {
            var requests = await _friendService.GetFriendRequestsByReceiverId(id);

            if (requests != null)
            {
                return Ok(requests);
            }

            return NotFound();
        }

        [HttpPost("requests/send/userId={receiverId}")]
        public async Task<IActionResult> SendFriendRequestById([FromBody] int senderId, int receiverId)
        {
            if (await _friendService.SendFriendRequestById(senderId, receiverId))
                return Ok();

            return BadRequest();
        }

        [HttpPut("requests/accept/requestId={id}")]
        public async Task<IActionResult> AcceptFriendRequestByIdAsync(int id)
        {
            if (await _friendService.AcceptFriendRequestById(id))
                return Ok();
            
            return NotFound();
        }

        [HttpDelete("requests/delete/requestId={id}")]
        public async Task<IActionResult> DeleteFriendRequestByIdAsync(int id)
        {
            if (await _friendService.DeleteFriendRequestById(id))
                return Ok();

            return NotFound();
        }
    }
}
