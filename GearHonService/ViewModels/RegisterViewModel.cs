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

		public RegisterViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;
		}

		[RelayCommand]
		public async Task Register()
		{
			if(Password != ConfirmPassword)
			{
				await Shell.Current.DisplayAlert("Error", "Passwords do not match", "Ok");
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
				catch(Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
		}
	}
}
