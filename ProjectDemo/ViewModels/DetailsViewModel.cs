namespace ProjectDemo.ViewModels;

[QueryProperty(nameof(Pizza), nameof(Pizza))]
public partial class DetailsViewModel : ObservableObject, IDisposable
{
    private readonly CartViewModel _cartViewModel;
    public DetailsViewModel(CartViewModel cartViewModel)
    {
        _cartViewModel = cartViewModel;
        _cartViewModel.CartCleared += OnCartCleared;
        _cartViewModel.CartItemRemoved += OnCartItemRemoved;
        _cartViewModel.CartItemUpdated += OnCartItemUpdated;
    }

    private void OnCartCleared(object? _, EventArgs e) => Pizza.CartQuantity = 0;

    private void OnCartItemRemoved(object? _, Pizza p) => 
        OnCartItemChanged(p, 0);
    private void OnCartItemUpdated(object? _, Pizza p) => 
        OnCartItemChanged(p, p.CartQuantity);
    private void OnCartItemChanged(Pizza p, int quantity)
    {
        if(p.Name == Pizza.Name)
        {
            Pizza.CartQuantity = quantity;
        }
    }

    [ObservableProperty]
    private Pizza _pizza;

    [RelayCommand]
    private void AddToCart()
    {
        Pizza.CartQuantity++;
        _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
    }

    [RelayCommand]
    private void RemoveFormCart()
    {
        if(Pizza.CartQuantity > 0 )
        {
            Pizza.CartQuantity--;
            _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
        }
    }

    [RelayCommand]
    private async Task ViewCart()
    {
        if(Pizza.CartQuantity > 0)
        {
            await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
        }
        else
        {
            await Shell.Current.DisplayAlert("Try Again", "Please select the quantity using plus (+) button","OK");

        }
    }

    public void Dispose()
    {
    _cartViewModel.CartCleared -= OnCartCleared;
    _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
    _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
    }
}
