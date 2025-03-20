using Microsoft.EntityFrameworkCore;
using TodoCA.API.Entities;

namespace TodoCA.Infrastructure.Persistence
{
    class AppDbContext : DbContext
    {
        public DbSet<TodoItem> ToDoItem { get; set; }
    }
}
