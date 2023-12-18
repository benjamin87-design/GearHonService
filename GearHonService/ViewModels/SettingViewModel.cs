namespace GearHonService.ViewModels
{
	public partial class SettingViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string uID;
		[ObservableProperty]
		private string pictureFileName;
		[ObservableProperty]
		private string pictureFilePath;

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public SettingViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			//get the UID from preferences
			UID = Preferences.Get("UID", "");
		}

		[RelayCommand]
		public async void UploadPictureCommand()
		{
			await CreatePictureFileName();
			await GetPictureFilePath();
			await UploadPictureToSupabase();
		}

		public async Task CreatePictureFileName()
		{
			try
			{
				PictureFileName = UID + ".png";
			} 
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");	
			}
		}

		public async Task GetPictureFilePath()
		{
			try
			{
				var result = await FilePicker.PickAsync(new PickOptions
				{
					PickerTitle = "Please select a picture",
					FileTypes = FilePickerFileType.Images,
				});

				if (result != null)
				{
					var stream = await result.OpenReadAsync();
					var path = result.FullPath;
					// Use the path as needed
				}
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		public async Task UploadPictureToSupabase()
		{

			try
			{
				var imagePath = Path.Combine(PictureFilePath, PictureFileName);

				await _supabaseClient.Storage
				  .From("UserProfilePic")
				  .Upload(imagePath, PictureFileName);

				await Shell.Current.DisplayAlert("Success", "Picture uploaded", "OK");
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}
	}
}
