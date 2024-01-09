using GearHonService.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace GearHonService.ViewModels
{
	public partial class RegisterViewModel : BaseViewModel
	{
		[ObservableProperty]
		public string email;
		[ObservableProperty]
		public string password;
		[ObservableProperty]
		public string confirmPassword;

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		private readonly RegisterValidator _validator;

		public RegisterViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;
			_validator = new RegisterValidator();
		}

		[RelayCommand]
		public async Task Register()
		{
			var validationResult = _validator.Validate(this);
			if (!validationResult.IsValid)
			{
				foreach (var error in validationResult.Errors)
				{
					await Shell.Current.DisplayAlert("Validation Error", error.ErrorMessage, "OK");
				}
				return;
			}
			else
			{
				try
				{
					var session = await _supabaseClient.Auth.SignUp(Email, Password);

					await Shell.Current.DisplayAlert("Success", "Account created successfully", "Ok");

					await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
		}
	}
}
