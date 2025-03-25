using TodoCA.API.DTO;
using TodoCA.API.Entities;
using TodoCA.API.Repoitories;

namespace TodoCA.API.Services
{
    public class ToDoItemService : IToDoItemService
    {
        //public async Task AddToDoItem(AddToDoItemDto addToDoItemDto)
        //{
        //    var toDoItem = new TodoItem
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = addToDoItemDto.Title
        //    };

        //    var toDoItemRepository = new ToDoItemRepository();
        //    await toDoItemRepository.ToDoItemAdd(toDoItem);
        //}

        //public async Task<List<TodoItem>> GetToDoItems()
        //{
        //    var toDoItemRepository = new ToDoItemRepository();
        //    var toDoItemList = await toDoItemRepository.GetToDoItemList();

        //    return toDoItemList;
        //}
        public Task AddToDoItem(AddToDoItemDto request)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetToDoItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetToDoItemList()
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoItem(Guid id, UpdateToDoItemDto request)
        {
            
        }
    }
}
