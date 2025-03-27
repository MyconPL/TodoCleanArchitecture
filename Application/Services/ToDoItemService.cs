using Serilog;
using TodoCA.Application.DTO;
using TodoCA.Application.Interfaces;
using TodoCA.Application.RRO.Responses;
using TodoCA.Domain.Entities;

namespace TodoCA.Application.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;
        private readonly ILogger _logger;

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

            var toggleCompletionToDoItem = new { TodoItem = await _repository.GetToDoItemById(request.Id) };

            if (toggleCompletionToDoItem == null)
            {
                _logger.Information("Cannot toggle completion. Item not found");
                return null;
            }
            else
            {
                var toggloCompletionToDoItemResponse = await _repository.ToggleCompletionToDoItem(request.Id);
                return new ToggleCompletionToDoItemResponse
                {
                    Id = toggloCompletionToDoItemResponse.Id,
                    Title = toggloCompletionToDoItemResponse.Title,
                    IsComplete = toggloCompletionToDoItemResponse.IsComplete,
                    CompletedAt = toggloCompletionToDoItemResponse.CompletedAt
                };
            }

        }
    }
}
