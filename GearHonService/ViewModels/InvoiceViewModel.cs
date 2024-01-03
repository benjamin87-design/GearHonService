using DocumentFormat.OpenXml.Spreadsheet;
using GearHonService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
	public partial class InvoiceViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string? name;
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
		[ObservableProperty]
		private decimal? totalForWorkInMonth;
		[ObservableProperty]
		private string? code;
		[ObservableProperty]
		private string? invoiceCurrency;

		//invoice item
		[ObservableProperty]
		private string? description;
		[ObservableProperty]
		private string? ammount;
		[ObservableProperty]
		private string? ammountPrice;
		[ObservableProperty]
		private string? price;
		[ObservableProperty]
		private string? currency;

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
		[ObservableProperty]
		private string? userEmail;
		[ObservableProperty]
		private string? userPhone;

		[ObservableProperty]
		private string? bankName;
		[ObservableProperty]
		private string? accountName;
		[ObservableProperty]
		private string? iBAN;
		[ObservableProperty]
		private string? sWIFT;

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
		[ObservableProperty]
		private ObservableCollection<InvoiceItemModel>? invoiceItems;

		//selected items
		private ContractorModel? selectedContractor;
		public ContractorModel? SelectedContractor
		{
			get { return selectedContractor; }
			set { selectedContractor = value; }
		}

		//Supabase Client
		private readonly Supabase.Client _supabaseClient;
		private readonly CurrencyLoader _currencyLoader;

		public InvoiceViewModel(Supabase.Client supabaseClient, CurrencyLoader currencyLoader)
		{
			_supabaseClient = supabaseClient;
			_currencyLoader = currencyLoader;

			Contractors = new ObservableCollection<ContractorModel>();
			Users = new ObservableCollection<UserModel>();
			Servicereports = new ObservableCollection<ServiceReportModel>();
			Expenses = new ObservableCollection<ExpenseModel>();
			Currencies = new ObservableCollection<CurrencyModel>();
			InvoiceItems = new ObservableCollection<InvoiceItemModel>();

			InvoiceDateSelection = DateTime.Now;

			UID = Preferences.Get("uid", string.Empty);
			_ = GetContractor();
			_ = GetCurrencyExchangeRate();
			_ = GetInvoiceNumber();
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
			await GetCurrencySymbole();

			try
			{
				LoadInformations();
				try
				{
					await GetInvoiceItems();
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		private async Task GetInvoiceItems()
		{
			try
			{
				//get the total amount of hours worked in the month
				double workinghour = Servicereports.Sum(x => Convert.ToDouble(x.TotalHour));
				double workinghourpermonth = Convert.ToDouble(SelectedContractor.HoursPerMonth);

				double ammount = workinghour / workinghourpermonth;

				if(ammount > 1)
				{
					double overtime = workinghour - workinghourpermonth;
					double overtimepay = overtime * Convert.ToDouble(SelectedContractor.PaymentOvertime);
					double totalpayforwork = Convert.ToDouble(SelectedContractor.PaymentPerMonth) + overtimepay;
					double ammountprice = Convert.ToDouble(SelectedContractor.PaymentPerMonth);

					//add to invoice item list
					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammount.ToString("F"),
						AmmountPrice = ammountprice.ToString("F"),
						Price = totalpayforwork.ToString("F"),
						Description = "Service für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}
				else
				{
					double totalpayforwork = ammount * Convert.ToDouble(SelectedContractor.PaymentPerMonth);
					double ammountprice = Convert.ToDouble(SelectedContractor.PaymentPerMonth);

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammount.ToString("F"),
						AmmountPrice = ammountprice.ToString("F"),
						Price = totalpayforwork.ToString("F"),
						Description = "Service für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				if(Expenses.Where(x => x.ExpenseType == "Daily allowance").Count() > 0)
				{
					double ammountallowance = Expenses.Where(x => x.ExpenseType == "Daily allowance").Count();
					double paymentallowance = Convert.ToDouble(SelectedContractor.ExpensePerDay);
					double totalallowance = paymentallowance * ammountallowance;

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammountallowance.ToString("F"),
						AmmountPrice = paymentallowance.ToString("F"),
						Price = totalallowance.ToString("F"),
						Description = "Tagespauschale für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				if (Expenses.Where(x => x.ExpenseType == "Flight").Count() > 0)
				{
					double ammountflight= Expenses.Where(x => x.ExpenseType == "Flight").Count();

					//sum for each flight the total price in the right currency
					double totalflight = 0;
					foreach (var flight in Expenses.Where(x => x.ExpenseType == "Flight"))
					{
						decimal rate = Currencies.Where(x => x.Code == flight.ExpenseCurrency).First().Rate;
						double price = Convert.ToDouble(flight.ExpenseAmount) / Convert.ToDouble(rate);
						totalflight += price;
					}

					

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammountflight.ToString("F"),
						Price = totalflight.ToString("F"),
						Description = "Flugkosten für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}
				


			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
			}
		}

		//Get relevant data from database and EZB API
		private async Task GetAllDataFromDb()
		{
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
		private async Task GetContractor()
		{
			//load contractors
			try
			{
				var result = await _supabaseClient.From<ContractorModel>().Where(x => x.UID == UID).Get();
				if (Contractors != null)
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
		private async Task GetInvoiceNumber()
		{
			//count how may are already in invoice table from database
			var result = await _supabaseClient.From<InvoiceModel>().Get();
			InvoiceNumber = result.Models.Count + 1;
		}
		private async Task GetCurrencySymbole()
		{
			//load the currency symbole from internet depend on user currency selection
			var symbole = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
				.Select(culture => new RegionInfo(culture.Name))
				.GroupBy(region => region.ISOCurrencySymbol)
				.Select(group => group.First())
				.ToDictionary(region => region.ISOCurrencySymbol, region => region.CurrencySymbol);

			InvoiceCurrency = symbole[selectedContractor.Currency];
		}


		private void LoadInformations()
		{
			if (SelectedContractor != null)
			{
				//Contractor Information
				ContractorName = SelectedContractor.Name;
				ContractorStreet = SelectedContractor.Street;
				ContractorZipCode = SelectedContractor.ZipCode;
				ContractorCity = SelectedContractor.City;
				ContractorCountry = SelectedContractor.Country;

				//Bank Information
				BankName = SelectedContractor.PaymentBankName;
				AccountName = SelectedContractor.PaymentBankAccount;
				IBAN = SelectedContractor.PaymentBankIban;
				SWIFT = SelectedContractor.PaymentBankSwift;

				//TAX
				TaxText = SelectedContractor.TaxText;
				TaxPercentage = Convert.ToDecimal(SelectedContractor.TaxPercent);

				//Dates
				InvoiceDate = DateTime.Now;
				InvoiceDueDate = DateTime.Now.AddDays(Convert.ToInt32(SelectedContractor.PaymentTerms)).Date;
			}

			//user information
			if (Users != null)
			{
				UserName = Users.First().UserName;
				UserStreet = Users.First().StreetName + " " + Users.First().StreetNumber;
				UserZipCode = Users.First().ZIPCode;
				UserCity = Users.First().City;
				UserCountry = Users.First().Country;
				UserEmail = Users.First().Email;
				UserPhone = Users.First().Phone;
			}
		}
	}
}

