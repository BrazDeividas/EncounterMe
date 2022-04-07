using EncounterMe;
using WebAPI.Database;

namespace WebAPI.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
            entities = context.Users;
        }
    }
}
