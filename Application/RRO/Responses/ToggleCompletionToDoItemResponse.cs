namespace TodoCA.Application.RRO.Responses
{
    public class ToggleCompletionToDoItemResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
