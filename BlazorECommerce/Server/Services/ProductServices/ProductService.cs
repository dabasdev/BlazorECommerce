namespace BlazorECommerce.Server.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>()
        {
            Data = await _context.Products
                .Include(x => x.Category)
                .ToListAsync(),
        };

        return response;
    }

    public async Task<ServiceResponse<Product>> GetSingleProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();

        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);

        if (product == null)
        {
            response.Success = false;
            response.Message = "Sorry , but this product does not exist ... ";
        }
        else
        {
            response.Data = product;
        }

        return response;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
    {
        var response = new ServiceResponse<List<Product>>()
        {
            Data = await _context.Products
                .Include(x => x.Category)
                .Where(x => x.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .ToListAsync(),
        };

        return response;
    }
}