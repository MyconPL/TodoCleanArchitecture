using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoCA.Application.RRO.Responses;

public class ToDoApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl = "https://localhost:7210/api/todoitems"; // URL do API

    public ToDoApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ToDoItemListResponse>> GetToDoItemsAsync()
    {
        var response = await _httpClient.GetAsync(_apiBaseUrl);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<ToDoItemListResponse>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task AddToDoItemAsync(string title)
    {
        var newTodo = new { Title = title };
        var json = JsonSerializer.Serialize(newTodo);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_apiBaseUrl, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteToDoItemAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task ToggleCompletionToDoItemAsync(Guid id)
    {
        var response = await _httpClient.PutAsync($"{_apiBaseUrl}/{id}/toggle", null);
        response.EnsureSuccessStatusCode();
    }
}
