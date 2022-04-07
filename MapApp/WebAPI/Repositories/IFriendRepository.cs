using EncounterMe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Repositories
{
    public interface IFriendRepository : IRepository<Friend>
    {
        IEnumerable<Friend> GetFriendsByUserId(int userId);
    }
}
