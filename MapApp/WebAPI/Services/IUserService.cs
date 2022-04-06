using EncounterMe;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(Credentials credentials);
        Task<User> GetUserById(int userid);
    }
}
