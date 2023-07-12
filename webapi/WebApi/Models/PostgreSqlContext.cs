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
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
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
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
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
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
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
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
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
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
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
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = false
                        }
                    );
                    builder
                    .Entity<Entity>()
                    .HasData(
                        new Entity
                        {
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            CompanyName = "EyeCue Lab"
                        },
                        new Entity
                        {
                            EntityId = "98a29f8d-3129-4af1-831a-ff52c16a5c6d",
                            CompanyName = "CocaCola"
                        }
                    );
                    builder
                        .Entity<EmailEntity>()
                        .HasData(
                            new EmailEntity
                            {
                                EmailEntityId = "1",
                                Email = "szook7@gmail.com",
                                EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                            },
                            new EmailEntity
                            {
                                EmailEntityId = "2",
                                Email = "lee.justin001126@gmail.com",
                                EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                            },
                            new EmailEntity
                            {
                                EmailEntityId = "3",
                                Email = "erintimlin@gmail.com",
                                EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                            },
                            new EmailEntity
                            {
                                EmailEntityId = "4",
                                Email = "Gronstal.Larson@gmail.com",
                                EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                            },
                            new EmailEntity
                            {
                                EmailEntityId = "5",
                                Email = "b.bakshev@gmail.com",
                                EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                            },
                            new EmailEntity
                            {
                                EmailEntityId = "6",
                                Email = "eliot.lauren@gmail.com",
                                EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                            }
                        );
                    builder
                    .Entity<Project>()
                    .HasData(
                        new Project
                        {
                            ProjectId= "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            EntityId= "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            ProjectName= "EyeCue Lab Project"
                        },
                        new Project
                        {
                            ProjectId= "0ed8fcad-f106-4717-b313-751a41e1077a",
                            EntityId= "98a29f8d-3129-4af1-831a-ff52c16a5c6d",
                            ProjectName= "CocaCola"
                        }
                    );
                    builder
                    .Entity<ProjectAppUser>()
                    .HasData(            
                        new ProjectAppUser
                        {
                            ProjectAppUserId="1",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            AppUserId = "1"
                        },
                        new ProjectAppUser
                        {
                            ProjectAppUserId="2",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            AppUserId = "2"
                        },
                        new ProjectAppUser
                        {
                            ProjectAppUserId="3",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            AppUserId = "3"
                        },
                        new ProjectAppUser
                        {
                            ProjectAppUserId="4",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            AppUserId = "4"
                        },
                        new ProjectAppUser
                        {
                            ProjectAppUserId="5",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            AppUserId = "5"
                        },
                        new ProjectAppUser
                        {
                            ProjectAppUserId="6",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            AppUserId = "6"
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
