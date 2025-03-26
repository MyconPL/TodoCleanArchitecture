using Microsoft.EntityFrameworkCore;
using TodoCA.Domain.Entities;

namespace TodoCA.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> ToDoItem { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
