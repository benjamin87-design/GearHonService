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

		public AboutViewModel()
		{
			UserEmail = Preferences.Get("email", "");
			AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			PhoneNumber = "Phone" + " " + "86-150-2214-3391";
			Email = "Email" + " " + "benjamin.fehr@praewema.de";

			//TODO: Get total machines, customers, and hours from database
			//TODO: Add Setup user 
			//TODO: Add copy for Version, so user can easily copy version info
		}
	}
}
