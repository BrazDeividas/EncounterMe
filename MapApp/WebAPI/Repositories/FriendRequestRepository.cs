using EncounterMe;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database;
using System.Linq;

namespace WebAPI.Repositories
{
    public class FriendRequestRepository : Repository<FriendRequest>, IFriendRequestRepository
    {

        public FriendRequestRepository(BaseDbContext context) : base(context)
        {
            entities = context.FriendRequests;
        }

        public IEnumerable<FriendRequest> GetRequestsByReceiverId(int userId)
        {
            var requests = from fr in entities
                           where fr.ReceiverId == userId
                           select fr;

            return requests;
        }

        public IEnumerable<FriendRequest> GetRequestsBySenderId(int userId)
        {
            var requests = from fr in entities
                           where fr.UserId == userId
                           select fr;

            return requests;
        }
    }
}
