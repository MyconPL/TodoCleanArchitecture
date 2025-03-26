namespace TodoCA.API.RRO.Responses
{
    public class AddToDoItemResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
