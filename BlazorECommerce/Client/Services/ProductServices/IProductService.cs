
namespace BlazorECommerce.Client.Services.ProductServices;

public interface IProductService
{
    event Action ProductChanged;
    List<Product> Products { get; set; }
    Task GetProductsAsync(string? categoryUrl = null);
    Task <ServiceResponse<Product>> GetSingleProductAsync(int productId);
}