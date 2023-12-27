using GearHonService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
	public partial class ExpenseViewModel : BaseViewModel
	{
		[ObservableProperty] private int iD;
		[ObservableProperty] private string contractorName;
		[ObservableProperty] private string uID;
		[ObservableProperty] private DateTime date;
		[ObservableProperty] private string expenseType;
		[ObservableProperty] private decimal expenseAmount;
		[ObservableProperty] private string expenseCurrency;

		[ObservableProperty]
		private ObservableCollection<ExpenseModel> expenses;
		[ObservableProperty]
		private ObservableCollection<ExpenseTypeModel> expenseTypes;
		[ObservableProperty]
		private ObservableCollection<CurrencyModel> currencies;
		[ObservableProperty]
		private ObservableCollection<ContractorModel> contractors;

		//Selection
		private ExpenseModel selectedExpense;
		public ExpenseModel SelectedExpense
		{
			get { return selectedExpense; }
			set { selectedExpense = value; }
		}

		private CurrencyModel selectedCurreny;
		public CurrencyModel SelectedCurrency
		{
			get { return selectedCurreny; }
			set { selectedCurreny = value; }
		}

		private ContractorModel selectedContractor;
		public ContractorModel SelectedContractor
		{
			get { return selectedContractor; }
			set { selectedContractor = value; }
		}

		private readonly Supabase.Client _supabaseClient;
		private readonly CurrencyLoader _currencyLoader;

		public ExpenseViewModel(Supabase.Client supabaseClient, CurrencyLoader currencyLoader)
		{
			_supabaseClient = supabaseClient;
			_currencyLoader = currencyLoader;

			UID = Preferences.Get("uid", string.Empty);
			Date = DateTime.Now;

			Expenses = new ObservableCollection<ExpenseModel>();
			ExpenseTypes = new ObservableCollection<ExpenseTypeModel>();
			Currencies = new ObservableCollection<CurrencyModel>();
			Contractors = new ObservableCollection<ContractorModel>();

			PopulateExpenseTypes();
			GetContractorFromDb();
			GetExpenseFromDb();
			GetCurrenies();
		}

		[RelayCommand]
		private void SelectedContractorChanged()
		{
			ContractorName = SelectedContractor.Name.ToString();
		}

		[RelayCommand]
		private void SelectedCurrencyChanged()
		{
			ExpenseCurrency = SelectedCurrency.Code.ToString();
		}

		[RelayCommand]
		private async Task Save()
		{
			try
			{
				if (ID == 0)
				{
					var insertExpense = new ExpenseModel
					{
						UID = UID,
						ContractorName = ContractorName,
						Date = Date,
						ExpenseType = ExpenseType,
						ExpenseAmount = ExpenseAmount,
						ExpenseCurrency = ExpenseCurrency
					};
					
					try
					{
						var insertResult = await _supabaseClient
						.From<ExpenseModel>()
						.Insert(insertExpense);

						ClearStrings();

						await GetExpenseFromDb();
					}
					catch (Exception ex)
					{
						await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
					}
				}
				else
				{
					try
					{
						var update = await _supabaseClient
							.From<ExpenseModel>()
							.Where(x => x.ID == ID)
							.Set(x => x.ContractorName, ContractorName)
							.Set(x => x.UID, UID)
							.Set(x => x.Date, Date)
							.Set(x => x.ExpenseType, ExpenseType)
							.Set(x => x.ExpenseAmount, ExpenseAmount)
							.Set(x => x.ExpenseCurrency, ExpenseCurrency)
							.Update();

						await Shell.Current.DisplayAlert("Success", "Contractor successfully updated", "Ok");

						ClearStrings();

						await GetExpenseFromDb();
					}
					catch (Exception ex)
					{
						await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		[RelayCommand]
		private async Task Delete()
		{
			if (SelectedExpense.ID != 0)
			{
				try
				{
					await _supabaseClient
						.From<ExpenseModel>()
						.Where(x => x.ID == ID)
						.Delete();
					await Shell.Current.DisplayAlert("Success", "Expense successfully deleted", "Ok");

					ClearStrings();

					await GetExpenseFromDb();
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
			else
			{
				await Shell.Current.DisplayAlert("Error", "No Expense selected", "Ok");
			}
		}

		private void PopulateExpenseTypes()
		{
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 1, Type = "Train" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 2, Type = "Bus" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 3, Type = "Taxi" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 4, Type = "Flight" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 5, Type = "Hotel" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 6, Type = "Buisiness Dinner" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 7, Type = "Tools" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 8, Type = "Spare parts" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 9, Type = "Other" });
		}

		private async Task GetExpenseFromDb()
		{
			var result = await _supabaseClient.From<ExpenseModel>().Get();
			Expenses.Clear();
			foreach (var expense in result.Models)
			{
				if (expense.UID == UID)
				{
					Expenses.Add(expense);
				}
			}
		}

		private async Task GetContractorFromDb()
		{
			var result = await _supabaseClient.From<ContractorModel>().Get();
			Contractors.Clear();
			foreach (var contractor in result.Models)
			{
				Contractors.Add(contractor);
			}
		}

		private async Task GetCurrenies()
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

		private void ClearStrings()
		{
			ID = 0;
			ContractorName = string.Empty;
			UID = string.Empty;
			Date = DateTime.Now;
			ExpenseType = string.Empty;
			ExpenseAmount = 0;
			ExpenseCurrency = string.Empty;
		}
	}
}
