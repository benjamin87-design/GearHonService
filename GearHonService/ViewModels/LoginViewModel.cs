﻿using GearHonService.Views.Navigation;

namespace GearHonService.ViewModels
{
	public partial class LoginViewModel : BaseViewModel
	{
		[ObservableProperty]
		public string email;
		[ObservableProperty]
		public string password;
		[ObservableProperty]
		public string blure;

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public LoginViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;
		}

		private async Task BlurePage()
		{

		}

		[RelayCommand]
		public async Task Login()
		{
			try
			{
				var response = await _supabaseClient.Auth.SignIn(Email, Password);
				var picturename = response.User.Id.ToString() + ".png";

				Preferences.Set("profilepicture", picturename);
				Preferences.Set("token", response.AccessToken);
				Preferences.Set("uid", response.User.Id.ToString());
				Preferences.Set("email", response.User.Email);

				Shell.Current.FlyoutHeader = new FlyoutHeader();

				//go to homepage
				await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		[RelayCommand]
		public async Task ForgotPassword()
		{
			await Task.Delay(1000);
		}

		[RelayCommand]
		public async Task CreateAccount()
		{
			await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
		}
	}
}
