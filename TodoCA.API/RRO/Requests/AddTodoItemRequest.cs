using System.ComponentModel.DataAnnotations;

namespace TodoCA.API.RRO.Requests
{
    public class AddTodoItemRequest
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
