using EncounterMe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Repositories
{
    public interface IFriendRequestRepository : IRepository<FriendRequest>
    {
        IEnumerable<FriendRequest> GetRequestsByReceiverId(int userId);

        IEnumerable<FriendRequest> GetRequestsBySenderId(int userId);
    }
}
