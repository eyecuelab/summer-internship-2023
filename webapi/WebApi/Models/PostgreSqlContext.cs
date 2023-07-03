using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApi.DataAccess
{
    public class PostgreSqlContext : IdentityDbContext<AppUser>
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ListOfCommits> ListOfCommits { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Committer> Committer { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<EntityAppUser> EntityAppUsers { get; set; }
        public DbSet<ProjectAppUser> ProjectAppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            {
                var hasher = new PasswordHasher<AppUser>();

                builder.Entity<AppUser>().HasData(
                    new AppUser
                    {
                        Id = "1",
                        UserName = "user1",
                        NormalizedUserName = "USER1",
                        Email = "user1@example.com",
                        NormalizedEmail = "USER1@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Password1!"),
                        SecurityStamp = string.Empty,
                        FirstName = "User",
                        LastName = "One",
                        EntityId = 1,
                        IsAdmin = true
                    },
                new AppUser
                {
                    Id = "2",
                    UserName = "user2",
                    NormalizedUserName = "USER2",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password2!"),
                    SecurityStamp = string.Empty,
                    FirstName = "User",
                    LastName = "Two",
                    EntityId = 2,
                    IsAdmin = true
                },
                new AppUser
                {
                    Id = "3",
                    UserName = "user3",
                    NormalizedUserName = "USER3",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password3!"),
                    SecurityStamp = string.Empty,
                    FirstName = "User",
                    LastName = "Three",
                    EntityId = 3,
                    IsAdmin = false
                }

                );
            }
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}