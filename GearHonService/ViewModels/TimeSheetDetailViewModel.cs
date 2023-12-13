namespace GearHonService.ViewModels
{
	public partial class TimeSheetDetailViewModel : BaseViewModel
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
		private string value;
		[ObservableProperty]
		private TimeSpan startTime;
		[ObservableProperty]
		private TimeSpan endTime;

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

		public TimeSheetModel SelectedTimeSheet { get; set; }

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;
		private TimeSheetViewModel _timeSheetViewModel;

		public TimeSheetDetailViewModel(Supabase.Client supabaseClient, TimeSheetViewModel timeSheetViewModel)
		{
			_supabaseClient = supabaseClient;
			_timeSheetViewModel = timeSheetViewModel;

			//initialize lists
			Machines = new ObservableCollection<MachineModel>();
			Customers = new ObservableCollection<CustomerModel>();
			TimeSheets = new ObservableCollection<TimeSheetModel>();
			WorkTypes = new ObservableCollection<WorkTypeModel>();

			//set start and end date to today
			StartDate = DateTime.Now;
			EndDate = DateTime.Now;

			GetAllData();

			//Add worktypes to list
			WorkTypes.Add(new WorkTypeModel { Key = 1, Value = "Work" });
			WorkTypes.Add(new WorkTypeModel { Key = 5, Value = "Travel" });
		}

		//ToDo: Add update method if the id is not 0. Just similar to machine and customer update method
		[RelayCommand]
		public async Task Save()
		{
			if (selectedMachine == null || selectedCustomer == null)
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Please select a machine and a customer", "OK");
				return;
			}
			else
			{
				StartDate = StartDate.Date + StartTime;
				EndDate = StartDate.Date + EndTime;
				Hours = EndDate - StartDate;

				try
				{
					var newEntry = new TimeSheetModel
					{
						MachineId = selectedMachine.Id.ToString(),
						CustomerId = selectedCustomer.ID.ToString(),
						UId = UId,
						Description = Description,
						StartDate = StartDate,
						EndDate = EndDate,
						Hours = Hours,
						WorkStatus = "Stopped",
						WorkType = selectedWorkType.Value.ToString()
					};
					await _supabaseClient.From<TimeSheetModel>().Insert(newEntry);
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
				}

				ClearStrings();
				_timeSheetViewModel.RefreshList();
				_timeSheetViewModel.CheckLastEntry();

				await Shell.Current.GoToAsync($"//{nameof(TimeSheetPage)}");
			}
		}

		[RelayCommand]
		public async Task Delete()
		{
			SelectedTimeSheet = WeakReferenceManager.GetReference("SelectedTimeSheet") as TimeSheetModel;

			if (SelectedMachine.Id != 0)
			{
				try
				{
					await _supabaseClient
						.From<TimeSheetModel>()
						.Where(x => x.Id == Id)
						.Delete();
					await Application.Current.MainPage.DisplayAlert("Success", "Timesheet successfully deleted", "Ok");

					ClearStrings();

					await _timeSheetViewModel.RefreshList();
					await _timeSheetViewModel.CheckLastEntry();

					await Shell.Current.GoToAsync($"//{nameof(TimeSheetPage)}");
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error", "No Timesheet selected", "Ok");
			}
		}

		[RelayCommand]
		public async Task Cancel()
		{
			ClearStrings();
			await Shell.Current.GoToAsync($"//{nameof(TimeSheetPage)}");
		}

		public async Task GetAllData()
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

			//load customers
			var resultt = await _supabaseClient.From<TimeSheetModel>().Get();

			TimeSheets.Clear();
			foreach (var timesheet in resultt.Models)
			{
				TimeSheets.Add(timesheet);
			}

			//get current user
			UId = Preferences.Get("uid", string.Empty);
		}

		public void ClearStrings()
		{
			Id = 0;
			MachineId = 0;
			CustomerId = 0;
			CustomerName = string.Empty;
			UId = string.Empty;
			Description = string.Empty;
			StartDate = DateTime.Now;
			EndDate = DateTime.MinValue;
			Hours = TimeSpan.Zero;
			WorkStatus = string.Empty;
			WorkType = string.Empty;
			StartTime = TimeSpan.Zero;
			EndTime = TimeSpan.Zero;

			//empty the selected machine and customer
			SelectedMachine = null;
			SelectedCustomer = null;
			SelectedWorkType = null;
		}
	}
}
