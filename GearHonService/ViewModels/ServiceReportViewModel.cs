using ClosedXML.Excel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;

namespace GearHonService.ViewModels
{
	public partial class ServiceReportViewModel : BaseViewModel
	{
		//Strings
		[ObservableProperty]
		private string folderPath;
		[ObservableProperty]
		private string customerName;
		[ObservableProperty]
		private string machineNumber;
		[ObservableProperty]
		private string uID;
		[ObservableProperty]
		private DateTime serviceStartDate;
		[ObservableProperty]
		private DateTime serviceEndDate;
		[ObservableProperty]
		private string userName;
		[ObservableProperty]
		private string userLocation;
		[ObservableProperty]
		private string customerLocation;

		#region Strings for days and time
		[ObservableProperty] private string day1date;
		[ObservableProperty] private string day2date;
		[ObservableProperty] private string day3date;
		[ObservableProperty] private string day4date;
		[ObservableProperty] private string day5date;
		[ObservableProperty] private string day6date;
		[ObservableProperty] private string day7date;
		[ObservableProperty] private string day8date;
		[ObservableProperty] private string day9date;
		[ObservableProperty] private string day10date;
		[ObservableProperty] private string day11date;
		[ObservableProperty] private string day12date;
		[ObservableProperty] private string day13date;
		[ObservableProperty] private string day14date;

		[ObservableProperty] private string day1name;
		[ObservableProperty] private string day2name;
		[ObservableProperty] private string day3name;
		[ObservableProperty] private string day4name;
		[ObservableProperty] private string day5name;
		[ObservableProperty] private string day6name;
		[ObservableProperty] private string day7name;
		[ObservableProperty] private string day8name;
		[ObservableProperty] private string day9name;
		[ObservableProperty] private string day10name;
		[ObservableProperty] private string day11name;
		[ObservableProperty] private string day12name;
		[ObservableProperty] private string day13name;
		[ObservableProperty] private string day14name;

		[ObservableProperty] private string day1WorkTime;
		[ObservableProperty] private string day1TravelTime;
		[ObservableProperty] private string day1TotalTime;
		[ObservableProperty] private string day2WorkTime;
		[ObservableProperty] private string day2TravelTime;
		[ObservableProperty] private string day2TotalTime;
		[ObservableProperty] private string day3WorkTime;
		[ObservableProperty] private string day3TravelTime;
		[ObservableProperty] private string day3TotalTime;
		[ObservableProperty] private string day4WorkTime;
		[ObservableProperty] private string day4TravelTime;
		[ObservableProperty] private string day4TotalTime;
		[ObservableProperty] private string day5WorkTime;
		[ObservableProperty] private string day5TravelTime;
		[ObservableProperty] private string day5TotalTime;
		[ObservableProperty] private string day6WorkTime;
		[ObservableProperty] private string day6TravelTime;
		[ObservableProperty] private string day6TotalTime;
		[ObservableProperty] private string day7WorkTime;
		[ObservableProperty] private string day7TravelTime;
		[ObservableProperty] private string day7TotalTime;
		[ObservableProperty] private string day8WorkTime;
		[ObservableProperty] private string day8TravelTime;
		[ObservableProperty] private string day8TotalTime;
		[ObservableProperty] private string day9WorkTime;
		[ObservableProperty] private string day9TravelTime;
		[ObservableProperty] private string day9TotalTime;
		[ObservableProperty] private string day10WorkTime;
		[ObservableProperty] private string day10TravelTime;
		[ObservableProperty] private string day10TotalTime;
		[ObservableProperty] private string day11WorkTime;
		[ObservableProperty] private string day11TravelTime;
		[ObservableProperty] private string day11TotalTime;
		[ObservableProperty] private string day12WorkTime;
		[ObservableProperty] private string day12TravelTime;
		[ObservableProperty] private string day12TotalTime;
		[ObservableProperty] private string day13WorkTime;
		[ObservableProperty] private string day13TravelTime;
		[ObservableProperty] private string day13TotalTime;
		[ObservableProperty] private string day14WorkTime;
		[ObservableProperty] private string day14TravelTime;
		[ObservableProperty] private string day14TotalTime;
		#endregion

		//Lists
		[ObservableProperty]
		private ObservableCollection<UserModel> users;
		[ObservableProperty]
		private ObservableCollection<CustomerModel> customers;
		[ObservableProperty]
		private ObservableCollection<TimeSheetModel> timeSheets;
		[ObservableProperty]
		private ObservableCollection<TimeSheetModel> workingHours;
		[ObservableProperty]
		private ObservableCollection<TimeSheetModel> travelHours;

		//Selected
		private CustomerModel selectedCustomer;
		public CustomerModel SelectedCustomer
		{
			get { return selectedCustomer; }
			set { selectedCustomer = value; }
		}

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public ServiceReportViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			//datepicker default values
			ServiceStartDate = DateTime.Now;
			ServiceEndDate = DateTime.Now;

			Users = new ObservableCollection<UserModel>();
			Customers = new ObservableCollection<CustomerModel>();
			TimeSheets = new ObservableCollection<TimeSheetModel>();
			WorkingHours = new ObservableCollection<TimeSheetModel>();
			TravelHours = new ObservableCollection<TimeSheetModel>();

			GetAllCustomers();
			GetAllTimeSheets();
			GetUserInformation();
		}

		[RelayCommand]
		async Task CreatServiceReport()
		{
			await PickFolder(CancellationToken.None);
			await PopulatingStrings();
			CreateExcelFile();
		}

		[RelayCommand]
		private async Task CustomerSelectionChanged()
		{
			CustomerName = selectedCustomer.CustomerName.ToString();
			CustomerLocation = selectedCustomer.City.ToString();
		}

		//get values from Supabase database
		private async Task GetAllCustomers()
		{
			var result = await _supabaseClient.From<CustomerModel>().Get();
			Customers.Clear();
			foreach (var customer in result.Models)
			{
				Customers.Add(customer);
			}
		}

		private async Task GetAllTimeSheets()
		{
			//load timesheets
			var resultt = await _supabaseClient.From<TimeSheetModel>().Get();

			TimeSheets.Clear();
			foreach (var timesheet in resultt.Models)
			{
				TimeSheets.Add(timesheet);
			}
		}

		private async Task GetUserInformation()
		{
			//load the UID from Preference
			UID = Preferences.Get("uid", "");

			var result = await _supabaseClient.From<UserModel>()
				.Where(x => x.UserId == UID)
				.Get();

			Users.Clear();
			foreach (var user in result.Models)
			{
				Users.Add(user);
			}
			//get the username from list to username string
			UserName = Users[0].UserName.ToString();
			UserLocation = Users[0].Location.ToString();
		}

		//add values depend on selection to strings
		private async Task PopulatingStrings()
		{
			//clear lists
			WorkingHours.Clear();
			TravelHours.Clear();

			//get hours queried by start and end date, worktype, workstatus and UID
			await GetDatesAndDay();
			await GetWorkingHours();
			await GetTravelHours();
			await SumWorkingTravelHoursAddToString();
		}

		private async Task GetWorkingHours()
		{
			//check if the Timespan for start and end is not more then 14 days
			if (ServiceStartDate > ServiceEndDate)
			{
				await Shell.Current.DisplayAlert("Error", "The start date can not be after the end date", "Ok");
			}
			else if (ServiceEndDate.Subtract(ServiceStartDate).TotalDays > 14)
			{
				await Shell.Current.DisplayAlert("Error", "The time span can not be more then 14 days", "Ok");
			}
			else
			{
				var result = TimeSheets
					.Where(x => x.UId == UID)
					.Where(x => x.StartDate >= ServiceStartDate)
					.Where(x => x.EndDate <= ServiceEndDate)
					.Where(x => x.CustomerName == CustomerName)
					.Where(x => x.WorkType == "Work")
					.Where(x => x.WorkStatus == "Finished");

				foreach (var workingtime in result)
				{
					WorkingHours.Add(workingtime);
				}
			}
		}

		private async Task GetDatesAndDay()
		{
			//get each date between start and end date and add them to strings
			if (ServiceStartDate > ServiceEndDate)
			{
				await Shell.Current.DisplayAlert("Error", "The start date can not be after the end date", "Ok");
			}

			else
			{
				for (int day = 1; day <= 14; day++)
				{
					var date = ServiceStartDate.AddDays(day - 1);
					switch (day)
					{
						case 1:
							Day1date = date.ToString("dd.MM.");
							Day1name = date.ToString("ddd");
							break;
						case 2:
							Day2date = date.ToString("dd.MM.");
							Day2name = date.ToString("ddd");
							break;
						case 3:
							Day3date = date.ToString("dd.MM.");
							Day3name = date.ToString("ddd");
							break;
						case 4:
							Day4date = date.ToString("dd.MM.");
							Day4name = date.ToString("ddd");
							break;
						case 5:
							Day5date = date.ToString("dd.MM.");
							Day5name = date.ToString("ddd");
							break;
						case 6:
							Day6date = date.ToString("dd.MM.");
							Day6name = date.ToString("ddd");
							break;
						case 7:
							Day7date = date.ToString("dd.MM.");
							Day7name = date.ToString("ddd");
							break;
						case 8:
							Day8date = date.ToString("dd.MM.");
							Day8name = date.ToString("ddd");
							break;
						case 9:
							Day9date = date.ToString("dd.MM.");
							Day9name = date.ToString("ddd");
							break;
						case 10:
							Day10date = date.ToString("dd.MM.");
							Day10name = date.ToString("ddd");
							break;
						case 11:
							Day11date = date.ToString("dd.MM.");
							Day11name = date.ToString("ddd");
							break;
						case 12:
							Day12date = date.ToString("dd.MM.");
							Day12name = date.ToString("ddd");
							break;
						case 13:
							Day13date = date.ToString("dd.MM.");
							Day13name = date.ToString("ddd");
							break;
						case 14:
							Day14date = date.ToString("dd.MM.");
							Day14name = date.ToString("ddd");
							break;
					}
				}
			}
		}

		private async Task GetTravelHours()
		{
			//check if the Timespan for start and end is not more then 14 days
			if (ServiceStartDate > ServiceEndDate)
			{
				await Shell.Current.DisplayAlert("Error", "The start date can not be after the end date", "Ok");
			}
			else if (ServiceEndDate.Subtract(ServiceStartDate).TotalDays > 14)
			{
				await Shell.Current.DisplayAlert("Error", "The time span can not be more then 14 days", "Ok");
			}
			else
			{
				var result = TimeSheets
					.Where(x => x.UId == UID)
					.Where(x => x.StartDate >= ServiceStartDate)
					.Where(x => x.EndDate <= ServiceEndDate)
					.Where(x => x.CustomerName == CustomerName)
					.Where(x => x.WorkType == "Travel")
					.Where(x => x.WorkStatus == "Finished");

				foreach (var traveltime in result)
				{
					TravelHours.Add(traveltime);
				}
			}
		}
		private async Task SumWorkingTravelHoursAddToString()
		{
			for (int day = 1; day <= 14; day++)
			{
				var workingHoursOfDay = WorkingHours.Where(x => x.StartDate.Day == day);
				var travelHoursOfDay = TravelHours.Where(x => x.StartDate.Day == day);

				//sum the timespan hours
				var totalWorkTimeOfDayTicks = workingHoursOfDay.Sum(x => x.Hours.Ticks);
				var totalTravelTimeOfDayTicks = travelHoursOfDay.Sum(x => x.Hours.Ticks);

				//convert the total tickes back to time
				var totalWorkTimeOfDay = new TimeSpan(totalWorkTimeOfDayTicks);
				var totalTravelTimeOfDay = new TimeSpan(totalTravelTimeOfDayTicks);

				// Assign the calculated sums to the respective properties
				switch (day)
				{
					case 1:
						Day1WorkTime = totalWorkTimeOfDay.ToString();
						Day1TravelTime = totalTravelTimeOfDay.ToString();
						break;
					case 2:
						Day2WorkTime = totalWorkTimeOfDay.ToString();
						Day2TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 3:
						Day3WorkTime = totalWorkTimeOfDay.ToString();
						Day3TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 4:
						Day4WorkTime = totalWorkTimeOfDay.ToString();
						Day4TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 5:
						Day5WorkTime = totalWorkTimeOfDay.ToString();
						Day5TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 6:
						Day6WorkTime = totalWorkTimeOfDay.ToString();
						Day6TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 7:
						Day7WorkTime = totalWorkTimeOfDay.ToString();
						Day7TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 8:
						Day8WorkTime = totalWorkTimeOfDay.ToString();
						Day8TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 9:
						Day9WorkTime = totalWorkTimeOfDay.ToString();
						Day9TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 10:
						Day10WorkTime = totalWorkTimeOfDay.ToString();
						Day10TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 11:
						Day11WorkTime = totalWorkTimeOfDay.ToString();
						Day11TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 12:
						Day12WorkTime = totalWorkTimeOfDay.ToString();
						Day12TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 13:
						Day13WorkTime = totalWorkTimeOfDay.ToString();
						Day13TravelTime = totalTravelTimeOfDay.ToString();
						break;
						case 14:
						Day14WorkTime = totalWorkTimeOfDay.ToString();
						Day14TravelTime = totalTravelTimeOfDay.ToString();
						break;
				}
			}
		}

		async Task PickFolder(CancellationToken cancellationToken)
		{
			var result = await FolderPicker.Default.PickAsync(cancellationToken);
			if (result.IsSuccessful)
			{
				//add file name ServiceReport to result
				FolderPath = result.Folder.Path + "\\ServiceReport.xlsx";
			}
			else
			{
				await Toast.Make($"The folder was not picked with error: {result.Exception.Message}").Show(cancellationToken);
			}
		}

		public async Task CreateExcelFile()
		{
			using (var workbook = new XLWorkbook())
			{
				#region Set Column width for Service report
				var worksheet = workbook.Worksheets.Add("Servicereport");

				//set column width from A to R to one size
				for (char column = 'A'; column <= 'Q'; column++)
				{
					worksheet.Column(column.ToString()).Width = 4;
				}

				//set column width for column R
				worksheet.Column("R").Width = 9;
				#endregion

				#region Set row height for service repport
				worksheet.Row(1).Height = 38;
				worksheet.Rows(2, 58).Height = 13;
				#endregion

				#region Merge cells for Service report
				//merge cells 
				var titlemerge = worksheet.Range("A1:I1");
				titlemerge.Merge();
				var titlemerge2 = worksheet.Range("J1:R1");
				titlemerge2.Merge();

				//merge spacer cells
				var spacermerge1 = worksheet.Range("A2:R2");
				spacermerge1.Merge();
				var spacermerge2 = worksheet.Range("A7:R7");
				spacermerge2.Merge();
				var spacermerge3 = worksheet.Range("A12:R12");
				spacermerge3.Merge();
				var spacermerge4 = worksheet.Range("A21:R21");
				spacermerge4.Merge();
				var spacermerge5 = worksheet.Range("A25:R25");
				spacermerge5.Merge();
				var spacermerge6 = worksheet.Range("A40:R40");
				spacermerge6.Merge();
				var spacermerge7 = worksheet.Range("A48:R48");
				spacermerge7.Merge();
				var spacermerge8 = worksheet.Range("A51:R51");
				spacermerge8.Merge();

				//merge cells for header left
				var headerleftmerge = worksheet.Range("A3:C3");
				headerleftmerge.Merge();
				var headerleftmerge2 = worksheet.Range("A4:C4");
				headerleftmerge2.Merge();
				var headerleftmerge3 = worksheet.Range("A5:C5");
				headerleftmerge3.Merge();
				var headerleftmerge4 = worksheet.Range("A6:C6");
				headerleftmerge4.Merge();

				var headerleftmerge5 = worksheet.Range("D3:I3");
				headerleftmerge5.Merge();
				var headerleftmerge6 = worksheet.Range("D4:I4");
				headerleftmerge6.Merge();
				var headerleftmerge7 = worksheet.Range("D5:I5");
				headerleftmerge7.Merge();
				var headerleftmerge8 = worksheet.Range("D6:I6");
				headerleftmerge8.Merge();

				//merge cells for header right
				var headerrightmerge = worksheet.Range("J3:L3");
				headerrightmerge.Merge();
				var headerrightmerge2 = worksheet.Range("J4:L4");
				headerrightmerge2.Merge();
				var headerrightmerge3 = worksheet.Range("J5:L5");
				headerrightmerge3.Merge();
				var headerrightmerge4 = worksheet.Range("J6:L6");
				headerrightmerge4.Merge();

				var headerrightmerge5 = worksheet.Range("M3:R3");
				headerrightmerge5.Merge();
				var headerrightmerge6 = worksheet.Range("M4:R4");
				headerrightmerge6.Merge();
				var headerrightmerge7 = worksheet.Range("M5:N5");
				headerrightmerge7.Merge();
				var headerrightmerge8 = worksheet.Range("P5:Q5");
				headerrightmerge8.Merge();
				var headerrightmerge9 = worksheet.Range("M6:N6");
				headerrightmerge9.Merge();
				var headerrightmerge10 = worksheet.Range("O6:Q6");
				headerrightmerge10.Merge();

				//merge cells for service type header
				var servicetypemerge = worksheet.Range("A8:E8");
				servicetypemerge.Merge();
				var servicetypemerge2 = worksheet.Range("F8:J8");
				servicetypemerge2.Merge();
				var servicetypemerge3 = worksheet.Range("K8:L8");
				servicetypemerge3.Merge();
				var servicetypemerge4 = worksheet.Range("M8:P8");
				servicetypemerge4.Merge();
				var servicetypemerge5 = worksheet.Range("Q8:R8");
				servicetypemerge5.Merge();
				var servicetypemerge6 = worksheet.Range("A9:B9");
				servicetypemerge6.Merge();
				var servicetypemerge7 = worksheet.Range("D9:E9");
				servicetypemerge7.Merge();
				var servicetypemerge8 = worksheet.Range("G9:I9");
				servicetypemerge8.Merge();
				var servicetypemerge9 = worksheet.Range("K9:L9");
				servicetypemerge9.Merge();
				var servicetypemerge10 = worksheet.Range("M9:P9");
				servicetypemerge10.Merge();
				var servicetypemerge11 = worksheet.Range("A10:B10");
				servicetypemerge11.Merge();
				var servicetypemerge12 = worksheet.Range("D10:F10");
				servicetypemerge12.Merge();
				var servicetypemerge13 = worksheet.Range("K10:L10");
				servicetypemerge13.Merge();
				var servicetypemerge14 = worksheet.Range("A11:D11");
				servicetypemerge14.Merge();
				var servicetypemerge15 = worksheet.Range("E11:R11");
				servicetypemerge15.Merge();

				//merge cells for time section
				var timemerge = worksheet.Range("A13:B13");
				timemerge.Merge();
				var timemerge2 = worksheet.Range("A14:B14");
				timemerge2.Merge();
				var timemerge3 = worksheet.Range("A15:B15");
				timemerge3.Merge();
				var timemerge4 = worksheet.Range("A16:B16");
				timemerge4.Merge();
				var timemerge5 = worksheet.Range("A17:B17");
				timemerge5.Merge();
				var timemerge6 = worksheet.Range("A18:B18");
				timemerge6.Merge();
				var timemerge7 = worksheet.Range("A19:B19");
				timemerge7.Merge();
				var timemerge8 = worksheet.Range("L18:Q18");
				timemerge8.Merge();
				var timemerge9 = worksheet.Range("L20:Q20");
				timemerge9.Merge();

				//merge cells for order section
				var ordermerge = worksheet.Range("A22:R22");
				ordermerge.Merge();
				var ordermerge2 = worksheet.Range("A23:R23");
				ordermerge2.Merge();
				var ordermerge3 = worksheet.Range("A24:R24");
				ordermerge3.Merge();

				//merge cells for work section
				var workmerge = worksheet.Range("A26:R26");
				workmerge.Merge();
				var workmerge2 = worksheet.Range("A27:C27");
				workmerge2.Merge();
				var workmerge3 = worksheet.Range("A28:C28");
				workmerge3.Merge();
				var workmerge4 = worksheet.Range("A29:C29");
				workmerge4.Merge();
				var workmerge5 = worksheet.Range("A30:C30");
				workmerge5.Merge();
				var workmerge6 = worksheet.Range("A31:C31");
				workmerge6.Merge();
				var workmerge7 = worksheet.Range("A32:C32");
				workmerge7.Merge();
				var workmerge8 = worksheet.Range("A33:C33");
				workmerge8.Merge();
				var workmerge9 = worksheet.Range("A34:C34");
				workmerge9.Merge();
				var workmerge10 = worksheet.Range("A35:C35");
				workmerge10.Merge();
				var workmerge11 = worksheet.Range("A36:C36");
				workmerge11.Merge();
				var workmerge12 = worksheet.Range("A37:C37");
				workmerge12.Merge();
				var workmerge13 = worksheet.Range("A38:C38");
				workmerge13.Merge();
				var workmerge14 = worksheet.Range("A39:C39");
				workmerge14.Merge();

				var workmerge15 = worksheet.Range("D27:F27");
				workmerge15.Merge();
				var workmerge16 = worksheet.Range("D28:F28");
				workmerge16.Merge();
				var workmerge17 = worksheet.Range("D29:F29");
				workmerge17.Merge();
				var workmerge18 = worksheet.Range("D30:F30");
				workmerge18.Merge();
				var workmerge19 = worksheet.Range("D31:F31");
				workmerge19.Merge();
				var workmerge20 = worksheet.Range("D32:F32");
				workmerge20.Merge();
				var workmerge21 = worksheet.Range("D33:F33");
				workmerge21.Merge();
				var workmerge22 = worksheet.Range("D34:F34");
				workmerge22.Merge();
				var workmerge23 = worksheet.Range("D35:F35");
				workmerge23.Merge();
				var workmerge24 = worksheet.Range("D36:F36");
				workmerge24.Merge();
				var workmerge25 = worksheet.Range("D37:F37");
				workmerge25.Merge();
				var workmerge26 = worksheet.Range("D38:F38");
				workmerge26.Merge();
				var workmerge27 = worksheet.Range("D39:F39");
				workmerge27.Merge();
				var workmerge28 = worksheet.Range("G27:R27");
				workmerge28.Merge();
				var workmerge29 = worksheet.Range("G28:R28");
				workmerge29.Merge();
				var workmerge30 = worksheet.Range("G29:R29");
				workmerge30.Merge();
				var workmerge31 = worksheet.Range("G30:R30");
				workmerge31.Merge();
				var workmerge32 = worksheet.Range("G31:R31");
				workmerge32.Merge();
				var workmerge33 = worksheet.Range("G32:R32");
				workmerge33.Merge();
				var workmerge34 = worksheet.Range("G33:R33");
				workmerge34.Merge();
				var workmerge35 = worksheet.Range("G34:R34");
				workmerge35.Merge();
				var workmerge36 = worksheet.Range("G35:R35");
				workmerge36.Merge();
				var workmerge37 = worksheet.Range("G36:R36");
				workmerge37.Merge();
				var workmerge38 = worksheet.Range("G37:R37");
				workmerge38.Merge();
				var workmerge39 = worksheet.Range("G38:R38");
				workmerge39.Merge();

				//merge cells for spareparts section
				var sparepartsmerge = worksheet.Range("A41:R41");
				sparepartsmerge.Merge();
				var sparepartsmerge2 = worksheet.Range("A42:R42");
				sparepartsmerge2.Merge();
				var sparepartsmerge3 = worksheet.Range("A43:R43");
				sparepartsmerge3.Merge();
				var sparepartsmerge4 = worksheet.Range("A44:R44");
				sparepartsmerge4.Merge();
				var sparepartsmerge5 = worksheet.Range("A45:R45");
				sparepartsmerge5.Merge();
				var sparepartsmerge6 = worksheet.Range("A46:R46");
				sparepartsmerge6.Merge();
				var sparepartsmerge7 = worksheet.Range("A47:R47");
				sparepartsmerge7.Merge();

				//merge cells for backup section
				var backupmerge = worksheet.Range("A49:F49");
				backupmerge.Merge();
				var backupmerge2 = worksheet.Range("G49:J49");
				backupmerge2.Merge();
				var backupmerge3 = worksheet.Range("A50:F50");
				backupmerge3.Merge();
				var backupmerge4 = worksheet.Range("G50:J50");
				backupmerge4.Merge();

				//merge cells for signature section
				var signaturemerge = worksheet.Range("C52:R52");
				signaturemerge.Merge();
				var signaturemerge2 = worksheet.Range("C53:F53");
				signaturemerge2.Merge();
				var signaturemerge4 = worksheet.Range("C54:F54");
				signaturemerge4.Merge();
				var signaturemerge5 = worksheet.Range("C55:F55");
				signaturemerge5.Merge();
				var signaturemerge6 = worksheet.Range("C56:F56");
				signaturemerge6.Merge();
				var signaturemerge7 = worksheet.Range("C57:F57");
				signaturemerge7.Merge();
				var signaturemerge8 = worksheet.Range("C58:F58");
				signaturemerge8.Merge();
				var signaturemerge9 = worksheet.Range("A52:B52");
				signaturemerge9.Merge();
				var signaturemerge10 = worksheet.Range("A53:B53");
				signaturemerge10.Merge();
				var signaturemerge11 = worksheet.Range("A54:B54");
				signaturemerge11.Merge();
				var signaturemerge12 = worksheet.Range("A55:B55");
				signaturemerge12.Merge();
				var signaturemerge13 = worksheet.Range("A56:B56");
				signaturemerge13.Merge();
				var signaturemerge14 = worksheet.Range("A57:B57");
				signaturemerge14.Merge();
				var signaturemerge15 = worksheet.Range("A58:B58");
				signaturemerge15.Merge();
				var signaturemerge16 = worksheet.Range("H53:M53");
				signaturemerge16.Merge();
				var signaturemerge17 = worksheet.Range("N53:O53");
				signaturemerge17.Merge();
				var signaturemerge18 = worksheet.Range("P53:R54");
				signaturemerge18.Merge();
				var signaturemerge19 = worksheet.Range("G54:R54");
				signaturemerge19.Merge();
				var signaturemerge20 = worksheet.Range("G55:M55");
				signaturemerge20.Merge();
				var signaturemerge21 = worksheet.Range("N55:R55");
				signaturemerge21.Merge();
				var signaturemerge22 = worksheet.Range("G56:M57");
				signaturemerge22.Merge();
				var signaturemerge23 = worksheet.Range("N56:R57");
				signaturemerge23.Merge();
				var signaturemerge24 = worksheet.Range("G58:M58");
				signaturemerge24.Merge();
				var signaturemerge25 = worksheet.Range("N58:R58");
				signaturemerge25.Merge();
				#endregion

				#region Set Fontsize for Service report
				worksheet.Range("A1:R1").Style.Font.FontSize = 16;
				worksheet.Range("C14:P14").Style.Font.FontSize = 9;
				#endregion

				//define print area
				worksheet.PageSetup.PrintAreas.Add("A1:R58");

				//set print options
				worksheet.PageSetup.SetPaperSize(XLPaperSize.A4Paper);
				worksheet.PageSetup.CenterHorizontally = true;
				worksheet.PageSetup.CenterVertically = true;
				worksheet.PageSetup.PageOrientation = XLPageOrientation.Portrait;
				worksheet.PageSetup.Margins.Left = 0.5;
				worksheet.PageSetup.Margins.Right = 0.5;
				worksheet.PageSetup.Margins.Top = 0.5;
				worksheet.PageSetup.Margins.Bottom = 0.5;

				//standart text for Service report
				worksheet.Cell("A1").Value = "PRÄWEMA";
				worksheet.Cell("J1").Value = "Service - Time - Report";

				worksheet.Cell("A3").Value = "Machine Nr.";
				worksheet.Cell("D3").Value = MachineNumber;
				worksheet.Cell("A4").Value = "Customer";
				worksheet.Cell("D4").Value = CustomerName;
				worksheet.Cell("A5").Value = "Contact";
				worksheet.Cell("A6").Value = "Machine type";

				worksheet.Cell("J3").Value = "Service Engineer";
				worksheet.Cell("M3").Value = UserName;
				worksheet.Cell("J4").Value = "Address";
				worksheet.Cell("M4").Value = UserLocation;
				worksheet.Cell("J5").Value = "From";
				worksheet.Cell("M5").Value = Convert.ToString(ServiceStartDate.Day) + "." + Convert.ToString(ServiceStartDate.Month) + ".";
				worksheet.Cell("J6").Value = "Order Nr.";
				worksheet.Cell("O5").Value = "To";
				worksheet.Cell("P5").Value = Convert.ToString(ServiceEndDate.Day) + "." + Convert.ToString(ServiceEndDate.Month) + ".";
				worksheet.Cell("R5").Value = ServiceStartDate.Year;
				worksheet.Cell("O6").Value = "Delivery Date";

				worksheet.Cell("A8").Value = "Customer order nr.";
				worksheet.Cell("A9").Value = "Repair";
				worksheet.Cell("A10").Value = "Exibition";
				worksheet.Cell("A11").Value = "Software change";
				worksheet.Cell("D9").Value = "RetroFit";
				worksheet.Cell("G9").Value = "IBN";
				worksheet.Cell("K9").Value = "Inspection";
				worksheet.Cell("N9").Value = "Training";
				worksheet.Cell("D10").Value = "Delevery cpl";
				worksheet.Cell("G10").Value = "Yes";
				worksheet.Cell("I10").Value = "No";
				worksheet.Cell("K10").Value = "Damaged";
				worksheet.Cell("N10").Value = "Yes";
				worksheet.Cell("P10").Value = "No";	

				worksheet.Cell("A13").Value = "Day";
				worksheet.Cell("C13").Value = Day1name;
				worksheet.Cell("D13").Value = Day2name;
				worksheet.Cell("E13").Value = Day3name;
				worksheet.Cell("F13").Value = Day4name;
				worksheet.Cell("G13").Value = Day5name;
				worksheet.Cell("H13").Value = Day6name;
				worksheet.Cell("I13").Value = Day7name;
				worksheet.Cell("J13").Value = Day8name;
				worksheet.Cell("K13").Value = Day9name;
				worksheet.Cell("L13").Value = Day10name;
				worksheet.Cell("M13").Value = Day11name;
				worksheet.Cell("N13").Value = Day12name;
				worksheet.Cell("O13").Value = Day13name;
				worksheet.Cell("P13").Value = Day14name;
				worksheet.Cell("R13").Value = "Total";
				worksheet.Cell("A14").Value = "Date";
				worksheet.Cell("C14").Value = Day1date;
				worksheet.Cell("D14").Value = Day2date;
				worksheet.Cell("E14").Value = Day3date;
				worksheet.Cell("F14").Value = Day4date;
				worksheet.Cell("G14").Value = Day5date;
				worksheet.Cell("H14").Value = Day6date;
				worksheet.Cell("I14").Value = Day7date;
				worksheet.Cell("J14").Value = Day8date;
				worksheet.Cell("K14").Value = Day9date;
				worksheet.Cell("L14").Value = Day10date;
				worksheet.Cell("M14").Value = Day11date;
				worksheet.Cell("N14").Value = Day12date;
				worksheet.Cell("O14").Value = Day13date;
				worksheet.Cell("P14").Value = Day14date;
				worksheet.Cell("A15").Value = "Work";
				worksheet.Cell("A16").Value = "Travel";
				worksheet.Cell("A17").Value = "Total/Day";
				worksheet.Cell("L18").Value = "Total hours without travel back";
				worksheet.Cell("A19").Value = "Travel back";
				worksheet.Cell("L20").Value = "Total hours with travel back";

				worksheet.Cell("A22").Value = "Order";

				worksheet.Cell("A26").Value = "Work description";
				worksheet.Cell("A41").Value = "Spare parts / Comments";

				worksheet.Cell("A49").Value = "Backup handover to";
				worksheet.Cell("A50").Value = "Backup date";

				worksheet.Cell("A52").Value = "Distriputor";
				worksheet.Cell("A53").Value = "Admin";
				worksheet.Cell("A54").Value = "Service";
				worksheet.Cell("A55").Value = "Sales";
				worksheet.Cell("A56").Value = "Production";
				worksheet.Cell("A57").Value = "QMS";
				worksheet.Cell("A58").Value = "EDV";

				worksheet.Cell("G53").Value = "Place:"; 
				worksheet.Cell("H53").Value = CustomerLocation;
				worksheet.Cell("N53").Value = "Signature:";

				worksheet.Cell("G55").Value = "Signature customer";
				worksheet.Cell("N55").Value = "Signature service engineer";
				worksheet.Cell("N58").Value = UserName;

				try
				{
					workbook.SaveAs(FolderPath);
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
		}
	}
}
