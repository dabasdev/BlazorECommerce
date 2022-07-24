namespace BlazorECommerce.Client.Shared;

public partial class ProductList
{
    protected override void OnInitialized()
    {
        Service.ProductChanged += StateHasChanged;
    }

    public void Dispose()
    {
        Service.ProductChanged -= StateHasChanged;
    }
}