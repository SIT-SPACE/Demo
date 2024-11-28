using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace ProjectDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		AddPizzaServices(builder.Services);

		return builder.Build();
	}

	private static IServiceCollection AddPizzaServices(IServiceCollection services)
	{
		services.AddSingleton<PizzaService>();
		services.AddSingletonWithShellRoute<HomePage,HomeViewModel>(nameof(HomePage));
		services.AddSingletonWithShellRoute<AllPizzasPage,AllPizzaViewModel>(nameof(AllPizzasPage));
		services.AddSingletonWithShellRoute<DetailPage,DetailsViewModel>(nameof(DetailPage));
		return services;
	}
}
