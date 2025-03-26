using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TodoCA.API.Entities;
using TodoCA.API.Repositories;
using TodoCA.API.Persistence;
using TodoCA.API.DTO;

namespace TodoCA.API.Repoitories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _dbContext;

        //public async Task AddToDoItem(TodoItem toDoItem)
        //{
        //    await _dbContext.ToDoItem.AddAsync(toDoItem);
        //    await _dbContext.SaveChangesAsync();
        //}

        public async Task<List<TodoItem>> GetToDoItemList()
        {
            return await _dbContext.ToDoItem.ToListAsync();
        }

        public async Task ToDoItemAdd(TodoItem toDoItem)
        {
            await _dbContext.ToDoItem.AddAsync(toDoItem);
        }

        public Task DeleteToDoItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task ToggleCompletionToDoItem(Guid id)
        {
            var toggleCompletionToDoItem = await _dbContext.ToDoItem.FindAsync(id);

            if (toggleCompletionToDoItem != null)
            { 
                toggleCompletionToDoItem.IsComplete = !toggleCompletionToDoItem.IsComplete;
                await _dbContext.SaveChangesAsync();
            } else throw new Exception("Item not found");
        }

        public async Task AddToDoItem(AddToDoItemDto addToDoItemDto)
        {
            await _dbContext.ToDoItem.AddAsync(addToDoItemDto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TodoItem> GetToDoItemById(Guid id)
        {
            var getToDoItem = await _dbContext.ToDoItem.FindAsync(id);

            if (getToDoItem != null)
            {
                return getToDoItem;

            } else throw new Exception("Item not found");
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