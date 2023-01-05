
/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-windows10.0.19041.0)'
Before:
using Microsoft.AspNetCore.Components.WebView.Maui;
using BikeSpareInventoryManager.Data;
using MudBlazor.Services;
After:
using BikeSpareInventoryManager.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using MudBlazor.Services;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-ios)'
Before:
using Microsoft.AspNetCore.Components.WebView.Maui;
using BikeSpareInventoryManager.Data;
using MudBlazor.Services;
After:
using BikeSpareInventoryManager.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using MudBlazor.Services;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-android)'
Before:
using Microsoft.AspNetCore.Components.WebView.Maui;
using BikeSpareInventoryManager.Data;
using MudBlazor.Services;
After:
using BikeSpareInventoryManager.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using MudBlazor.Services;
*/
using BikeSpareInventoryManager.Data;
using MudBlazor.Services;

namespace BikeSpareInventoryManager;

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
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<InventoryService>();
        builder.Services.AddSingleton<InventoryLogService>();
        builder.Services.AddSingleton<FilesUtils>();
        builder.Services.AddSingleton<HelperService>();

        return builder.Build();
    }
}
