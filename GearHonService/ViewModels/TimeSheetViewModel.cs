namespace GearHonService.ViewModels
{
	public partial class TimeSheetViewModel : BaseViewModel
	{
		//Strings
		[ObservableProperty]
		private int id;
		[ObservableProperty]
		private int machineId;
		[ObservableProperty]
		private string machineNumber;
		[ObservableProperty]
		private int customerId;
		[ObservableProperty]
		private string customerName;
		[ObservableProperty]
		private string uId;
		[ObservableProperty]
		private string description;
		[ObservableProperty]
		private DateTime startDate;
		[ObservableProperty]
		private DateTime endDate;
		[ObservableProperty]
		private TimeSpan hours;
		[ObservableProperty]
		private string workStatus;
		[ObservableProperty]
		private string workType;
		[ObservableProperty]
		private TimeSpan startTime;
		[ObservableProperty]
		private TimeSpan endTime;
		[ObservableProperty]
		private string value;

		[ObservableProperty]
		private bool startVisible;
		[ObservableProperty]
		private bool stopVisible;

		//Lists
		[ObservableProperty]
		private ObservableCollection<MachineModel> machines;
		[ObservableProperty]
		private ObservableCollection<CustomerModel> customers;
		[ObservableProperty]
		private ObservableCollection<TimeSheetModel> timeSheets;
		[ObservableProperty]
		private ObservableCollection<WorkTypeModel> workTypes;

		//Selected
		private MachineModel selectedMachine;
		public MachineModel SelectedMachine
		{
			get { return selectedMachine; }
			set { selectedMachine = value; }
		}

		private CustomerModel selectedCustomer;
		public CustomerModel SelectedCustomer
		{
			get { return selectedCustomer; }
			set { selectedCustomer = value; }
		}

		private WorkTypeModel selectedWorkType;
		public WorkTypeModel SelectedWorkType
		{
			get { return selectedWorkType; }
			set { selectedWorkType = value; }
		}

		//Selected
		private TimeSheetModel selectedTimeSheet;
		public TimeSheetModel SelectedTimeSheet
		{
			get { return selectedTimeSheet; }
			set { selectedTimeSheet = value; }
		}

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;

		public TimeSheetViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			//Initialize Lists
			Machines = new ObservableCollection<MachineModel>();
			Customers = new ObservableCollection<CustomerModel>();
			TimeSheets = new ObservableCollection<TimeSheetModel>();
			WorkTypes = new ObservableCollection<WorkTypeModel>();

			//Load Data
			LoadAllData();
			CheckLastEntry();

			//Add worktypes to list
			WorkTypes.Add(new WorkTypeModel { Key = 1, Value = "Work" });
			WorkTypes.Add(new WorkTypeModel { Key = 5, Value = "Travel" });
		}

		[RelayCommand]
		public async Task StartWork()
		{
			//check if the last entry is still running
			var result = await _supabaseClient.From<TimeSheetModel>().Get();
			var lastEntry = result.Models.LastOrDefault();

			if (selectedMachine == null || selectedCustomer == null)
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Please select a machine and a customer", "OK");
				return;
			}
			else
			{
				var newEntry = new TimeSheetModel
				{
					MachineId = selectedMachine.Id.ToString(),
					MachineNumber = selectedMachine.MachineNumber.ToString(),
					CustomerId = selectedCustomer.ID.ToString(),
					CustomerName = selectedCustomer.CustomerName.ToString(),
					UId = UId,
					Description = Description,
					StartDate = DateTime.Now,
					EndDate = DateTime.MinValue,
					Hours = TimeSpan.Zero,
					WorkStatus = "Running",
					WorkType = selectedWorkType.Value.ToString()
				};
				await _supabaseClient.From<TimeSheetModel>().Insert(newEntry);

				CheckLastEntry();
			}
		}

		[RelayCommand]
		public async Task StopWork()
		{
			//check if the last entry is running
			var result = await _supabaseClient.From<TimeSheetModel>().Get();
			var lastEntry = result.Models.LastOrDefault();

			if (lastEntry?.WorkStatus == "Running")
			{
				try
				{
					//Update the last entry based on his id and set the end date and hours
					var updateEntry = new TimeSheetModel
					{
						Id = lastEntry.Id,
						MachineId = lastEntry.MachineId,
						MachineNumber = lastEntry.MachineNumber,
						CustomerId = lastEntry.CustomerId,
						CustomerName = lastEntry.CustomerName,
						UId = lastEntry.UId,
						Description = lastEntry.Description,
						StartDate = lastEntry.StartDate,
						EndDate = DateTime.Now,
						Hours = DateTime.Now - lastEntry.StartDate,
						WorkStatus = "Stopped",
						WorkType = lastEntry.WorkType
					};
					await _supabaseClient.From<TimeSheetModel>().Update(updateEntry);
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
				}
				RefreshList();
				CheckLastEntry();
			}
		}

		[RelayCommand]
		public async Task AddPastWork()
		{
			try
			{
				//Go to TimeSheetDetailPage
				await Shell.Current.GoToAsync($"//{nameof(TimeSheetDetailPage)}");
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		[RelayCommand]
		public async Task TimeSheetSelectionChanged()
		{
			if (selectedTimeSheet != null)
			{
				WeakReferenceManager.AddReference("SelectedTimeSheet", SelectedTimeSheet);

				//Go to TimeSheetDetailPage
				await Shell.Current.GoToAsync($"//{nameof(TimeSheetDetailPage)}");
			}
		}

		public void ClearStrings()
		{
			StartDate = DateTime.Now;
			Description = string.Empty;
			EndDate = DateTime.MinValue;
			//empty the selected machine and customer
			SelectedMachine = null;
			SelectedCustomer = null;
			SelectedWorkType = null;
			Hours = TimeSpan.Zero;
			WorkStatus = string.Empty;
		}

		public async Task CheckLastEntry()
		{
			var result = await _supabaseClient.From<TimeSheetModel>().Get();
			var lastEntry = result.Models.LastOrDefault();

			switch (lastEntry?.WorkStatus)
			{
				case "Running":
					StopVisible = true;
					StartVisible = false;
					break;
				default:
					StartVisible = true;
					StopVisible = false;
					break;
			}
		}

		private async Task LoadData()
		{
			//load machines
			var resultm = await _supabaseClient.From<MachineModel>().Get();

			Machines.Clear();
			foreach (var machine in resultm.Models)
			{
				Machines.Add(machine);
			}

			//load customers
			var resultc = await _supabaseClient.From<CustomerModel>().Get();

			Customers.Clear();
			foreach (var customer in resultc.Models)
			{
				Customers.Add(customer);
			}

			//load timesheets
			var resultt = await _supabaseClient.From<TimeSheetModel>().Get();

			TimeSheets.Clear();
			foreach (var timesheet in resultt.Models)
			{
				var machine = Machines.FirstOrDefault(m => m.Id == Convert.ToUInt32(timesheet.MachineId));
				var customer = Customers.FirstOrDefault(c => c.ID == Convert.ToUInt32(timesheet.CustomerId));
				timesheet.MachineNumber = machine?.MachineNumber;
				timesheet.CustomerName = customer?.CustomerName;
				TimeSheets.Add(timesheet);
			}

			//get current user
			UId = Preferences.Get("uid", string.Empty);
		}

		public async Task LoadAllData()
		{
			await LoadData();
		}

		[RelayCommand]
		public async Task RefreshList()
		{
			//load timesheets
			var resultt = await _supabaseClient.From<TimeSheetModel>().Get();

			TimeSheets.Clear();
			foreach (var timesheet in resultt.Models)
			{
				var machine = Machines.FirstOrDefault(m => m.Id == Convert.ToUInt32(timesheet.MachineId));
				var customer = Customers.FirstOrDefault(c => c.ID == Convert.ToUInt32(timesheet.CustomerId));
				timesheet.MachineNumber = machine?.MachineNumber;
				timesheet.CustomerName = customer?.CustomerName;
				TimeSheets.Add(timesheet);
			}
		}
	}
}
