using Microsoft.AspNetCore.Components.WebView.Maui;
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
