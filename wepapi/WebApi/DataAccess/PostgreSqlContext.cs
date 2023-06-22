using Microsoft.EntityFrameworkCore;  
using WebApi.Models;  

namespace WebApi.DataAccess  
{  
    public class PostgreSqlContext: DbContext  
    {  
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)  
        {  
        }  

        public DbSet<User> Users { get; set; }
        public DbSet<Entity> Entities { get; set; } 
        public DbSet<Project> Projects { get; set; } 

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