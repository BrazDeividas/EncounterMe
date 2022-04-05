using EncounterMe;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Database
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Friend> Friends {  get; set; }

        public DbSet<FriendRequest> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //pre-configured users here i guess
        }
    }
}

