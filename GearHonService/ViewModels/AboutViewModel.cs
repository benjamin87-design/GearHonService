using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
	public partial class AboutViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string userEmail;
		[ObservableProperty]
		private string appVersion;
		[ObservableProperty]
		private string totalMachines;
		[ObservableProperty]
		private string totalCustomers;
		[ObservableProperty]
		private string totalHours;
		[ObservableProperty]
		private string phoneNumber;
		[ObservableProperty]
		private string email;

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public AboutViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			GetStrings();
			GetMachine();
			GetCustomer();
			GetWorkingHours();
		}

		[RelayCommand]
		private async Task GoToUserSetting()
		{
			await Shell.Current.GoToAsync($"//{nameof(UserSettingPage)}");
		}

		public async Task GetMachine()
		{
			try
			{
				var result = await _supabaseClient.From<MachineModel>().Get();
				TotalMachines = result.Models.Count().ToString();
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		public async Task GetCustomer()
		{
			try
			{
				var result = await _supabaseClient.From<CustomerModel>().Get();
				TotalCustomers = result.Models.Count().ToString();
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		private async Task GetWorkingHours()
		{
			try
			{
				var result = await _supabaseClient.From<ServiceReportModel>().Get();
				var total = result.Models.Sum(x => Convert.ToInt32(x.TotalHour)).ToString();
				TotalHours = total;
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}
		public void GetStrings()
		{
			ClearStrings();

			UserEmail = Preferences.Get("email", "");
			AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			PhoneNumber = "Phone:" + " " + "86-150-2214-3391";
			Email = "Email:" + " " + "benjamin.fehr@praewema.de";
		}

		private void ClearStrings()
		{
			UserEmail = "";
			AppVersion = "";
			PhoneNumber = "";
			Email = "";
		}
	}
}
