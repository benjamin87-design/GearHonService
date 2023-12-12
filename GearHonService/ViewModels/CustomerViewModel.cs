namespace GearHonService.ViewModels
{
	public partial class CustomerViewModel : BaseViewModel
	{
		[ObservableProperty]
		private int id;
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

		[ObservableProperty]
		private ObservableCollection<CustomerModel> customers;

		private CustomerModel selectedCustomer;
		public CustomerModel SelectedCustomer
		{
			get { return selectedCustomer; }
			set { selectedCustomer = value; }
		}

		private readonly Supabase.Client _supabaseClient;
		public CustomerViewModel(Supabase.Client supabaseClient)

		{
			_supabaseClient = supabaseClient;

			Customers = new ObservableCollection<CustomerModel>();

			LoadCustomerFromDb();
		}

		[RelayCommand]
		private async Task AddUpdateCustomer()
		{
			try
			{
				await Shell.Current.GoToAsync($"//{nameof(CustomerDetailPage)}");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		[RelayCommand]
		private async Task Export()
		{

		}

		[RelayCommand]
		private void CustomerSelectionChanged()
		{
			if (selectedCustomer != null)
			{
				WeakReferenceManager.AddReference("SelectedCustomer", SelectedCustomer);

				//Go to CustomerDetailPage
				Shell.Current.GoToAsync($"//{nameof(CustomerDetailPage)}");	
			}
		}

		[RelayCommand]
		public async Task LoadCustomerFromDb()
		{
			var result = await _supabaseClient.From<CustomerModel>().Get();
			Customers.Clear();
			foreach (var customer in result.Models)
			{
				customer.FullAddress = customer.StreetName + " " + customer.StreetNumber + ", " + customer.ZIPCode + " " + customer.City + ", " + customer.Country;
				Customers.Add(customer);
			}
		}
	}
}
