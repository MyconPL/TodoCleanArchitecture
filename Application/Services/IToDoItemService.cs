using TodoCA.API.DTO;
using TodoCA.API.Entities;
using TodoCA.API.RRO.Responses;

namespace TodoCA.API.Services
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
