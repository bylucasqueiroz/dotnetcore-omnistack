using Microsoft.EntityFrameworkCore;
using Omnistack.Configurations;
using Omnistack.Models.User;

namespace Omnistack.Context
{
    public class OmnistackContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Omnistack;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserConfiguration().Configure);
        }
    }    
}