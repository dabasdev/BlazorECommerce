﻿namespace BlazorECommerce.Server.Services.ProductServices;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<ServiceResponse<Product>> GetSingleProductAsync(int productId);
    Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
}