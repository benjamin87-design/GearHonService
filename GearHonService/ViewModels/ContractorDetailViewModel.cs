using GearHonService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
    public partial class ContractorDetailViewModel : BaseViewModel
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

		//Currency list
		[ObservableProperty]
		private ObservableCollection<CurrencyModel> currencies;

		//Selections
		private CurrencyModel selectedCurrency;
		public CurrencyModel SelectedCurrency
		{
			get { return selectedCurrency; }
			set { selectedCurrency = value; }
		}

		private ContractorModel selectedContractor;
		public ContractorModel SelectedContractor
		{
			get { return selectedContractor; }
			set { selectedContractor = value;}
		}

		//Service to load currency from ECBank
		private readonly CurrencyLoader _currencyLoader;
		private readonly Supabase.Client _supabaseClient;
		private ContractorViewModel _contractorViewModel;

		public ContractorDetailViewModel(Supabase.Client supabaseClient, CurrencyLoader currencyLoader, ContractorViewModel contractorViewModel)
		{
			_supabaseClient = supabaseClient;
			_currencyLoader = currencyLoader;
			_contractorViewModel = contractorViewModel;

			currencies = new ObservableCollection<CurrencyModel>();

			UID = Preferences.Get("uid", string.Empty);

			GetSelectedContractor();
			LoadCurrencies();
		}

		[RelayCommand]
		public async Task SaveCommand()
		{
			await SaveContractor();
		}

		[RelayCommand]
		public async Task SelectedCurrencyChanged()
		{
			Currency = SelectedCurrency.Code;
		}

		private async Task GetSelectedContractor()
		{
			SelectedContractor = WeakReferenceManager.GetReference("SelectedContractor") as ContractorModel;

			if (SelectedContractor == null)
			{
				ClearStrings();
			}
			else
			{
				UID = _contractorViewModel.SelectedContractor.UID;
				Name = _contractorViewModel.SelectedContractor.Name;
				Street = _contractorViewModel.SelectedContractor.Street;
				City = _contractorViewModel.SelectedContractor.City;
				ZipCode = _contractorViewModel.SelectedContractor.ZipCode;
				Country = _contractorViewModel.SelectedContractor.Country;
				Phone = _contractorViewModel.SelectedContractor.Phone;
				Email = _contractorViewModel.SelectedContractor.Email;
				Contact = _contractorViewModel.SelectedContractor.Contact;
				HoursPerMonth = _contractorViewModel.SelectedContractor.HoursPerMonth;
				PaymentPerMonth = _contractorViewModel.SelectedContractor.PaymentPerMonth;
				PaymentOvertime = _contractorViewModel.SelectedContractor.PaymentOvertime;
				PaymentPerHour = _contractorViewModel.SelectedContractor.PaymentPerHour;
				PaymentTerms = _contractorViewModel.SelectedContractor.PaymentTerms;
				PaymentMethod = _contractorViewModel.SelectedContractor.PaymentMethod;
				PaymentBankAccount = _contractorViewModel.SelectedContractor.PaymentBankAccount;
				PaymentBankName = _contractorViewModel.SelectedContractor.PaymentBankName;
				PaymentBankSwift = _contractorViewModel.SelectedContractor.PaymentBankSwift;
				PaymentBankIban = _contractorViewModel.SelectedContractor.PaymentBankIban;
				Currency = _contractorViewModel.SelectedContractor.Currency;
				ExpensePerDay = _contractorViewModel.SelectedContractor.ExpensePerDay;
				ExpenseBreakfast = _contractorViewModel.SelectedContractor.ExpenseBreakfast;
				ExpenseLunch = _contractorViewModel.SelectedContractor.ExpenseLunch;
				ExpenseDinner = _contractorViewModel.SelectedContractor.ExpenseDinner;
				ExpenseHotel = _contractorViewModel.SelectedContractor.ExpenseHotel;
				TaxText = _contractorViewModel.SelectedContractor.TaxText;
				TaxPercent = _contractorViewModel.SelectedContractor.TaxPercent;
			}
		}

		public async void OnNavigatedTo()
		{
			await GetSelectedContractor();
		}

		private async void LoadCurrencies()
		{
			try
			{
				Currencies.Add(new CurrencyModel { Code = "EUR", Rate = 1 });

				var currencies = await _currencyLoader.LoadCurrenciesAsync();

				foreach (var currency in currencies)
				{
					Currencies.Add(currency);
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		private async Task SaveContractor()
		{
			try
			{
				if(ID == 0)
				{
					var insertContractor = new ContractorModel
					{
						UID = UID,
						Name = Name,
						Street = Street,
						City = City,
						ZipCode = ZipCode,
						Country = Country,
						Phone = Phone,
						Email = Email,
						Contact = Contact,
						HoursPerMonth = HoursPerMonth,
						PaymentPerMonth = PaymentPerMonth,
						PaymentOvertime = PaymentOvertime,
						PaymentPerHour = PaymentPerHour,
						PaymentTerms = PaymentTerms,
						PaymentMethod = PaymentMethod,
						PaymentBankAccount = PaymentBankAccount,
						PaymentBankName = PaymentBankName,
						PaymentBankSwift = PaymentBankSwift,
						PaymentBankIban = PaymentBankIban,
						Currency = Currency,
						ExpensePerDay = ExpensePerDay,
						ExpenseBreakfast = ExpenseBreakfast,
						ExpenseLunch = ExpenseLunch,
						ExpenseDinner = ExpenseDinner,
						ExpenseHotel = ExpenseHotel,
						TaxText = TaxText,
						TaxPercent = TaxPercent
					};

					try
					{
						var insertResult = await _supabaseClient
						.From<ContractorModel>()
						.Insert(insertContractor);

						ClearStrings();

						await _contractorViewModel.LoadContractorFromDb();
						await Shell.Current.GoToAsync($"//{nameof(ContractorPage)}");
					}
					catch (Exception ex)
					{
						await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
					}
				}
				else
				{

				}
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		private void ClearStrings()
		{
			UID = string.Empty;
			Name = string.Empty;
			Street = string.Empty;
			City = string.Empty;
			ZipCode = string.Empty;
			Country = string.Empty;
			Phone = string.Empty;
			Email = string.Empty;
			Contact = string.Empty;
			HoursPerMonth = string.Empty;
			PaymentPerMonth = string.Empty;
			PaymentOvertime = string.Empty;
			PaymentPerHour = string.Empty;
			PaymentTerms = string.Empty;
			PaymentMethod = string.Empty;
			PaymentBankAccount = string.Empty;
			PaymentBankName = string.Empty;
			PaymentBankSwift = string.Empty;
			PaymentBankIban = string.Empty;
			Currency = string.Empty;
			ExpensePerDay = string.Empty;
			ExpenseBreakfast = string.Empty;
			ExpenseLunch = string.Empty;
			ExpenseDinner = string.Empty;
			ExpenseHotel = string.Empty;
			TaxText = string.Empty;
			TaxPercent = string.Empty;
		}
	}
}
