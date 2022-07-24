namespace BlazorECommerce.Server.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
    {
        var response = new ServiceResponse<List<Category>>()
        {
            Data = await _context.Categories.ToListAsync(),
        };

        return response;
    }

    public Task<ServiceResponse<List<Category>>> GetAdminCategories()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Category>>> AddCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}