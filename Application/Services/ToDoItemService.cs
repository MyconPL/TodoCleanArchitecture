using Serilog;
using TodoCA.API.DTO;
using TodoCA.API.Entities;
using TodoCA.API.Persistence;
using TodoCA.API.Repoitories;
using TodoCA.API.Repositories;
using TodoCA.API.RRO.Responses;

namespace TodoCA.API.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;
        private readonly AppDbContext _dbContext;

        public ToDoItemService(IToDoItemRepository toDoItemRepository, AppDbContext dbContext)
        {
            _repository = toDoItemRepository;
            _dbContext = dbContext;
        }

        public async Task AddToDoItem(AddToDoItemDto addToDoItemDto)
        {
            var toDoItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = addToDoItemDto.Title
            };
            Log.Information("Item added with title {Title}", toDoItem.Title);
            await _repository.AddToDoItem(addToDoItemDto);
        }

        public async Task DeleteToDoItem(Guid id)
        {
            await _repository.DeleteToDoItem(id);
        }

        public async Task<TodoItem> GetToDoItemById(Guid id)
        {
            return await _repository.GetToDoItemById(id);
        }

        public async Task<List<TodoItem>> GetToDoItemList()
        {
            return await _repository.GetToDoItemList();
        }

        //public async Task<ToggleCompletionToDoItemResponse> ToggleCompletionToDoItem(Guid id)
        //{
        //    var toggleCompletionToDoItem = await _repository.GetToDoItemById(id);

        //    return new ToggleCompletionToDoItemResponse
        //    {
        //        Id = toggleCompletionToDoItem.Id,
        //        Title = toggleCompletionToDoItem.Title,
        //        IsComplete = toggleCompletionToDoItem.IsComplete,
        //        CompletedAt = toggleCompletionToDoItem.CompletedAt
        //    };
        //}

        public async Task<ToggleCompletionToDoItemResponse> ToggleCompletionToDoItem(ToggleCompletionToDoItemDto request)
        {
            var toggleCompletionToDoItem = await _repository.GetToDoItemById(request.Id);

            if (toggleCompletionToDoItem == null)
            {
                Log.Error("Item not found");
                throw new Exception("Item not found");
            }
            
            toggleCompletionToDoItem.IsComplete = !toggleCompletionToDoItem.IsComplete;
            if (toggleCompletionToDoItem.IsComplete)
            {
                toggleCompletionToDoItem.CompletedAt = DateTime.Now;
                Log.Information("Item completed at {CompletedAt}", toggleCompletionToDoItem.CompletedAt);
            }
            else
            {
                toggleCompletionToDoItem.CompletedAt = null;
                Log.Information("Item {Title} uncompleted");
            }

            await _dbContext.SaveChangesAsync();

            return new ToggleCompletionToDoItemResponse
            {
                Id = toggleCompletionToDoItem.Id,
                Title = toggleCompletionToDoItem.Title,
                IsComplete = toggleCompletionToDoItem.IsComplete,
                CompletedAt = toggleCompletionToDoItem.CompletedAt
            };
        }
    }
}
