using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApi.DataAccess  
{  
    public class PostgreSqlContext: IdentityDbContext<IdentityUser> 
    {  
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)  
        {  
        }  

        public DbSet<User> Users { get; set; }
        public DbSet<Entity> Entities { get; set; } 
        public DbSet<Project> Projects { get; set; }
        public DbSet<EntityUser> EntityUsers { get; set; } 
        public DbSet<ProjectUser> ProjectUsers { get; set; }  

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        }  

        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        }  
    }  
}  