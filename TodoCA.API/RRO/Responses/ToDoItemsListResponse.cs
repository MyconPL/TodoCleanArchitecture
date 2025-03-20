namespace TodoCA.API.RRO.Responses
{
    public class ToDoItemListResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
    }
}