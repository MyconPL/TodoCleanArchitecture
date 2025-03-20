using Microsoft.AspNetCore.Mvc;
using TodoCA.API.DTO;
using TodoCA.API.RRO.Requests;
using TodoCA.API.RRO.Responses;
using TodoCA.API.Services;

namespace TodoCA.API.Controllers
{
    public class TodoItemController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> AddToDo(AddTodoItemRequest newTodo)
        {
            var toDoItemService = new ToDoItemService();
            var addToDoItemDto = new AddToDoItemDto
            {
                Title = newTodo.Title
            };

            await toDoItemService.AddToDoItem(addToDoItemDto);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemListResponse>>> GetAllToDos()
        {
            var toDoItemService = new ToDoItemService();
            var toDoItems = await toDoItemService.GetToDoItems();


            var toDoItemsListResponse = new List<ToDoItemListResponse>();
            foreach (var item in toDoItems)
            {
                toDoItemsListResponse.Add(new ToDoItemListResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    IsComplete = item.IsComplete
                });
            }

            return Ok(toDoItemsListResponse);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetSpecificToDo()
        {
            var toDoItemService = new ToDoItemService();
            var toDoItems = await toDoItemService.GetToDoItems();


            var toDoItemsListResponse = new List<ToDoItemListResponse>();
            foreach (var item in toDoItems)
            {
                toDoItemsListResponse.Add(new ToDoItemListResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    IsComplete = item.IsComplete
                });
            }

            return Ok(toDoItemsListResponse);
        }
    }
}