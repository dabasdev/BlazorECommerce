namespace BlazorECommerce.Client.Services.ProductServices;

public class ProductService  : IProductService
{
    private readonly HttpClient _http;
    public event Action? ProductChanged;
    public List<Product> Products { get; set; } = new();

    public ProductService(HttpClient http)
    {
        _http = http;
    }
    public async Task GetProductsAsync(string? categoryUrl = null)
    {
        var rout = categoryUrl == null ? "api/product" : $"api/product/category/{categoryUrl}";

        var result = 
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>(rout);

        if (result?.Data != null)
            Products = result.Data;

        ProductChanged?.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetSingleProductAsync(int productId)
    {
        var result =
            await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");

        return result;
    }
}