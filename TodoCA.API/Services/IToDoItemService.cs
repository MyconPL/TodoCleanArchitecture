using TodoCA.API.DTO;
using TodoCA.API.Entities;

namespace TodoCA.API.Services
{
    public interface IToDoItemService
    {
        Task AddToDoItem(AddToDoItemDto request);
        Task<List<TodoItem>> GetToDoItemList();
        Task<TodoItem> GetToDoItemById(Guid id);
        Task UpdateToDoItem(Guid id, UpdateToDoItemDto request);
    }
}
