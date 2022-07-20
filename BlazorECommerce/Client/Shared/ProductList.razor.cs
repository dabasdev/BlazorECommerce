using System.Net.Http.Json;
using BlazorECommerce.Shared.Models;

namespace BlazorECommerce.Client.Shared;

public partial class ProductList
{
    private static List<Product> _products = new();


    protected override async Task OnInitializedAsync()
    {
        var result = (await Http.GetFromJsonAsync<List<Product>>("api/product"));

        if (result != null)
            _products = result;
    }
}