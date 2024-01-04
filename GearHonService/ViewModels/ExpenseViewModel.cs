using GearHonService.Services;

namespace GearHonService.ViewModels
{
	public partial class ExpenseViewModel : BaseViewModel
	{
		[ObservableProperty] private string name;
		[ObservableProperty] private string code;
		[ObservableProperty] private string type;
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
			set { selectedContractor = value; }
		}

		private ExpenseTypeModel selectedExpenseType;
		public ExpenseTypeModel SelectedExpenseType
		{
			get { return selectedExpenseType; }
			set { selectedExpenseType = value; }
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
		private void SelectedExpenseChanged()
		{
			//load selected expense to strings	
			ID = selectedExpense.ID;
			ContractorName = selectedExpense.ContractorName;
			UID = selectedExpense.UID;
			Date = selectedExpense.Date;
			ExpenseType = selectedExpense.ExpenseType;
			ExpenseAmount = selectedExpense.ExpenseAmount;
			ExpenseCurrency = selectedExpense.ExpenseCurrency;
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
						ContractorName = selectedContractor.Name,
						Date = Date,
						ExpenseType = selectedExpenseType.Type,
						ExpenseAmount = ExpenseAmount,
						ExpenseCurrency = selectedCurrency.Code
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
							.Set(x => x.ContractorName, selectedContractor.Name)
							.Set(x => x.UID, UID)
							.Set(x => x.Date, Date)
							.Set(x => x.ExpenseType, selectedExpenseType.Type)
							.Set(x => x.ExpenseAmount, ExpenseAmount)
							.Set(x => x.ExpenseCurrency, selectedCurrency.Code)
							.Update();

						await Shell.Current.DisplayAlert("Success", "Expense successfully updated", "Ok");

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
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 1, Type = "Daily allowance" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 2, Type = "Car" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 3, Type = "Train" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 4, Type = "Bus" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 5, Type = "Taxi" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 6, Type = "Flight" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 7, Type = "Hotel" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 8, Type = "Buisiness Dinner" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 9, Type = "Tools" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 10, Type = "Spare parts" });
			ExpenseTypes.Add(new ExpenseTypeModel { ID = 11, Type = "Other" });
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
				Currencies.Clear();

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
			Date = DateTime.Now;
			ExpenseType = string.Empty;
			ExpenseAmount = 0;
			ExpenseCurrency = string.Empty;
		}
	}
}
