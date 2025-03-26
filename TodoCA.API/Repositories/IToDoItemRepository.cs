using TodoCA.API.DTO;
using TodoCA.API.Entities;
using TodoCA.API.Repoitories;
using TodoCA.API.Persistence;

namespace TodoCA.API.Repositories
{
    public interface IToDoItemRepository
    {
        Task AddToDoItem(AddToDoItemDto toDoItem);
        Task<List<TodoItem>> GetToDoItemList();

        Task GetToDoItemById(Guid id);

        Task DeleteToDoItem(Guid id);

        Task ToggleCompletionToDoItem(Guid id);
    }
}
