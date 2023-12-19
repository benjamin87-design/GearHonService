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

		[ObservableProperty]
		public string pictureName;
		[ObservableProperty]
		public string accessToken;
		[ObservableProperty]
		public string uID;

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public LoginViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			//TODO: Check for internet connection and messege error to user if no connection
		}

		[RelayCommand]
		private async Task Login()
		{
			try
			{
				var response = await _supabaseClient.Auth.SignIn(Email, Password);
				var picturename = response.User.Id.ToString() + ".png";

				PictureName = picturename;
				AccessToken = response.AccessToken;
				UID = response.User.Id.ToString();
				Email = response.User.Email;

				await SetPreferences();

				Shell.Current.FlyoutHeader = new FlyoutHeader();

				await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

				Email = "";
				Password = "";
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private async Task SetPreferences()
		{
			Preferences.Set("profilepicture", PictureName);
			Preferences.Set("token", AccessToken);
			Preferences.Set("uid", UID);
			Preferences.Set("email", Email);
		}

		[RelayCommand]
		private async Task ForgotPassword()
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
