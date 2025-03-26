using System.ComponentModel.DataAnnotations;

namespace TodoCA.API.RRO.Requests
{
    public class GetToDoItemByIdRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
