using Microsoft.EntityFrameworkCore;
using RockStarEmployeesApi.Persistence.Models;

namespace RockStarEmployeesApi.Persistence
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }  
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity => { entity.ToTable("employees"); })
                .Entity<Office>(entity => entity.ToTable("offices"));
        }
    }
}