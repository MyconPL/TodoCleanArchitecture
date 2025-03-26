using Microsoft.EntityFrameworkCore;
using TodoCA.API.Entities;

namespace TodoCA.API.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> ToDoItem { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
