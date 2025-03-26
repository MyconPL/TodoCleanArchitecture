using Microsoft.AspNetCore.Mvc;
using TodoCA.API.DTO;
using TodoCA.API.RRO.Requests;
using TodoCA.API.RRO.Responses;
using TodoCA.API.Services;

namespace TodoCA.API.Controllers
{

    [ApiController]
    [Route("api/todoitems")]
    public class TodoItemController : Controller
    {
        private readonly IToDoItemService _toDoItemService;
        public TodoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpPost]
        public async Task<ActionResult> AddToDoItem(AddTodoItemRequest data)
        {

           await _toDoItemService.AddToDoItem(new AddToDoItemDto { Title = data.Title});
           return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemListResponse>>> GetToDoItemList()
        {

            var toDoItems = await _toDoItemService.GetToDoItemList();
            var toDoItemsListResponse = toDoItems.Select(x => new ToDoItemListResponse
            {
                Id = x.Id,
                Title = x.Title,
                IsComplete = x.IsComplete
            }).ToList();

            return Ok(toDoItemsListResponse);
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<ActionResult<GetToDoItemByIdResponse>> GetToDoItemById(Guid Id)
        {
            var result = await _toDoItemService.GetToDoItemById(Id);
            return Ok(new GetToDoItemByIdResponse
            {
                Id = result.Id,
                Title = result.Title,
                IsComplete = result.IsComplete,
                CreatedAt = result.CreatedAt,
                CompletedAt = result.CompletedAt
            });
        }

        [HttpPut]
        [Route("{Id}")]

        public async Task<ActionResult> ToggleCompletionToDoItem(Guid Id)
        {
            var toggleCompletionToDoItemDto = new ToggleCompletionToDoItemDto
            {
                Id = Id
            };
            await _toDoItemService.ToggleCompletionToDoItem(Id);
            return Ok();
        }


        [HttpDelete]
        [Route("{Id}")]

        public async Task<ActionResult> DeleteToDoItem(Guid Id)
        {
            await _toDoItemService.DeleteToDoItem(Id);
            return Ok();
        }
    }
}