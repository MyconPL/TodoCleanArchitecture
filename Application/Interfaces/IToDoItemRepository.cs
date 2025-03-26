using TodoCA.Application.DTO;
using TodoCA.Domain.Entities;

namespace TodoCA.Application.Interfaces
{
    public interface IToDoItemRepository
    {
        Task AddToDoItem(AddToDoItemDto toDoItem);
        Task<List<TodoItem>> GetToDoItemList();

        Task<TodoItem> GetToDoItemById(Guid id);

        Task DeleteToDoItem(Guid id);

        Task<TodoItem> ToggleCompletionToDoItem(Guid id);
    }
}
