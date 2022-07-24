using Microsoft.AspNetCore.Components;

namespace BlazorECommerce.Client.Pages;

public partial class ProductDetails
{
    private Product? _product = null;
    private string _message = string.Empty;


    [Parameter] public int Id { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        _message = "Loading Product ...";
        var result = await Service.GetSingleProductAsync(Id);

        if (!result.Success)
        {
            _message = result.Message;
            return;
        }

        _product = result.Data;
    }
}