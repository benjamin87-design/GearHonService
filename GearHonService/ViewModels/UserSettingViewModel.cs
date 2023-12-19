using Supabase.Gotrue;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
	public partial class UserSettingViewModel : BaseViewModel
	{
		[ObservableProperty]
		private int iD;
		[ObservableProperty]
		private string userName;
		[ObservableProperty]
		private string streetName;
		[ObservableProperty]
		private string streetNumber;
		[ObservableProperty]
		private string zIPCode;
		[ObservableProperty]
		private string city;
		[ObservableProperty]
		private string country;
		[ObservableProperty]
		private string phoneNumber;
		[ObservableProperty]
		private string email;
		[ObservableProperty]
		private string userId;

		[ObservableProperty]
		private string pictureFileName;
		[ObservableProperty]
		private string pictureFilePath;

		[ObservableProperty]
		private ObservableCollection<UserModel> users;

		private readonly Supabase.Client _supabaseClient;

		public UserSettingViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			Users = new ObservableCollection<UserModel>();

			GetUser();
		}

		private async Task GetUser()
		{
			var result = await _supabaseClient.From<UserModel>().Get();
			Users.Clear();
			foreach (var user in result.Models)
			{
				Users.Add(user);
			}
			DisplayUser();
		}

		private void DisplayUser()
		{
			var userUID = Preferences.Get("uid", "");
			var userEmail = Preferences.Get("email", "");
			var user = Users.Where(x => x.UserId == userUID).FirstOrDefault();

			if (user != null)
			{
				UserName = user.UserName;
				StreetName = user.StreetName;
				StreetNumber = user.StreetNumber;
				ZIPCode = user.ZIPCode;
				City = user.City;
				Country = user.Country;
				PhoneNumber = user.Phone;
				Email = user.Email;
				UserId= user.UserId;
			}
			else
			{
				Email = userEmail;
				UserId = userUID;
			}
		}

		[RelayCommand]
		private async Task UpdateUser()
		{
			var userUID = Preferences.Get("uid", "");
			var user = Users.Where(x => x.UserId == userUID).FirstOrDefault();

			if (user == null)
			{
				var newUser = new UserModel()
				{
					UserName = UserName,
					StreetName = StreetName,
					StreetNumber = StreetNumber,
					ZIPCode = ZIPCode,
					City = City,
					Country = Country,
					Phone = PhoneNumber,
					Email = Email,
					UserId = userUID
				};

				try
				{
					var insertResult = await _supabaseClient
					.From<UserModel>()
					.Insert(newUser);

					await Shell.Current.DisplayAlert("Success", "User created successfully", "Ok");
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
				}
			}
			else
			{
				var updatedUser = new UserModel()
				{
					UserName = UserName,
					StreetName = StreetName,
					StreetNumber = StreetNumber,
					ZIPCode = ZIPCode,
					City = City,
					Country = Country,
					Phone = PhoneNumber,
					Email = Email
				};

				try
				{
					var update = await _supabaseClient
						.From<UserModel>()
						.Where(x => x.ID == ID)
						.Set(x => x.UserName, UserName)
						.Set(x => x.StreetName, StreetName)
						.Set(x => x.StreetNumber, StreetNumber)
						.Set(x => x.ZIPCode, ZIPCode)
						.Set(x => x.City, City)
						.Set(x => x.Country, Country)
						.Set(x => x.Phone, PhoneNumber)
						.Set(x => x.Email, Email)
						.Update();

					await Shell.Current.DisplayAlert("Success", "User updated successfully", "Ok");
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
				}
			}
		}

		[RelayCommand]
		private async Task ChangeUser()
		{
			try
			{
				await _supabaseClient.Auth.SignOut();
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}

			Preferences.Clear();
			Users.Clear();
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
		}

		[RelayCommand]
		public async Task UploadPicture()
		{
			await CreatePictureFileName();
			await GetPictureFilePath();
			await UploadPictureToSupabase();
		}

		public async Task CreatePictureFileName()
		{
			try
			{
				PictureFileName = Preferences.Get("uid", "") + ".png";
			}
			catch (Exception ex)
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
				}
			}
			catch (Exception ex)
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
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}
	}
}
