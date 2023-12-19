using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Supabase;

namespace GearHonService
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				// Initialize the .NET MAUI Community Toolkit by adding the below line of code
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleMaterialFont");
				});

			var url = "https://pzvwsjvyfegmnuactovr.supabase.co";
			var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InB6dndzanZ5ZmVnbW51YWN0b3ZyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTcwMjU0MDMsImV4cCI6MjAxMjYwMTQwM30.2hRWxbX3DjveekpQfjcQEz979Z46Q5mk9kVWPy-k-5I";


			var options = new SupabaseOptions
			{
				AutoRefreshToken = true,
				AutoConnectRealtime = true,
				// SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
			};

			builder.Services.AddSingleton(provider => new Supabase.Client(url, key));

			//Singelton for Views
			builder.Services.AddSingleton<LoginPage>();
			builder.Services.AddSingleton<RegisterPage>();
			builder.Services.AddSingleton<HomePage>();
			builder.Services.AddSingleton<CustomerPage>();
			builder.Services.AddSingleton<CustomerDetailPage>();
			builder.Services.AddSingleton<MachinePage>();
			builder.Services.AddSingleton<MachineDetailPage>();
			builder.Services.AddSingleton<TimeSheetPage>();
			builder.Services.AddSingleton<TimeSheetDetailPage>();
			builder.Services.AddSingleton<ServiceReportPage>();
			builder.Services.AddSingleton<AboutPage>();
			builder.Services.AddSingleton<UserSettingPage>();

			//Singelton for ViewModels
			builder.Services.AddSingleton<LoginViewModel>();
			builder.Services.AddSingleton<RegisterViewModel>();
			builder.Services.AddSingleton<HomeViewModel>();
			builder.Services.AddSingleton<CustomerViewModel>();
			builder.Services.AddSingleton<CustomerDetailViewModel>();
			builder.Services.AddSingleton<MachineViewModel>();
			builder.Services.AddSingleton<MachineDetailViewModel>();
			builder.Services.AddSingleton<TimeSheetViewModel>();
			builder.Services.AddSingleton<TimeSheetDetailViewModel>();
			builder.Services.AddSingleton<ServiceReportViewModel>();
			builder.Services.AddSingleton<AboutViewModel>();
			builder.Services.AddSingleton<UserSettingViewModel>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
