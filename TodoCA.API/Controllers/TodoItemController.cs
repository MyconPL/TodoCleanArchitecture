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
        public async Task<ActionResult> AddToDoItem(AddToDoItemDto addToDoItemDto)
        {
           await _toDoItemService.AddToDoItem(addToDoItemDto);
           return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemListResponse>>> GetToDoItemList()
        {
            var toDoItems = await _toDoItemService.GetToDoItemList();
            var toDoItemsListResponse = new List<ToDoItemListResponse>();

            return Ok(toDoItemsListResponse);
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<ActionResult<GetToDoItemDto>> GetToDoItemById(Guid Id)
        {
            var request = new Get
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