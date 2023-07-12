using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApi.DataAccess
{
    public class PostgreSqlContext : IdentityDbContext<AppUser>
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ListOfCommits> ListOfCommits { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Committer> Committer { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<EmailEntity> emailEntities{ get; set; }
        public DbSet<ProjectAppUser> ProjectAppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            {
                var hasher = new PasswordHasher<AppUser>();

                builder
                    .Entity<AppUser>()
                    .HasData(
                        new AppUser
                        {
                            Id = "1",
                            UserName = "szook7@gmail.com",
                            NormalizedUserName = "SZOOK7@GMAIL.COM",
                            Email = "szook7@gmail.com",
                            NormalizedEmail = "SZOOK7@GMAIL.COM",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "Password1!"),
                            SecurityStamp = string.Empty,
                            EntityId = 1.ToString(),
                            IsAdmin = true
                        },
                        new AppUser
                        {
                            Id = "2",
                            UserName = "lee.justin001126@gmail.com",
                            NormalizedUserName = "LEE.JUSTIN001126@GMAIL.COM",
                            Email = "lee.justin001126@gmail.com",
                            NormalizedEmail = "LEE.JUSTIN001126@GMAIL.COM",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "Password2!"),
                            SecurityStamp = string.Empty,
                            EntityId = 1.ToString(),
                            IsAdmin = true
                        },
                        new AppUser
                        {
                            Id = "3",
                            UserName = "erintimlin@gmail.com",
                            NormalizedUserName = "ERINTIMLIN@GMAIL.COM",
                            Email = "erintimlin@gmail.com",
                            NormalizedEmail = "ERINTIMLIN@GMAIL.COM",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "Password3!"),
                            SecurityStamp = string.Empty,
                            EntityId = 0.ToString(),
                            IsAdmin = true
                        },
                        new AppUser
                        {
                            Id = "4",
                            UserName = "Gronstal.Larson@gmail.com",
                            NormalizedUserName = "GRONSTAL.LARSON@GMAIL.COM",
                            Email = "gronstal.larson@gmail.com",
                            NormalizedEmail = "GRONSTAL.LARSON@GMAIL.COM",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "Password4!"),
                            SecurityStamp = string.Empty,
                            EntityId = 0.ToString(),
                            IsAdmin = true
                        },
                        new AppUser
                        {
                            Id = "5",
                            UserName = "b.bakshev@gmail.com",
                            NormalizedUserName = "B.BAKSHEV@GMAIL.COM",
                            Email = "b.bakshev@gmail.com",
                            NormalizedEmail = "B.BAKSHEV@GMAIL.COM",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "Password5!"),
                            SecurityStamp = string.Empty,
                            EntityId = 0.ToString(),
                            IsAdmin = true
                        },
                        new AppUser
                        {
                            Id = "6",
                            UserName = "eliot.lauren@gmail.com",
                            NormalizedUserName = "ELIOT.LAUREN@GMAIL.COM",
                            Email = "eliot.lauren@gmail.com",
                            NormalizedEmail = "ELIOT.LAUREN@GMAIL.COM",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "Password6!"),
                            SecurityStamp = string.Empty,
                            EntityId = 0.ToString(),
                            IsAdmin = true
                        }
                    );
                    builder
                    .Entity<Entity>()
                    .HasData(
                        new Entity
                        {
                            EntityId = "1",
                            CompanyName = "EyeCue Lab"
                        },
                        new Entity
                        {
                            EntityId = "0",
                            CompanyName = "Devkoda"
                        }
                    );
                    builder
                    .Entity<Project>()
                    .HasData(
                        new Project
                        {
                            ProjectId= 1,
                            EntityId= "1",
                            ProjectName= "EyeCue Lab Project"
                        },
                        new Project
                        {
                            ProjectId= 2,
                            EntityId= "0",
                            ProjectName= "Devkoda Project"
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
