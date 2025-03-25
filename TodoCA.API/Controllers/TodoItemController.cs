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
        private readonly ToDoItemService _toDoItemService;

        public TodoItemController(ToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpPost]
        public async Task<ActionResult> AddToDo(AddTodoItemRequest newTodo)
        {
            var addToDoItemDto = new AddToDoItemDto
            {
                Title = newTodo.Title
            };

            await _toDoItemService.AddToDoItem(addToDoItemDto);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemListResponse>>> GetAllToDos()
        {
            var toDoItems = await _toDoItemService.GetToDoItemList();
            var toDoItemsListResponse = new List<ToDoItemListResponse>();

            return Ok(toDoItemsListResponse);
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<ActionResult<GetToDoItemDto>> GetToDoItem(Guid Id)
        {
            var item = await _toDoItemService.GetToDoItemById(Id);
            
            if(item == null)
            {
                return NotFound();
            }

            var response = new GetToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                IsComplete = item.IsComplete,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{Id}")]

        public async Task<ActionResult> UpdateToDoItem(Guid Id, UpdateToDoItemRequest updateToDoItemRequest)
        {
            var updateToDoItemDto = new UpdateToDoItemDto
            {
                Id = Id
            };
            await _toDoItemService.UpdateToDoItem(updateToDoItemDto);
            return Ok();
        }


        [HttpDelete]
        [Route("{Id}")]
    }
}