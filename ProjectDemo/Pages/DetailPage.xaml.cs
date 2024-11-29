

using CommunityToolkit.Maui.Behaviors;

namespace ProjectDemo.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;

	public DetailPage(DetailsViewModel detailsViewModel)
	{
		_detailsViewModel = detailsViewModel;
		InitializeComponent();
		BindingContext = _detailsViewModel;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
	}

	async void ImageButton_Clicked(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..", animate: true);
	}

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
		Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior
		{
			StatusBarColor = Colors.DarkGoldenrod, 
			StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent
		});
    }
}