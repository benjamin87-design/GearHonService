using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Supabase;

namespace GearHonService.ViewModels
{
	public partial class LoginViewModel : BaseViewModel
	{
		[ObservableProperty]
		public string email;
		[ObservableProperty]
		public string password;

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public LoginViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;
		}

		[RelayCommand]
		public async Task Login()
		{
			try
			{
				var response = await _supabaseClient.Auth.SignIn(Email, Password);

				//Save token and uid to preferences for later use
				Preferences.Set("token", response.AccessToken);
				Preferences.Set("uid", response.User.Id.ToString());
				Preferences.Set("email", response.User.Email);

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
