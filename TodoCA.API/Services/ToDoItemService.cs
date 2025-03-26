using TodoCA.API.DTO;
using TodoCA.API.Entities;
using TodoCA.API.Repoitories;
using TodoCA.API.Repositories;
using TodoCA.API.Persistence;
using TodoCA.API.RRO.Responses;
using TodoCA.API.RRO.Requests;

namespace TodoCA.API.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;
        private readonly AppDbContext _dbContext;


        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _repository = toDoItemRepository;
        }

        public async Task AddToDoItem(AddToDoItemDto addToDoItemDto)
        {
            var toDoItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = addToDoItemDto.Title
            };

            var toDoItemRepository = new ToDoItemRepository();
            await toDoItemRepository.ToDoItemAdd(toDoItem);
        }

        public async Task DeleteToDoItem(Guid id)
        {
            await _repository.DeleteToDoItem(id);
        }

        public async Task GetToDoItemById(Guid id)
        {
            await _repository.GetToDoItemById(id);
        }

        public async Task<List<TodoItem>> GetToDoItemList()
        {
            return await _repository.GetToDoItemList();
        }

        public Task<ToggleCompletionToDoItemResponse> ToggleCompletionToDoItem(ToggleCompletionToDoItemRequest request)
        {
            var toggleCompletionToDoItem = _repository.GetToDoItemById(request.Id);
            if (toggleCompletionToDoItem == null)
            {
                throw new System.Exception("Item not found");
            }
        }

        Task<TodoItem> IToDoItemService.GetToDoItemById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
