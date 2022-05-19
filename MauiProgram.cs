using MotivateMe.Services;
using MotivateMe.ViewModels;

namespace MotivateMe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("fa-solid-900.ttf", "Icon");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		var services = builder.Services;

		services.AddSingleton<MainPage>();
		services.AddSingleton<MainPageViewModel>();
		services.AddSingleton<IQuoteService, QuoteService>();

		return builder.Build();
	}
}
