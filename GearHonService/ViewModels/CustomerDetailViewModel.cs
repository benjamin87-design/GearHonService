namespace GearHonService.ViewModels
{
	public partial class CustomerDetailViewModel : BaseViewModel
	{
		//Strings
		[ObservableProperty]
		private int iD;
		[ObservableProperty]
		private string customerName;
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
		private string fullAddress;

		//Lists
		[ObservableProperty]
		private ObservableCollection<CustomerModel> customers;

		//Selected

		public CustomerModel SelectedCustomer { get; set; }

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;
		private CustomerViewModel _customeriewModel;
		public CustomerDetailViewModel(Supabase.Client supabaseClient, CustomerViewModel customerViewModel)
		{
			_supabaseClient = supabaseClient;
			_customeriewModel = customerViewModel;

			Customers = new ObservableCollection<CustomerModel>();

			GetSelectedCustomer();
		}

		[RelayCommand]
		public async Task Save()
		{
			if (ID == 0)
			{
				var insertCustomer = new CustomerModel
				{
					CustomerName = CustomerName,
					StreetName = StreetName,
					StreetNumber = StreetNumber,
					ZIPCode = ZIPCode,
					City = City,
					Country = Country
				};

				try
				{
					var insertResult = await _supabaseClient
					.From<CustomerModel>()
					.Insert(insertCustomer);
					await Application.Current.MainPage.DisplayAlert("Success", "Customer successfully added", "Ok");

					ClearStrings();

					await _customeriewModel.LoadCustomerFromDb();
					await Shell.Current.GoToAsync($"//{nameof(CustomerPage)}");
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
			else
			{
				var updateCustomer = new CustomerModel
				{
					ID = ID,
					CustomerName = CustomerName,
					StreetName = StreetName,
					StreetNumber = StreetNumber,
					ZIPCode = ZIPCode,
					City = City,
					Country = Country
				};

				try
				{
					var update = await _supabaseClient
						.From<CustomerModel>()
						.Where(x => x.ID == ID)
						.Set(x => x.CustomerName, CustomerName)
						.Set(x => x.StreetName, StreetName)
						.Set(x => x.StreetNumber, StreetNumber)
						.Set(x => x.ZIPCode, ZIPCode)
						.Set(x => x.City, City)
						.Set(x => x.Country, Country)
						.Update();
					await Application.Current.MainPage.DisplayAlert("Success", "Customer successfully updated", "Ok");

					ClearStrings();

					await _customeriewModel.LoadCustomerFromDb();
					await Shell.Current.GoToAsync($"//{nameof(CustomerPage)}");
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
		}

		[RelayCommand]
		public async Task Delete()
		{
			if (SelectedCustomer.ID != 0)
			{
				try
				{
					await _supabaseClient
						.From<CustomerModel>()
						.Where(x => x.ID == ID)
						.Delete();
					await Application.Current.MainPage.DisplayAlert("Success", "Customer successfully deleted", "Ok");

					ClearStrings();

					await _customeriewModel.LoadCustomerFromDb();
					await Shell.Current.GoToAsync($"//{nameof(CustomerPage)}");
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error", "No Customer selected", "Ok");
			}
		}

		[RelayCommand]
		private async Task Cancel()
		{
			ClearStrings();
			await Shell.Current.GoToAsync($"//{nameof(CustomerPage)}");
		}

		public void OnNavigatedTo()
		{
			GetSelectedCustomer();
		}

		public void GetSelectedCustomer()
		{
			SelectedCustomer = WeakReferenceManager.GetReference("SelectedCustomer") as CustomerModel;

			if(SelectedCustomer == null)
			{
				ClearStrings();
			}
			else
			{
				ID = _customeriewModel.SelectedCustomer.ID;
				CustomerName = _customeriewModel.SelectedCustomer.CustomerName;
				StreetName = _customeriewModel.SelectedCustomer.StreetName;
				StreetNumber = _customeriewModel.SelectedCustomer.StreetNumber;
				ZIPCode = _customeriewModel.SelectedCustomer.ZIPCode;
				City = _customeriewModel.SelectedCustomer.City;
				Country = _customeriewModel.SelectedCustomer.Country;
				FullAddress = _customeriewModel.SelectedCustomer.FullAddress;
			}
		}

		public void ClearStrings()
		{
			ID = 0;
			CustomerName = "";
			StreetName = "";
			StreetNumber = "";
			ZIPCode = "";
			City = "";
			Country = "";
			FullAddress = "";
		}
	}
}
