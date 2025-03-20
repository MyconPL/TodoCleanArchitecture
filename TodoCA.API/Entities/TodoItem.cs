namespace TodoCA.API.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsComplete { get; set; } = false;

        public void ToggleCompletion()
        {
            IsComplete = !IsComplete;
        }
    }
}