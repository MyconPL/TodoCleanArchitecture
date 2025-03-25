using Microsoft.EntityFrameworkCore;
using TodoCA.API.Entities;
using TodoCA.API.Repositories;
using TodoCA.Infrastructure.Persistence;

namespace TodoCA.API.Repoitories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        public async Task ToDoItemAdd(TodoItem toDoItem)
        {   
            using (var db = new AppDbContext())
            {
                db.Add(toDoItem);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<TodoItem>> GetToDoItemList()
        {
            using (var db = new AppDbContext())
            {
                return await db.ToDoItem.ToListAsync();
            }
        }
    }
}