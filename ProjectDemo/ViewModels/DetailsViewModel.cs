using System;

namespace ProjectDemo.ViewModels;


[QueryProperty(nameof(Pizza), nameof(Pizza))]
public partial class DetailsViewModel : ObservableObject
{
    public DetailsViewModel()
    {

    }

    [ObservableProperty]
    private Pizza _pizza;

    [RelayCommand]
    private void AddToCart()
    {
        Pizza.CartQuantity++;
    }

    [RelayCommand]
    private void RemoveFormCart()
    {
        if(Pizza.CartQuantity > 0 )
            Pizza.CartQuantity--;
    }

    private async Task ViewCart()
    {
        if(Pizza.CartQuantity > 0)
        {

        }
        else
        {
            
        }
    }
}
