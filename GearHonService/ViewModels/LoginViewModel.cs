using GearHonService.Views.Navigation;

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

			//TODO: Check for internet connection and messege error to user if no connection
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
			bool result = await Shell.Current.DisplayAlert("Forgot Password", "Are you sure you want to reset your password?", "Yes", "No");
			if(result)
			{
				//check email entry
				if(Email != null)
				{
					await _supabaseClient.Auth.ResetPasswordForEmail(Email);
					await Shell.Current.DisplayAlert("Forgot Password", "Reset link sent to your email", "Ok");
				}
				else
				{
					await Shell.Current.DisplayAlert("Error!", "Please enter your email address.", "Ok");
				}
			}
			else
			{
				//do nothing
			}
		}

		[RelayCommand]
		public async Task CreateAccount()
		{
			await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
		}
	}
}
