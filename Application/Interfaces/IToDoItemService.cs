using TodoCA.Application.DTO;
using TodoCA.Domain.Entities;
using TodoCA.Application.RRO.Responses;

namespace TodoCA.Application.Interfaces
{
    public interface IToDoItemService
    {
        Task AddToDoItem(AddToDoItemDto request);
        Task<List<TodoItem>> GetToDoItemList();
        Task<TodoItem> GetToDoItemById(Guid id);
        Task DeleteToDoItem(Guid id);
        Task<ToggleCompletionToDoItemResponse> ToggleCompletionToDoItem(ToggleCompletionToDoItemDto request);
    }
}
