using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
    public partial class ContractorViewModel : BaseViewModel
	{
		//Currency
		[ObservableProperty] string code;
		[ObservableProperty] decimal rate;

		//Contractor
		[ObservableProperty] int iD;
		[ObservableProperty] string uID;
		[ObservableProperty] string name;
		[ObservableProperty] string street;
		[ObservableProperty] string city;
		[ObservableProperty] string zipCode;
		[ObservableProperty] string country;
		[ObservableProperty] string phone;
		[ObservableProperty] string email;
		[ObservableProperty] string contact;
		[ObservableProperty] string hoursPerMonth;
		[ObservableProperty] string paymentPerMonth;
		[ObservableProperty] string paymentOvertime;
		[ObservableProperty] string paymentPerHour;
		[ObservableProperty] string paymentTerms;
		[ObservableProperty] string paymentMethod;
		[ObservableProperty] string paymentBankAccount;
		[ObservableProperty] string paymentBankName;
		[ObservableProperty] string paymentBankSwift;
		[ObservableProperty] string paymentBankIban;
		[ObservableProperty] string currency;
		[ObservableProperty] string expensePerDay;
		[ObservableProperty] string expenseBreakfast;
		[ObservableProperty] string expenseLunch;
		[ObservableProperty] string expenseDinner;
		[ObservableProperty] string expenseHotel;
		[ObservableProperty] string taxText;
		[ObservableProperty] string taxPercent;

		[ObservableProperty]
		private ObservableCollection<ContractorModel> contractors;

		//Selections
		private ContractorModel selectedContractor;
		public ContractorModel SelectedContractor
		{
			get { return selectedContractor; }
			set { selectedContractor = value; }
		}

		private readonly Supabase.Client _supabaseClient;

		public ContractorViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			Contractors = new ObservableCollection<ContractorModel>();

			LoadContractorFromDb();
        }

		[RelayCommand]
		private async Task AddContractor()
		{
			await Shell.Current.GoToAsync($"//{nameof(ContractorDetailPage)}");
		}

		[RelayCommand]
        public async Task LoadContractorFromDb()
        {
			var result = await _supabaseClient.From<ContractorModel>().Get();
			Contractors.Clear();
			foreach (var contractor in result.Models)
			{
				Contractors.Add(contractor);
			}
		}

		[RelayCommand]
		private async Task ContractorSelectionChanged()
		{
			if (selectedContractor != null)
			{
				WeakReferenceManager.AddReference("SelectedContractor", SelectedContractor);

				//Go to ContractorDetailPage
				await Shell.Current.GoToAsync($"//{nameof(ContractorDetailPage)}");
			}
		}
    }
}
