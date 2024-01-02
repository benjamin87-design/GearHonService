using DocumentFormat.OpenXml.Spreadsheet;
using GearHonService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
	public partial class InvoiceViewModel : BaseViewModel
	{
		[ObservableProperty]
		private int invoiceId;
		[ObservableProperty]
		private string? uID;
		[ObservableProperty]
		private DateTime invoiceDateSelection;
		[ObservableProperty]
		private string? invoiceMonth;
		[ObservableProperty]
		private string? invoiceYear;
		[ObservableProperty]
		private decimal? workingHours;
		[ObservableProperty]
		private decimal? totalExpenseInMonth;

		//address contractor
		[ObservableProperty]
		private string? contractorName;
		[ObservableProperty]
		private string? contractorStreet;
		[ObservableProperty]
		private string? contractorCity;
		[ObservableProperty]
		private string? contractorZipCode;
		[ObservableProperty]
		private string? contractorCountry;

		//address user
		[ObservableProperty]
		private string? userName;
		[ObservableProperty]
		private string? userStreet;
		[ObservableProperty]
		private string? userCity;
		[ObservableProperty]
		private string? userZipCode;
		[ObservableProperty]
		private string? userCountry;

		//Bank information
		[ObservableProperty]
		private string? bankName;
		[ObservableProperty]
		private string? accountName;
		[ObservableProperty]
		private string? iBAN;
		[ObservableProperty]
		private string? sWIFT;

		//Ivoice information
		[ObservableProperty]
		private int invoiceNumber;
		[ObservableProperty]
		private DateTime invoiceDate;
		[ObservableProperty]
		private DateTime invoiceDueDate;
		[ObservableProperty]
		private string? invoicePaymentTerms;
		[ObservableProperty]
		private string? invoicePaymentMethod;
		[ObservableProperty]
		private decimal invoiceTotal;
		[ObservableProperty]
		private decimal taxPercentage;
		[ObservableProperty]
		private decimal taxAmount;
		[ObservableProperty]
		private string? taxText;
		[ObservableProperty]
		private decimal invoiceGrandTotal;

		[ObservableProperty]
		private ObservableCollection<ContractorModel>? contractors;
		[ObservableProperty]
		private ObservableCollection<UserModel>? users;
		[ObservableProperty]
		private ObservableCollection<ServiceReportModel>? servicereports;
		[ObservableProperty]
		private ObservableCollection<ExpenseModel>? expenses;
		[ObservableProperty]
		private ObservableCollection<CurrencyModel>? currencies;

		public ContractorModel? SelectedContractor { get; set; }
		public UserModel? SelectedUser { get; set; }
		public ServiceReportModel? SelectedServiceReport { get; set; }

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;
		private readonly CurrencyLoader _currencyLoader;

		public InvoiceViewModel(Supabase.Client supabaseClient, CurrencyLoader currencyLoader)
		{
			_supabaseClient = supabaseClient;
			_currencyLoader = currencyLoader;

			contractors = new ObservableCollection<ContractorModel>();
			users = new ObservableCollection<UserModel>();
			servicereports = new ObservableCollection<ServiceReportModel>();
			expenses = new ObservableCollection<ExpenseModel>();
			currencies = new ObservableCollection<CurrencyModel>();

			InvoiceDateSelection = DateTime.Now;

			UID = Preferences.Get("uid", string.Empty);
		}

		[RelayCommand]
		private void MonthAndYearChanged()
		{
			InvoiceMonth = InvoiceDateSelection.Month.ToString();
			InvoiceYear = InvoiceDateSelection.Year.ToString();
		}

		[RelayCommand]
		private async Task CreateInvoice()
		{
			await GetAllDataFromDb();

			try
			{
				CalculateInvoiceGrandTotal();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void CalculateInvoiceGrandTotal()
		{

		}

		private async Task TotalExpense()
		{
			await GetCurrencyExchangeRate();

			//group all expenses by currency and sum each group
			var totalExpense = Expenses.GroupBy(x => x.ExpenseCurrency).Select(x => new { Currency = x.Key, Total = x.Sum(y => y.ExpenseAmount) });

			//convert each currency to euro and sum all up
			decimal totalExpenseInEuro = 0;
			foreach (var expense in totalExpense)
			{
				var currency = Currencies.FirstOrDefault(x => x.Code == expense.Currency);
				if (currency != null)
				{
					totalExpenseInEuro += expense.Total / currency.Rate;
				}
			}

			TotalExpenseInMonth = totalExpenseInEuro;
		}

		private void TotalHours()
		{
			decimal totalHours = Servicereports.Sum(servicereport => Convert.ToDecimal(servicereport.TotalHour));
			WorkingHours = totalHours;
		}

		private void TotalForWork()
		{

		}

		private async Task GetAllDataFromDb()
		{
			//load contractors
			try
			{
				var result = await _supabaseClient.From<ContractorModel>().Get();
				if(Contractors != null)
				{
					Contractors.Clear();
				}

				foreach (var contractor in result.Models)
				{
					Contractors?.Add(contractor);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//load user
			try
			{
				var result = await _supabaseClient.From<UserModel>().Where(x => x.UserId == UID).Get();
				if (Users != null)
				{
					Users.Clear();
				}

				foreach (var user in result.Models)
				{
					Users?.Add(user);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//Load Servicereports within the right month and year
			try
			{
				var result = await _supabaseClient.From<ServiceReportModel>().Get();
				if (Servicereports != null)
				{
					Servicereports.Clear();
				}

				foreach (var servicereport in result.Models)
				{
					if (servicereport.Month == InvoiceMonth && servicereport.Year == InvoiceYear)
					{
						Servicereports?.Add(servicereport);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//load expenses within the right month and year
			try
			{
				var result = await _supabaseClient.From<ExpenseModel>().Get();
				if (Expenses != null)
				{
					Expenses.Clear();
				}

				foreach (var expense in result.Models)
				{
					if (expense.Date.Month == InvoiceDateSelection.Month && expense.Date.Year == InvoiceDateSelection.Year)
					{
						Expenses?.Add(expense);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private async Task GetCurrencyExchangeRate()
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
	}
}
