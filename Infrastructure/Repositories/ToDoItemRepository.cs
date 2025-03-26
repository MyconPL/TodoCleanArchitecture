using Microsoft.EntityFrameworkCore;
using TodoCA.Application.DTO;
using TodoCA.Application.Interfaces;
using TodoCA.Domain.Entities;
using TodoCA.Infrastructure.Persistence;

namespace TodoCA.Infrastructure.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ToDoItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TodoItem>> GetToDoItemList()
        {
            return await _dbContext.ToDoItem.ToListAsync();
        }


        public async Task DeleteToDoItem(Guid id)
        {
            var deleteToDoItem = await _dbContext.ToDoItem.FindAsync(id);

            if (deleteToDoItem == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Remove(deleteToDoItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TodoItem> ToggleCompletionToDoItem(Guid id)
        {
            var toggleCompletionToDoItem = await _dbContext.ToDoItem.FindAsync(id);

            if (toggleCompletionToDoItem == null)
            {
                throw new Exception("Item not found");
            }

            toggleCompletionToDoItem.IsComplete = !toggleCompletionToDoItem.IsComplete;
            if (toggleCompletionToDoItem.IsComplete)
            {
                toggleCompletionToDoItem.CompletedAt = DateTime.Now;
            }
            else
            {
                toggleCompletionToDoItem.CompletedAt = null;
            }

            await _dbContext.SaveChangesAsync();

            return toggleCompletionToDoItem;
        }

        public async Task AddToDoItem(AddToDoItemDto addToDoItemDto)
        {
            await _dbContext.ToDoItem.AddAsync(new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = addToDoItemDto.Title
            });
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
    }
}