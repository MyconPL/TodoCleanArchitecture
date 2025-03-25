using Microsoft.EntityFrameworkCore;
using TodoCA.API.Entities;
using TodoCA.API.Repositories;
using TodoCA.Infrastructure.Persistence;

namespace TodoCA.API.Repoitories
{
    public class ToDoItemRepository : IToDoItemRepository
    {

        private readonly AppDbContext _dbContext;

        public ToDoItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToDoItem(TodoItem toDoItem)
        {
            await _dbContext.ToDoItem.AddAsync(toDoItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TodoItem>> GetToDoItemList()
        {
            return await _dbContext.ToDoItem.ToListAsync();
        }

        public async Task ToDoItemAdd(TodoItem toDoItem)
        {
            await _dbContext.ToDoItem.AddAsync(toDoItem);
        }

        public async Task<TodoItem> GetToDoItemById(Guid id)
        {
            return await _dbContext.ToDoItem.FindAsync(id);
        }


        //public async Task ToDoItemAdd(TodoItem toDoItem)
        //{   
        //    using (var db = new AppDbContext())
        //    {
        //        db.Add(toDoItem);
        //        await db.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<TodoItem>> GetToDoItemList()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return await db.ToDoItem.ToListAsync();
        //    }
        //}
    }
}