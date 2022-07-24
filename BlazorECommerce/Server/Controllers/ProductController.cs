using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
        var result = await _service.GetProductsAsync();
        return Ok(result);
    }


    [HttpGet("{productId:int}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetSingleProducts(int productId)
    {
        var result = await _service.GetSingleProductAsync(productId);
        return Ok(result);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategoryUrlAsync (string categoryUrl)
    {
        var result = await _service.GetProductsByCategoryAsync(categoryUrl);
        return Ok(result);
    }
}