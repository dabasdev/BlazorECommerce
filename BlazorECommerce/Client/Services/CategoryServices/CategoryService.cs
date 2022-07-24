namespace BlazorECommerce.Client.Services.CategoryServices;

public class CategoryService  : ICategoryService
{
    private readonly HttpClient _http;
    public List<Category> Categories { get; set; } = new();

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetCategoryAsync()
    {
        var result =
            await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");

        if (result?.Data != null)
            Categories = result.Data;
    }
}