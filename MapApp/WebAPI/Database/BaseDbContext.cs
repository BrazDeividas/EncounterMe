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

        public DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserSeed
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User { Id = 1, Name = "Hamster", Email = "mrhamster@gmail.com", Password = "ilovehamsters", LevelPoints = 8520, AchievementNum = 10, FoundLocationNum = 23},
                    new User { Id = 2, Name = "Camster", Email = "mrcamster@gmail.com", Password = "ilovecamsters", LevelPoints = 8520, AchievementNum = 10, FoundLocationNum = 23}
                );
            #endregion
        }
    }
}

