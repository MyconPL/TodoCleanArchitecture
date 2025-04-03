using TodoCA.Application.DTO;

namespace TodoCA.WindowsFormsUI
{
    public partial class TodoApp : Form
    {
        private readonly ToDoApiClient _apiClient;

        public TodoApp(ToDoApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            LoadTodos();
        }

        private async void LoadTodos()
        {
            var todos = await _apiClient.GetToDoItemsAsync();
            listBoxTodos.DataSource = todos;
            listBoxTodos.DisplayMember = "Title";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await _apiClient.AddToDoItemAsync(txtTitle.Text);
            LoadTodos();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await _apiClient.DeleteToDoItemAsync(sender.Id);
            LoadTodos();
        }

        private async void btnToggle_Click(object sender, EventArgs e)
        {
            if (listBoxTodos.SelectedItem is ToggleCompletionToDoItemDto selectedTodo)
            {
                await _apiClient.ToggleCompletionToDoItemAsync(selectedTodo.Id);
                LoadTodos();
            }
        }
    }
}
