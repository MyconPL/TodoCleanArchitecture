using System.ComponentModel.DataAnnotations;

namespace TodoCA.Application.RRO.Requests
{
    public class GetToDoItemByIdRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
