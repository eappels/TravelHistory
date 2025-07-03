using Microsoft.Extensions.Logging;
using TravelHistoryApp.ViewModels;
using TravelHistoryApp.Views;

namespace TravelHistoryApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MapViewModel>();
        builder.Services.AddTransient<MapView>(s => new MapView()
        {
            BindingContext = s.GetRequiredService<MapViewModel>()
        });

        return builder.Build();
    }
}