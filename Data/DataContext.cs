using CantThinkOfATitle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CantThinkOfATitle.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
        //: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        //public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users", "Identity");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Identity");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Identity");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Identity");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Identity");
        }
    }   

}
