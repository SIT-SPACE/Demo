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

}
