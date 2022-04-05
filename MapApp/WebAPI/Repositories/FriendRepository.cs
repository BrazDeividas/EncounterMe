using EncounterMe;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database;
using System.Linq;

namespace WebAPI.Repositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {

        public FriendRepository(BaseDbContext context) : base(context)
        {
            entities = context.Friends;
        }

        public IEnumerable<Friend> GetFriendsByUserId(int userId)
        {
            var friends = from f in entities
                          where f.UserId == userId
                          select f;

            return friends;
        }
    }
}
