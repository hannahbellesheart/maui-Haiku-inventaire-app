using BarcodeScanner.Mobile;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Haiku.Mobile.Inventaire;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
            }).ConfigureMauiHandlers(handlers =>
            {
                // Add the handlers
                handlers.AddBarcodeScannerHandler();
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ArticlesService>();
        builder.Services.AddSingleton<ArticlesViewModel>();
        builder.Services.AddSingleton<ArticlesPage>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<PopupPage>();

        builder.Services.AddTransient<AddArticlePage>();
        builder.Services.AddTransient<BarcodeScanPage>();
        Methods.AskForRequiredPermission();

        return builder.Build();
    }
}