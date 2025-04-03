using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TodoCA.WindowsFormsUI
{
    public partial class WinForm : Form
    {
        private readonly HttpClient _httpClient;

        public WinForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7210/api/") };
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
            if (lstToDoItems.SelectedItem is TodoItem selectedItem)
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
            if (lstToDoItems.SelectedItem is TodoItem selectedItem)
            {
                var response = await _httpClient.PutAsJsonAsync($"ToDoItem/{selectedItem.Id}/toggle", new { });
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item toggled successfully!");
                    await LoadToDoItems();
                }
                else
                {
                    MessageBox.Show("Error toggling item.");
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadToDoItems();
        }
    }
}