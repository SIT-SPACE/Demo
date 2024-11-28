using UIKit;

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
		var bottom = UIApplication.SharedApplication.Delegate.GetWindow().
		SafeAreaInsets.Bottom;

		bottomBox.Margin = new Thickness(-1, 0, -1, (bottom+1) * -1);
	}
}