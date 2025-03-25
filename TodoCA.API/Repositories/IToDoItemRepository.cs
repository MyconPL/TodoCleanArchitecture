using TodoCA.API.Entities;

namespace TodoCA.API.Repositories
{
    public interface IToDoItemRepository
    {
        Task ToDoItemAdd(TodoItem toDoItem);
        Task<List<TodoItem>> GetToDoItemList();

        Task<TodoItem> GetToDoItemById(Guid id);
    }
}
