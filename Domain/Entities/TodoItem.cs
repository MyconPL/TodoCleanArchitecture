namespace TodoCA.API.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsComplete { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
    }
}