using CommunityToolkit.Maui;
using GearHonService.Services;
using Microsoft.Extensions.Logging;
using Supabase;

namespace GearHonService
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var url = "https://pzvwsjvyfegmnuactovr.supabase.co";
			var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InB6dndzanZ5ZmVnbW51YWN0b3ZyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTcwMjU0MDMsImV4cCI6MjAxMjYwMTQwM30.2hRWxbX3DjveekpQfjcQEz979Z46Q5mk9kVWPy-k-5I";

			var options = new SupabaseOptions
			{
				AutoRefreshToken = true,
				AutoConnectRealtime = true,
				// SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
			};

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleMaterialFont");
				});

			builder.Services.AddSingleton<LoginViewModel>();
			builder.Services.AddSingleton<LoginPage>();
			builder.Services.AddSingleton<RegisterViewModel>();
			builder.Services.AddSingleton<RegisterPage>();
			builder.Services.AddSingleton<HomeViewModel>();
			builder.Services.AddSingleton<HomePage>();
			builder.Services.AddSingleton<ContractorViewModel>();
			builder.Services.AddSingleton<ContractorPage>();
			builder.Services.AddSingleton<ContractorDetailViewModel>();
			builder.Services.AddSingleton<ContractorDetailPage>();
			builder.Services.AddSingleton<CustomerViewModel>();
			builder.Services.AddSingleton<CustomerPage>();
			builder.Services.AddSingleton<CustomerDetailViewModel>();
			builder.Services.AddSingleton<CustomerDetailPage>();
			builder.Services.AddSingleton<ExpenseViewModel>();
			builder.Services.AddSingleton<ExpensePage>();
			builder.Services.AddSingleton<InvoiceViewModel>();
			builder.Services.AddSingleton<InvoicePage>();
			builder.Services.AddSingleton<MachineViewModel>();
			builder.Services.AddSingleton<MachinePage>();
			builder.Services.AddSingleton<MachineDetailViewModel>();
			builder.Services.AddSingleton<MachineDetailPage>();
			builder.Services.AddSingleton<TimeSheetViewModel>();
			builder.Services.AddSingleton<TimeSheetPage>();
			builder.Services.AddSingleton<TimeSheetDetailViewModel>();
			builder.Services.AddSingleton<TimeSheetDetailPage>();
			builder.Services.AddSingleton<ServiceReportViewModel>();
			builder.Services.AddSingleton<ServiceReportPage>();
			builder.Services.AddSingleton<AboutViewModel>();
			builder.Services.AddSingleton<AboutPage>();
			builder.Services.AddSingleton<UserSettingViewModel>();
			builder.Services.AddSingleton<UserSettingPage>();

			builder.Services.AddSingleton(provider => new Supabase.Client(url, key));

			builder.Services.AddSingleton<CurrencyLoader>();

			return builder.Build();
		}
	}
}
