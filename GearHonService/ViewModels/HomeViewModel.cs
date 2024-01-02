using System.Diagnostics;

namespace GearHonService.ViewModels
{
	public partial class HomeViewModel : BaseViewModel
	{
		public HomeViewModel()
		{
			//TODO: Link button open edge and go to website www.praewema.de
		}

		[RelayCommand]
		private async Task GoToCompanyHomePage()
		{
			bool answer = await Shell.Current.DisplayAlert("Warning!", "You are about to leave this app. Do you want to continue?", "Yes", "No");
			if (answer)
			{
				await Launcher.OpenAsync(new Uri("https://www.dvs-technology.com/praewema-antriebstechnik/"));
			}
			else
			{
				//do nothing
			}
		}
	}
}
