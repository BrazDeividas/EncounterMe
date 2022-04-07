using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EncounterMe;
using WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //we probably shouldn't send passwords as strings to webservice, but rather hash them in the app
        //public string SignIn(string username, string password)
        //{
        //    //DatabaseManager databaseManager = new DatabaseManager();
        //    //LogInManager logInManager = new LogInManager(databaseManager);
        //    //User user = logInManager.CheckPassword(username, password);
        //    //if (user != null)
        //    //    return null;
        //    //    //would be nice to have a serializer method ( maybe after we rework database? )
        //    //    // TODO : change null to serialized user
        //    //else
        //    //    return null;
        //}

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult<User>> Authenticate(Credentials credentials)
        {
            var user = await userService.Authenticate(credentials);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
        private int? TryGetUserId()
        {
            int res = 0;
            if (int.TryParse(this.User.FindFirst(ClaimTypes.Name)?.Value, out res))
                return res;
            else
                return null;
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userid = this.TryGetUserId();
            if (userid == null)
            {
                return NoContent();
            }
            return Ok(await userService.GetUserById((int)userid));
        }

        ////change to hash when we start hashing in app
        //public string SingUp(string username, string email, string password)
        //{
        //    //DatabaseManager databaseManager = new DatabaseManager();
        //    //LogInManager logInManager = new LogInManager(databaseManager);
        //    //User user = logInManager.CreateUser(username, email, password);
        //    //if (user != null)
        //    //    return null;
        //    //    // TODO : change null to serialized user
        //    //else
        //    //    return null;
        //}
    }
}
