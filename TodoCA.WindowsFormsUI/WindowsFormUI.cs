using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoCA.WindowsFormsUI;


namespace TodoCA.WindowsFormsUI
{
    public partial class WinForm : Form
    {
        private readonly HttpClient _httpClient;

        public WinForm(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new { Title = txtTitle.Text };
            var response = await _httpClient.PostAsJsonAsync("ToDoItem", newItem);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item added successfully!");
                await LoadToDoItems();
            }
            else
            {
                MessageBox.Show("Error adding item.");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTodos.SelectedItem is TodoItem selectedItem)
            {
                var response = await _httpClient.DeleteAsync($"ToDoItem/{selectedItem.Id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item deleted successfully!");
                    await LoadToDoItems();
                }
                else
                {
                    MessageBox.Show("Error deleting item.");
                }
            }
        }

        private async void btnToggle_Click(object sender, EventArgs e)
        {
            if (listBoxTodos.SelectedItem is ToDoItem selectedTodo)
            {
                selectedTodo.IsComplete = !selectedTodo.IsComplete; // Zmieñ stan
                var response = await _httpClient.PutAsJsonAsync($"todoitems/{selectedTodo.Id}", selectedTodo);

                if (response.IsSuccessStatusCode)
                {
                    btnLoad_Click(null, null); // Odœwie¿ listê
                }
                else
                {
                    MessageBox.Show("Error toggling completion.");
                }
            }
            else
            {
                MessageBox.Show("Select a task to toggle.");
            }
        }


        private async void WinForm_Load(object sender, EventArgs e)
        {
            await LoadTodos();
        }

        private async Task LoadTodos()
        {
            try
            {
                var todos = await _httpClient.GetFromJsonAsync<ToDoItem[]>("api/todoitems");
                listBoxTodos.DataSource = todos;
                listBoxTodos.DisplayMember = "Title";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading todos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            
        }
    }
}