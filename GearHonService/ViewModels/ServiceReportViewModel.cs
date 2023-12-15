using ClosedXML.Excel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using DocumentFormat.OpenXml.ExtendedProperties;
using System.Diagnostics;

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
		[ObservableProperty] private string day1TravelBackTime;
		[ObservableProperty] private string day2TravelBackTime;
		[ObservableProperty] private string day3TravelBackTime;
		[ObservableProperty] private string day4TravelBackTime;
		[ObservableProperty] private string day5TravelBackTime;
		[ObservableProperty] private string day6TravelBackTime;
		[ObservableProperty] private string day7TravelBackTime;
		[ObservableProperty] private string day8TravelBackTime;
		[ObservableProperty] private string day9TravelBackTime;
		[ObservableProperty] private string day10TravelBackTime;
		[ObservableProperty] private string day11TravelBackTime;
		[ObservableProperty] private string day12TravelBackTime;
		[ObservableProperty] private string day13TravelBackTime;
		[ObservableProperty] private string day14TravelBackTime;
		[ObservableProperty] private string day1MachineNumber;
		[ObservableProperty] private string day2MachineNumber;
		[ObservableProperty] private string day3MachineNumber;
		[ObservableProperty] private string day4MachineNumber;
		[ObservableProperty] private string day5MachineNumber;
		[ObservableProperty] private string day6MachineNumber;
		[ObservableProperty] private string day7MachineNumber;
		[ObservableProperty] private string day8MachineNumber;
		[ObservableProperty] private string day9MachineNumber;
		[ObservableProperty] private string day10MachineNumber;
		[ObservableProperty] private string day11MachineNumber;
		[ObservableProperty] private string day12MachineNumber;
		[ObservableProperty] private string day13MachineNumber;
		[ObservableProperty] private string day14MachineNumber;
		[ObservableProperty] private string day1Description;
		[ObservableProperty] private string day2Description;
		[ObservableProperty] private string day3Description;
		[ObservableProperty] private string day4Description;
		[ObservableProperty] private string day5Description;
		[ObservableProperty] private string day6Description;
		[ObservableProperty] private string day7Description;
		[ObservableProperty] private string day8Description;
		[ObservableProperty] private string day9Description;
		[ObservableProperty] private string day10Description;
		[ObservableProperty] private string day11Description;
		[ObservableProperty] private string day12Description;
		[ObservableProperty] private string day13Description;
		[ObservableProperty] private string day14Description;

		[ObservableProperty] private string workTotal;
		[ObservableProperty] private string travelTotal;
		[ObservableProperty] private string totalWithoutTravelBackTime;
		[ObservableProperty] private string travelBackTotal;
		[ObservableProperty] private string totalAllTime;

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
		[ObservableProperty]
		private ObservableCollection<TimeSheetModel> travelBackHours;
		[ObservableProperty]
		private ObservableCollection<TimeSheetModel> machineNumberAndDescription;

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
			TravelBackHours = new ObservableCollection<TimeSheetModel>();
			MachineNumberAndDescription = new ObservableCollection<TimeSheetModel>();

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
			await GetTravelBackHours();
			await SumWorkingTravelHours();
			await SumTravelBackAndGetFinalTotal();
			await GetMachineNumberAndDescriptionPerDay();

			//finaly clean all 0 or 0.0 out of the report
			SetZeroStrings();
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
			try
			{
				var dailyTotalTravelTime = TimeSheets
					.Where(t => t.UId == UID)
					.Where(t => t.CustomerName == CustomerName)
					.Where(t => t.WorkType == "Travel")
					.Where(t => t.WorkStatus == "Stopped")
					.Where(t => t.StartDate >= ServiceStartDate)
					.Where(t => t.EndDate <= ServiceEndDate)
					.GroupBy(t => t.StartDate.Date)
					.Select(g => new
					{
						Date = g.Key,
						TotalTravelTime = g.Aggregate(TimeSpan.Zero, (subtotal, timesheet) => subtotal + timesheet.Hours)
					});

				foreach (var item in dailyTotalTravelTime)
				{
					TravelHours.Add(new TimeSheetModel
					{
						StartDate = item.Date,
						Hours = item.TotalTravelTime
					});
				}

				//load the hours to the strings where the startdate are the same date
				for (int day = 1; day <= 14; day++)
				{
					var date = ServiceStartDate.AddDays(day - 1);
					switch (day)
					{
						case 1:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day1TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day1TravelTime = t.ToString("0.#");
							}
							break;
						case 2:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day2TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day2TravelTime = t.ToString("0.#");
							}
							break;
						case 3:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day3TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day3TravelTime = t.ToString("0.#");
							}
							break;
						case 4:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day4TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day4TravelTime = t.ToString("0.#");
							}
							break;
						case 5:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day5TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day5TravelTime = t.ToString("0.#");
							}
							break;
						case 6:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day6TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day6TravelTime = t.ToString("0.#");
							}
							break;
						case 7:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day7TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day7TravelTime = t.ToString("0.#");
							}
							break;
						case 8:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day8TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day8TravelTime = t.ToString("0.#");
							}
							break;
						case 9:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day9TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day9TravelTime = t.ToString("0.#");
							}
							break;
						case 10:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day10TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day10TravelTime = t.ToString("0.#");
							}
							break;
						case 11:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day11TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day11TravelTime = t.ToString("0.#");
							}
							break;
						case 12:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day12TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day12TravelTime = t.ToString("0.#");
							}
							break;
						case 13:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day13TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day13TravelTime = t.ToString("0.#");
							}
							break;
						case 14:
							if (TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day14TravelTime = "";
							}
							else
							{
								var timespanday = TravelHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day14TravelTime = t.ToString("0.#");
							}
							break;
					}

				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private async Task GetTravelBackHours()
		{
			try
			{
				var dailyTotalTravelBackTime = TimeSheets
					.Where(t => t.UId == UID)
					.Where(t => t.CustomerName == CustomerName)
					.Where(t => t.WorkType == "Travel back")
					.Where(t => t.WorkStatus == "Stopped")
					.Where(t => t.StartDate >= ServiceStartDate)
					.Where(t => t.EndDate <= ServiceEndDate)
					.GroupBy(t => t.StartDate.Date)
					.Select(g => new
					{
						Date = g.Key,
						TotalTravelBackTime = g.Aggregate(TimeSpan.Zero, (subtotal, timesheet) => subtotal + timesheet.Hours)
					});

				foreach (var item in dailyTotalTravelBackTime)
				{
					TravelBackHours.Add(new TimeSheetModel
					{
						StartDate = item.Date,
						Hours = item.TotalTravelBackTime
					});
				}

				//load the hours to the strings where the startdate are the same date
				for (int day = 1; day <= 14; day++)
				{
					var date = ServiceStartDate.AddDays(day - 1);
					switch (day)
					{
						case 1:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day1TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day1TravelBackTime = t.ToString("0.#");
							}
							break;
						case 2:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day2TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day2TravelBackTime = t.ToString("0.#");
							}
							break;
						case 3:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day3TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day3TravelBackTime = t.ToString("0.#");
							}
							break;
						case 4:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day4TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day4TravelBackTime = t.ToString("0.#");
							}
							break;
						case 5:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day5TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day5TravelBackTime = t.ToString("0.#");
							}
							break;
						case 6:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day6TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day6TravelBackTime = t.ToString("0.#");
							}
							break;
						case 7:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day7TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day7TravelBackTime = t.ToString("0.#");
							}
							break;
						case 8:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day8TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day8TravelBackTime = t.ToString("0.#");
							}
							break;
						case 9:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day9TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day9TravelBackTime = t.ToString("0.#");
							}
							break;
						case 10:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day10TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day10TravelBackTime = t.ToString("0.#");
							}
							break;
						case 11:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day11TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day11TravelBackTime = t.ToString("0.#");
							}
							break;
						case 12:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day12TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day12TravelBackTime = t.ToString("0.#");
							}
							break;
						case 13:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day13TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day13TravelBackTime = t.ToString("0.#");
							}
							break;
						case 14:
							if (TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day14TravelBackTime = "";
							}
							else
							{
								var timespanday = TravelBackHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day14TravelBackTime = t.ToString("0.#");
							}
							break;
					}

				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private async Task GetWorkingHours()
		{
			try
			{
				var dailyTotalWorkingTime = TimeSheets
					.Where(t => t.UId == UID)
					.Where(t => t.CustomerName == CustomerName)
					.Where(t => t.WorkType == "Work")
					.Where(t => t.WorkStatus == "Stopped")
					.Where(t => t.StartDate >= ServiceStartDate)
					.Where(t => t.EndDate <= ServiceEndDate)
					.GroupBy(t => t.StartDate.Date)
					.Select(g => new
					{
						Date = g.Key,
						TotalWorkingTime = g.Aggregate(TimeSpan.Zero, (subtotal, timesheet) => subtotal + timesheet.Hours)
					});

				foreach (var item in dailyTotalWorkingTime)
				{
					WorkingHours.Add(new TimeSheetModel
					{
						StartDate = item.Date,
						Hours = item.TotalWorkingTime
					});
				}

				//load the hours to the strings where the startdate are the same date
				for (int day = 1; day <= 14; day++)
				{
					var date = ServiceStartDate.AddDays(day - 1);
					switch (day)
					{
						case 1:
							if(WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day1WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m)/60;
								Day1WorkTime = t.ToString("0.#");
							}
							break;
						case 2:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day2WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day2WorkTime = t.ToString("0.#");
							}
							break;
						case 3:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day3WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day3WorkTime = t.ToString("0.#");
							}
							break;
						case 4:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day4WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day4WorkTime = t.ToString("0.#");
							}
							break;
						case 5:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day5WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day5WorkTime = t.ToString("0.#");
							}
							break;
						case 6:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day6WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day6WorkTime = t.ToString("0.#");
							}
							break;
						case 7:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day7WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day7WorkTime = t.ToString("0.#");
							}
							break;
						case 8:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day8WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day8WorkTime = t.ToString("0.#");
							}
							break;
						case 9:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day9WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day9WorkTime = t.ToString("0.#");
							}
							break;
						case 10:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day10WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day10WorkTime = t.ToString("0.#");
							}
							break;
						case 11:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day11WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day11WorkTime = t.ToString("0.#");
							}
							break;
						case 12:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day12WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day12WorkTime = t.ToString("0.#");
							}
							break;
						case 13:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day13WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day13WorkTime = t.ToString("0.#");
							}
							break;
					    case 14:
							if (WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString().Equals("00:00:00"))
							{
								Day14WorkTime = "";
							}
							else
							{
								var timespanday = WorkingHours.Where(x => x.StartDate == date).Select(x => x.Hours).FirstOrDefault().ToString();
								double h = Convert.ToDateTime(timespanday).Hour;
								double m = Convert.ToDateTime(timespanday).Minute;

								double t = ((h * 60) + m) / 60;
								Day14WorkTime = t.ToString("0.#");
							}
							break;
					}
				}
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private async Task SumWorkingTravelHours()
		{
			try
			{
				//check if any string is "" and set them to 0.0
				if (Day1WorkTime == "")
				{
					Day1WorkTime = "0.0";
				}
				if (Day2WorkTime == "")
				{
					Day2WorkTime = "0.0";
				}
				if (Day3WorkTime == "")
				{
					Day3WorkTime = "0.0";
				}
				if (Day4WorkTime == "")
				{
					Day4WorkTime = "0.0";
				}
				if (Day5WorkTime == "")
				{
					Day5WorkTime = "0.0";
				}
				if (Day6WorkTime == "")
				{
					Day6WorkTime = "0.0";
				}
				if (Day7WorkTime == "")
				{
					Day7WorkTime = "0.0";
				}
				if (Day8WorkTime == "")
				{
					Day8WorkTime = "0.0";
				}
				if (Day9WorkTime == "")
				{
					Day9WorkTime = "0.0";
				}
				if (Day10WorkTime == "")
				{
					Day10WorkTime = "0.0";
				}
				if (Day11WorkTime == "")
				{
					Day11WorkTime = "0.0";
				}
				if (Day12WorkTime == "")
				{
					Day12WorkTime = "0.0";
				}
				if (Day13WorkTime == "")
				{
					Day13WorkTime = "0.0";
				}
				if (Day14WorkTime == "")
				{
					Day14WorkTime = "0.0";
				}
				if (Day1TravelTime == "")
				{
					Day1TravelTime = "0.0";
				}
				if (Day2TravelTime == "")
				{
					Day2TravelTime = "0.0";
				}
				if (Day3TravelTime == "")
				{
					Day3TravelTime = "0.0";
				}
				if (Day4TravelTime == "")
				{
					Day4TravelTime = "0.0";
				}
				if (Day5TravelTime == "")
				{
					Day5TravelTime = "0.0";
				}
				if (Day6TravelTime == "")
				{
					Day6TravelTime = "0.0";
				}
				if (Day7TravelTime == "")
				{
					Day7TravelTime = "0.0";
				}
				if (Day8TravelTime == "")
				{
					Day8TravelTime = "0.0";
				}
				if (Day9TravelTime == "")
				{
					Day9TravelTime = "0.0";
				}
				if (Day10TravelTime == "")
				{
					Day10TravelTime = "0.0";
				}
				if (Day11TravelTime == "")
				{
					Day11TravelTime = "0.0";
				}
				if (Day12TravelTime == "")
				{
					Day12TravelTime = "0.0";
				}
				if (Day13TravelTime == "")
				{
					Day13TravelTime = "0.0";
				}
				if (Day14TravelTime == "")
				{
					Day14TravelTime = "0.0";
				}

				//sum all strings from workingtime
				double workTotal = Convert.ToDouble(Day1WorkTime) + Convert.ToDouble(Day2WorkTime) + Convert.ToDouble(Day3WorkTime) + Convert.ToDouble(Day4WorkTime) + Convert.ToDouble(Day5WorkTime) + Convert.ToDouble(Day6WorkTime) + Convert.ToDouble(Day7WorkTime) + Convert.ToDouble(Day8WorkTime) + Convert.ToDouble(Day9WorkTime) + Convert.ToDouble(Day10WorkTime) + Convert.ToDouble(Day11WorkTime) + Convert.ToDouble(Day12WorkTime) + Convert.ToDouble(Day13WorkTime) + Convert.ToDouble(Day14WorkTime);

				double travelTotal = Convert.ToDouble(Day1TravelTime) + Convert.ToDouble(Day2TravelTime) + Convert.ToDouble(Day3TravelTime) + Convert.ToDouble(Day4TravelTime) + Convert.ToDouble(Day5TravelTime) + Convert.ToDouble(Day6TravelTime) + Convert.ToDouble(Day7TravelTime) + Convert.ToDouble(Day8TravelTime) + Convert.ToDouble(Day9TravelTime) + Convert.ToDouble(Day10TravelTime) + Convert.ToDouble(Day11TravelTime) + Convert.ToDouble(Day12TravelTime) + Convert.ToDouble(Day13TravelTime) + Convert.ToDouble(Day14TravelTime);

				WorkTotal = workTotal.ToString("0.#");
				TravelTotal = travelTotal.ToString("0.#");
				TotalWithoutTravelBackTime = (workTotal + travelTotal).ToString("0.#");
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private async Task SumTravelBackAndGetFinalTotal()
		{
			try
			{
				//check if any string is "" if so change to 0.0
				if (Day1TravelBackTime == "")
				{
					Day1TravelBackTime = "0.0";
				}
				if (Day2TravelBackTime == "")
				{
					Day2TravelBackTime = "0.0";
				}
				if (Day3TravelBackTime == "")
				{
					Day3TravelBackTime = "0.0";
				}
				if (Day4TravelBackTime == "")
				{
					Day4TravelBackTime = "0.0";
				}
				if (Day5TravelBackTime == "")
				{
					Day5TravelBackTime = "0.0";
				}
				if (Day6TravelBackTime == "")
				{
					Day6TravelBackTime = "0.0";
				}
				if (Day7TravelBackTime == "")
				{
					Day7TravelBackTime = "0.0";
				}
				if (Day8TravelBackTime == "")
				{
					Day8TravelBackTime = "0.0";
				}
				if (Day9TravelBackTime == "")
				{
					Day9TravelBackTime = "0.0";
				}
				if (Day10TravelBackTime == "")
				{
					Day10TravelBackTime = "0.0";
				}
				if (Day11TravelBackTime == "")
				{
					Day11TravelBackTime = "0.0";
				}
				if (Day12TravelBackTime == "")
				{
					Day12TravelBackTime = "0.0";
				}
				if (Day13TravelBackTime == "")
				{
					Day13TravelBackTime = "0.0";
				}
				if (Day14TravelBackTime == "")
				{
					Day14TravelBackTime = "0.0";
				}
				//Sum all travel back hours
				var travelBackTotal = Convert.ToDouble(Day1TravelBackTime) + Convert.ToDouble(Day2TravelBackTime) + Convert.ToDouble(Day3TravelBackTime) + Convert.ToDouble(Day4TravelBackTime) + Convert.ToDouble(Day5TravelBackTime) + Convert.ToDouble(Day6TravelBackTime) + Convert.ToDouble(Day7TravelBackTime) + Convert.ToDouble(Day8TravelBackTime) + Convert.ToDouble(Day9TravelBackTime) + Convert.ToDouble(Day10TravelBackTime) + Convert.ToDouble(Day11TravelBackTime) + Convert.ToDouble(Day12TravelBackTime) + Convert.ToDouble(Day13TravelBackTime) + Convert.ToDouble(Day14TravelBackTime);
				TravelBackTotal = travelBackTotal.ToString("0.#");

				double a = Convert.ToDouble(TotalWithoutTravelBackTime);
				double b = Convert.ToDouble(TravelBackTotal);
				double t = a + b;
				TotalAllTime = (t).ToString("0.#");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private async Task GetMachineNumberAndDescriptionPerDay()
		{
			try
			{
				//get the description and the corresponding machine number with the longest timespan from each day 
				var machineNumberAndDescription = TimeSheets
					.Where(t => t.UId == UID)
					.Where(t => t.CustomerName == CustomerName)
					.Where(t => t.WorkType == "Work")
					.Where(t => t.WorkStatus == "Stopped")
					.Where(t => t.StartDate >= ServiceStartDate)
					.Where(t => t.EndDate <= ServiceEndDate)
					.GroupBy(t => t.StartDate.Date)
					.Select(g => new
					{
						Date = g.Key,
						TotalWorkingTime = g.Aggregate(TimeSpan.Zero, (subtotal, timesheet) => subtotal + timesheet.Hours),
						MachineNumber = g.OrderByDescending(x => x.Hours).Select(x => x.MachineNumber).FirstOrDefault(),
						Description = g.OrderByDescending(x => x.Hours).Select(x => x.Description).FirstOrDefault()
					});

				foreach (var item in machineNumberAndDescription)
				{
					MachineNumberAndDescription.Add(new TimeSheetModel
					{
						StartDate = item.Date,
						Hours = item.TotalWorkingTime,
						MachineNumber = item.MachineNumber,
						Description = item.Description
					});
				}

				//load the machine number and description to the strings where the startdate are the same date
				for (int day = 1; day <= 14; day++)
				{
					var date = ServiceStartDate.AddDays(day - 1);
					switch (day)
					{
						case 1:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day1MachineNumber = "";
							}
							else
							{
								Day1MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day1Description = "";
							}
							else
							{
								Day1Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 2:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day2MachineNumber = "";
							}
							else
							{
								Day2MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day2Description = "";
							}
							else
							{
								Day2Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 3:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day3MachineNumber = "";
							}
							else
							{
								Day3MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day3Description = "";
							}
							else
							{
								Day3Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 4:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day4MachineNumber = "";
							}
							else
							{
								Day4MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day4Description = "";
							}
							else
							{
								Day4Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 5:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day5MachineNumber = "";
							}
							else
							{
								Day5MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day5Description = "";
							}
							else
							{
								Day5Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 6:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day6MachineNumber = "";
							}
							else
							{
								Day6MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day6Description = "";
							}
							else
							{
								Day6Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 7:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day7MachineNumber = "";
							}
							else
							{
								Day7MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day7Description = "";
							}
							else
							{
								Day7Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 8:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day8MachineNumber = "";
							}
							else
							{
								Day8MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day8Description = "";
							}
							else
							{
								Day8Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 9:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day9MachineNumber = "";
							}
							else
							{
								Day9MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day9Description = "";
							}
							else
							{
								Day9Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 10:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day10MachineNumber = "";
							}
							else
							{
								Day10MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day10Description = "";
							}
							else
							{
								Day10Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 11:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day11MachineNumber = "";
							}
							else
							{
								Day11MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day11Description = "";
							}
							else
							{
								Day11Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 12:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day12MachineNumber = "";
							}
							else
							{
								Day12MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day12Description = "";
							}
							else
							{
								Day12Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 13:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day13MachineNumber = "";
							}
							else
							{
								Day13MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day13Description = "";
							}
							else
							{
								Day13Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
						case 14:
							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault() == null)
							{
								Day14MachineNumber = "";
							}
							else
							{
								Day14MachineNumber = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.MachineNumber).FirstOrDefault();
							}

							if (MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault() == null)
							{
								Day14Description = "";
							}
							else
							{
								Day14Description = MachineNumberAndDescription.Where(x => x.StartDate == date).Select(x => x.Description).FirstOrDefault();
							}
							break;
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		private void SetZeroStrings()
		{
			//if any string is 0 or 0.0 set it to ""
			if (Day1WorkTime == "0" || Day1WorkTime == "0.0")
			{
				Day1WorkTime = "";
			}
			if (Day2WorkTime == "0" || Day2WorkTime == "0.0")
			{
				Day2WorkTime = "";
			}
			if (Day3WorkTime == "0" || Day3WorkTime == "0.0")
			{
				Day3WorkTime = "";
			}
			if (Day4WorkTime == "0" || Day4WorkTime == "0.0")
			{
				Day4WorkTime = "";
			}
			if (Day5WorkTime == "0" || Day5WorkTime == "0.0")
			{
				Day5WorkTime = "";
			}
			if (Day6WorkTime == "0" || Day6WorkTime == "0.0")
			{
				Day6WorkTime = "";
			}
			if (Day7WorkTime == "0" || Day7WorkTime == "0.0")
			{
				Day7WorkTime = "";
			}
			if (Day8WorkTime == "0" || Day8WorkTime == "0.0")
			{
				Day8WorkTime = "";
			}
			if (Day9WorkTime == "0" || Day9WorkTime == "0.0")
			{
				Day9WorkTime = "";
			}
			if (Day10WorkTime == "0" || Day10WorkTime == "0.0")
			{
				Day10WorkTime = "";
			}
			if (Day11WorkTime == "0" || Day11WorkTime == "0.0")
			{
				Day11WorkTime = "";
			}
			if (Day12WorkTime == "0" || Day12WorkTime == "0.0")
			{
				Day12WorkTime = "";
			}
			if (Day13WorkTime == "0" || Day13WorkTime == "0.0")
			{
				Day13WorkTime = "";
			}
			if (Day14WorkTime == "0" || Day14WorkTime == "0.0")
			{
				Day14WorkTime = "";
			}
			if (Day1TravelTime == "0" || Day1TravelTime == "0.0")
			{
				Day1TravelTime = "";
			}
			if (Day2TravelTime == "0" || Day2TravelTime == "0.0")
			{
				Day2TravelTime = "";
			}
			if (Day3TravelTime == "0" || Day3TravelTime == "0.0")
			{
				Day3TravelTime = "";
			}
			if (Day4TravelTime == "0" || Day4TravelTime == "0.0")
			{
				Day4TravelTime = "";
			}
			if (Day5TravelTime == "0" || Day5TravelTime == "0.0")
			{
				Day5TravelTime = "";
			}
			if (Day6TravelTime == "0" || Day6TravelTime == "0.0")
			{
				Day6TravelTime = "";
			}
			if (Day7TravelTime == "0" || Day7TravelTime == "0.0")
			{
				Day7TravelTime = "";
			}
			if (Day8TravelTime == "0" || Day8TravelTime == "0.0")
			{
				Day8TravelTime = "";
			}
			if (Day9TravelTime == "0" || Day9TravelTime == "0.0")
			{
				Day9TravelTime = "";
			}
			if (Day10TravelTime == "0" || Day10TravelTime == "0.0")
			{
				Day10TravelTime = "";
			}
			if (Day11TravelTime == "0" || Day11TravelTime == "0.0")
			{
				Day11TravelTime = "";
			}
			if (Day12TravelTime == "0" || Day12TravelTime == "0.0")
			{
				Day12TravelTime = "";
			}
			if (Day13TravelTime == "0" || Day13TravelTime == "0.0")
			{
				Day13TravelTime = "";
			}
			if (Day14TravelTime == "0" || Day14TravelTime == "0.0")
			{
				Day14TravelTime = "";
			}
			if (Day1TravelBackTime == "0" || Day1TravelBackTime == "0.0")
			{
				Day1TravelBackTime = "";
			}
			if (Day2TravelBackTime == "0" || Day2TravelBackTime == "0.0")
			{
				Day2TravelBackTime = "";
			}
			if (Day3TravelBackTime == "0" || Day3TravelBackTime == "0.0")
			{
				Day3TravelBackTime = "";
			}
			if (Day4TravelBackTime == "0" || Day4TravelBackTime == "0.0")
			{
				Day4TravelBackTime = "";
			}
			if (Day5TravelBackTime == "0" || Day5TravelBackTime == "0.0")
			{
				Day5TravelBackTime = "";
			}
			if (Day6TravelBackTime == "0" || Day6TravelBackTime == "0.0")
			{
				Day6TravelBackTime = "";
			}
			if (Day7TravelBackTime == "0" || Day7TravelBackTime == "0.0")
			{
				Day7TravelBackTime = "";
			}
			if (Day8TravelBackTime == "0" || Day8TravelBackTime == "0.0")
			{
				Day8TravelBackTime = "";
			}
			if (Day9TravelBackTime == "0" || Day9TravelBackTime == "0.0")
			{
				Day9TravelBackTime = "";
			}
			if (Day10TravelBackTime == "0" || Day10TravelBackTime == "0.0")
			{
				Day10TravelBackTime = "";
			}
			if (Day11TravelBackTime == "0" || Day11TravelBackTime == "0.0")
			{
				Day11TravelBackTime = "";
			}
			if (Day12TravelBackTime == "0" || Day12TravelBackTime == "0.0")
			{
				Day12TravelBackTime = "";
			}
			if (Day13TravelBackTime == "0" || Day13TravelBackTime == "0.0")
			{
				Day13TravelBackTime = "";
			}
			if (Day14TravelBackTime == "0" || Day14TravelBackTime == "0.0")
			{
				Day14TravelBackTime = "";
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
				var spacermerge6 = worksheet.Range("A41:R41");
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
				var workmerge42 = worksheet.Range("A40:C40");
				workmerge42.Merge();

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
				var workmerge43 = worksheet.Range("D40:F40");
				workmerge43.Merge();
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
				var workmerge40 = worksheet.Range("G39:R39");
				workmerge40.Merge();
				var workmerge41 = worksheet.Range("G40:R40");
				workmerge41.Merge();

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

				#region Set fontweight for Service report
				worksheet.Range("A1:R1").Style.Font.Bold = true;
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
				worksheet.Cell("C15").Value = Day1WorkTime;
				worksheet.Cell("D15").Value = Day2WorkTime;
				worksheet.Cell("E15").Value = Day3WorkTime;
				worksheet.Cell("F15").Value = Day4WorkTime;
				worksheet.Cell("G15").Value = Day5WorkTime;
				worksheet.Cell("H15").Value = Day6WorkTime;
				worksheet.Cell("I15").Value = Day7WorkTime;
				worksheet.Cell("J15").Value = Day8WorkTime;
				worksheet.Cell("K15").Value = Day9WorkTime;
				worksheet.Cell("L15").Value = Day10WorkTime;
				worksheet.Cell("M15").Value = Day11WorkTime;
				worksheet.Cell("N15").Value = Day12WorkTime;
				worksheet.Cell("O15").Value = Day13WorkTime;
				worksheet.Cell("P15").Value = Day14WorkTime;
				worksheet.Cell("R15").Value = WorkTotal;
				worksheet.Cell("A16").Value = "Travel";
				worksheet.Cell("C16").Value = Day1TravelTime;
				worksheet.Cell("D16").Value = Day2TravelTime;
				worksheet.Cell("E16").Value = Day3TravelTime;
				worksheet.Cell("F16").Value = Day4TravelTime;
				worksheet.Cell("G16").Value = Day5TravelTime;
				worksheet.Cell("H16").Value = Day6TravelTime;
				worksheet.Cell("I16").Value = Day7TravelTime;
				worksheet.Cell("J16").Value = Day8TravelTime;
				worksheet.Cell("K16").Value = Day9TravelTime;
				worksheet.Cell("L16").Value = Day10TravelTime;
				worksheet.Cell("M16").Value = Day11TravelTime;
				worksheet.Cell("N16").Value = Day12TravelTime;
				worksheet.Cell("O16").Value = Day13TravelTime;
				worksheet.Cell("P16").Value = Day14TravelTime;
				worksheet.Cell("R16").Value = TravelTotal;
				worksheet.Cell("A17").Value = "Total/Day";
				worksheet.Cell("L18").Value = "Total hours without travel back";
				worksheet.Cell("R18").Value = TotalWithoutTravelBackTime;
				worksheet.Cell("A19").Value = "Travel back";
				worksheet.Cell("C19").Value = Day1TravelBackTime;
				worksheet.Cell("D19").Value = Day2TravelBackTime;
				worksheet.Cell("E19").Value = Day3TravelBackTime;
				worksheet.Cell("F19").Value = Day4TravelBackTime;
				worksheet.Cell("G19").Value = Day5TravelBackTime;
				worksheet.Cell("H19").Value = Day6TravelBackTime;
				worksheet.Cell("I19").Value = Day7TravelBackTime;
				worksheet.Cell("J19").Value = Day8TravelBackTime;
				worksheet.Cell("K19").Value = Day9TravelBackTime;
				worksheet.Cell("L19").Value = Day10TravelBackTime;
				worksheet.Cell("M19").Value = Day11TravelBackTime;
				worksheet.Cell("N19").Value = Day12TravelBackTime;
				worksheet.Cell("O19").Value = Day13TravelBackTime;
				worksheet.Cell("P19").Value = Day14TravelBackTime;
				worksheet.Cell("R19").Value = TravelBackTotal;
				worksheet.Cell("L20").Value = "Total hours with travel back";
				worksheet.Cell("R20").Value = TotalAllTime;

				worksheet.Cell("A22").Value = "Order";

				worksheet.Cell("A26").Value = "Work description";
				worksheet.Cell("A27").Value = Day1MachineNumber;
				worksheet.Cell("A28").Value = Day2MachineNumber;
				worksheet.Cell("A29").Value = Day3MachineNumber;
				worksheet.Cell("A30").Value = Day4MachineNumber;
				worksheet.Cell("A31").Value = Day5MachineNumber;
				worksheet.Cell("A32").Value = Day6MachineNumber;
				worksheet.Cell("A33").Value = Day7MachineNumber;
				worksheet.Cell("A34").Value = Day8MachineNumber;
				worksheet.Cell("A35").Value = Day9MachineNumber;
				worksheet.Cell("A36").Value = Day10MachineNumber;
				worksheet.Cell("A37").Value = Day11MachineNumber;
				worksheet.Cell("A38").Value = Day12MachineNumber;
				worksheet.Cell("A39").Value = Day13MachineNumber;
				worksheet.Cell("A40").Value = Day14MachineNumber;
				worksheet.Cell("D27").Value = Day1date;
				worksheet.Cell("D28").Value = Day2date;
				worksheet.Cell("D29").Value = Day3date;
				worksheet.Cell("D30").Value = Day4date;
				worksheet.Cell("D31").Value = Day5date;
				worksheet.Cell("D32").Value = Day6date;
				worksheet.Cell("D33").Value = Day7date;
				worksheet.Cell("D34").Value = Day8date;
				worksheet.Cell("D35").Value = Day9date;
				worksheet.Cell("D36").Value = Day10date;
				worksheet.Cell("D37").Value = Day11date;
				worksheet.Cell("D38").Value = Day12date;
				worksheet.Cell("D39").Value = Day13date;
				worksheet.Cell("D40").Value = Day14date;
				worksheet.Cell("G27").Value = Day1Description;
				worksheet.Cell("G28").Value = Day2Description;
				worksheet.Cell("G29").Value = Day3Description;
				worksheet.Cell("G30").Value = Day4Description;
				worksheet.Cell("G31").Value = Day5Description;
				worksheet.Cell("G32").Value = Day6Description;
				worksheet.Cell("G33").Value = Day7Description;
				worksheet.Cell("G34").Value = Day8Description;
				worksheet.Cell("G35").Value = Day9Description;
				worksheet.Cell("G36").Value = Day10Description;
				worksheet.Cell("G37").Value = Day11Description;
				worksheet.Cell("G38").Value = Day12Description;
				worksheet.Cell("G39").Value = Day13Description;
				worksheet.Cell("G40").Value = Day14Description;
				worksheet.Cell("A42").Value = "Spare parts / Comments";

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
