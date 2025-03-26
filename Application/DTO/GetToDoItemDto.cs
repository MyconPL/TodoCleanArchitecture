namespace TodoCA.Application.DTO
{
    public class GetToDoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsComplete { get; set; }
    }
}
