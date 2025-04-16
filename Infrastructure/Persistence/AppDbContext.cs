using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TodoCA.Domain.Entities;

namespace TodoCA.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> ToDoItem { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.UserName)
        }
    }
}
