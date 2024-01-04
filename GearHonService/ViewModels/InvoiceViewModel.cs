using DocumentFormat.OpenXml.Office2010.Excel;
using GearHonService.Services;
using System.Globalization;

namespace GearHonService.ViewModels
{
	public partial class InvoiceViewModel : BaseViewModel
	{
		[ObservableProperty]
		private int iD;
		[ObservableProperty]
		private string name;
		[ObservableProperty]
		private int invoiceId;
		[ObservableProperty]
		private string uID;
		[ObservableProperty]
		private DateTime invoiceDateSelection;
		[ObservableProperty]
		private string invoiceMonth;
		[ObservableProperty]
		private string invoiceYear;
		[ObservableProperty]
		private decimal workingHours;
		[ObservableProperty]
		private decimal totalExpenseInMonth;
		[ObservableProperty]
		private double totalForWorkInMonth;
		[ObservableProperty]
		private string code;
		[ObservableProperty]
		private string invoiceCurrency;

		//invoice item
		[ObservableProperty]
		private string description;
		[ObservableProperty]
		private string ammount;
		[ObservableProperty]
		private string ammountPrice;
		[ObservableProperty]
		private string price;
		[ObservableProperty]
		private string currency;

		[ObservableProperty]
		private string contractorName;
		[ObservableProperty]
		private string contractorStreet;
		[ObservableProperty]
		private string contractorCity;
		[ObservableProperty]
		private string contractorZipCode;
		[ObservableProperty]
		private string contractorCountry;

		[ObservableProperty]
		private string userName;
		[ObservableProperty]
		private string userStreet;
		[ObservableProperty]
		private string userCity;
		[ObservableProperty]
		private string userZipCode;
		[ObservableProperty]
		private string userCountry;
		[ObservableProperty]
		private string userEmail;
		[ObservableProperty]
		private string userPhone;

		[ObservableProperty]
		private string bankName;
		[ObservableProperty]
		private string accountName;
		[ObservableProperty]
		private string iBAN;
		[ObservableProperty]
		private string sWIFT;

		[ObservableProperty]
		private int invoiceNumber;
		[ObservableProperty]
		private DateTime invoiceDate;
		[ObservableProperty]
		private string invoiceDueDate;
		[ObservableProperty]
		private string invoicePaymentTerms;
		[ObservableProperty]
		private string invoicePaymentMethod;
		[ObservableProperty]
		private decimal invoiceTotal;
		[ObservableProperty]
		private decimal taxPercentage;
		[ObservableProperty]
		private decimal taxAmount;
		[ObservableProperty]
		private string taxText;
		[ObservableProperty]
		private string invoiceGrandTotal;

		[ObservableProperty]
		private bool isRunning;
		[ObservableProperty]
		private bool invoiceVisible;

		[ObservableProperty]
		private ObservableCollection<ContractorModel> contractors;
		[ObservableProperty]
		private ObservableCollection<UserModel> users;
		[ObservableProperty]
		private ObservableCollection<ServiceReportModel> servicereports;
		[ObservableProperty]
		private ObservableCollection<ExpenseModel> expenses;
		[ObservableProperty]
		private ObservableCollection<CurrencyModel> currencies;
		[ObservableProperty]
		private ObservableCollection<InvoiceItemModel> invoiceItems;

		//selected items
		private ContractorModel selectedContractor;
		public ContractorModel SelectedContractor
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

			InvoiceDateSelection = DateTime.Now;
			UID = Preferences.Get("uid", string.Empty);

			IsRunning = false;
			InvoiceVisible = false;

			Contractors = new ObservableCollection<ContractorModel>();
			Users = new ObservableCollection<UserModel>();
			Servicereports = new ObservableCollection<ServiceReportModel>();
			Expenses = new ObservableCollection<ExpenseModel>();
			Currencies = new ObservableCollection<CurrencyModel>();
			InvoiceItems = new ObservableCollection<InvoiceItemModel>();

			_ = GetContractorFromDb();
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
			if(selectedContractor != null)
			{
				IsRunning = true;
				await GetAllDataFromDb();
				await GetCurrencySymbole();
				await GetInvoiceNumber();

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
				IsRunning = false;
				InvoiceVisible = true;
			}
			else
			{
				await Shell.Current.DisplayAlert("Error", "Bitte wählen Sie einen Auftraggeber aus", "OK");
			}
		}

		public async Task SaveInvoice()
		{
			//save invoice to database
			try
			{
				if (ID == 0)
				{
					var insertInvoice = new InvoiceModel
					{
						UID = UID,
						InvoiceNumber = InvoiceNumber,
						InvoiceDate = InvoiceDate,
						InvoiceDueDate = Convert.ToDateTime(InvoiceDueDate),
						InvoiceTotal = InvoiceGrandTotal
					};

					try
					{
						var insertResult = await _supabaseClient
						.From<InvoiceModel>()
						.Insert(insertInvoice);

						await Shell.Current.DisplayAlert("Success", "Invoice successfully added", "Ok");
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

					TotalForWorkInMonth = totalpayforwork;
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

					TotalForWorkInMonth = totalpayforwork;
				}

				if (Expenses.Where(x => x.ExpenseType == "Daily allowance").Any())
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

				if (Expenses.Where(x => x.ExpenseType == "Flight").Any())
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

				if (Expenses.Where(x => x.ExpenseType == "Taxi").Any())
				{
					double ammounttaxi = Expenses.Where(x => x.ExpenseType == "Taxi").Count();

					//sum for each taxi the total price in the right currency
					double totaltaxi = 0;
					foreach (var taxi in Expenses.Where(x => x.ExpenseType == "Taxi"))
					{
						decimal rate = Currencies.Where(x => x.Code == taxi.ExpenseCurrency).First().Rate;
						double price = Convert.ToDouble(taxi.ExpenseAmount) / Convert.ToDouble(rate);
						totaltaxi += price;
					}

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammounttaxi.ToString("F"),
						Price = totaltaxi.ToString("F"),
						Description = "Taxikosten für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				if (Expenses.Where(x => x.ExpenseType == "Train").Any())
				{
					double ammounttrain = Expenses.Where(x => x.ExpenseType == "Train").Count();

					//sum for each train the total price in the right currency
					double totaltrain = 0;
					foreach (var train in Expenses.Where(x => x.ExpenseType == "Train"))
					{
						decimal rate = Currencies.Where(x => x.Code == train.ExpenseCurrency).First().Rate;
						double price = Convert.ToDouble(train.ExpenseAmount) / Convert.ToDouble(rate);
						totaltrain += price;
					}

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammounttrain.ToString("F"),
						Price = totaltrain.ToString("F"),
						Description = "Zugkosten für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				if (Expenses.Where(x => x.ExpenseType == "Car").Any())
				{
					double ammountcar = Expenses.Where(x => x.ExpenseType == "Car").Count();

					//sum for each Car the total price in the right currency
					double totalcar = 0;
					foreach (var car in Expenses.Where(x => x.ExpenseType == "Car"))
					{
						decimal rate = Currencies.Where(x => x.Code == car.ExpenseCurrency).First().Rate;
						double price = Convert.ToDouble(car.ExpenseAmount) / Convert.ToDouble(rate);
						totalcar += price;
					}

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammountcar.ToString("F"),
						Price = totalcar.ToString("F"),
						Description = "Autokosten für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				if (Expenses.Where(x => x.ExpenseType == "Bus").Any())
				{
					double ammountbus = Expenses.Where(x => x.ExpenseType == "Bus").Count();

					//sum for each Bus the total price in the right currency
					double totalbus = 0;
					foreach (var bus in Expenses.Where(x => x.ExpenseType == "Bus"))
					{
						decimal rate = Currencies.Where(x => x.Code == bus.ExpenseCurrency).First().Rate;
						double price = Convert.ToDouble(bus.ExpenseAmount) / Convert.ToDouble(rate);
						totalbus += price;
					}

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammountbus.ToString("F"),
						Price = totalbus.ToString("F"),
						Description = "Buskosten für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				if (Expenses.Where(x => x.ExpenseType == "Hotel").Any())
				{
					double ammounthotel = Expenses.Where(x => x.ExpenseType == "Hotel").Count();

					//sum for each hotel the total price in the right currency
					double totalhotel = 0;
					foreach (var hotel in Expenses.Where(x => x.ExpenseType == "Hotel"))
					{
						decimal rate = Currencies.Where(x => x.Code == hotel.ExpenseCurrency).First().Rate;
						double price = Convert.ToDouble(hotel.ExpenseAmount) / Convert.ToDouble(rate);
						totalhotel += price;
					}

					InvoiceItems.Add(new InvoiceItemModel
					{
						Ammount = ammounthotel.ToString("F"),
						Price = totalhotel.ToString("F"),
						Description = "Hotelkosten für den Zeitraum" + " " + InvoiceMonth + "." + InvoiceYear + " " + "gemäss Anlage",
						Currency = InvoiceCurrency
					});
				}

				//sum all expenses
				double totalexpense = 0;
				foreach (var expense in Expenses)
				{
					decimal rate = Currencies.Where(x => x.Code == expense.ExpenseCurrency).First().Rate;
					double price = Convert.ToDouble(expense.ExpenseAmount) / Convert.ToDouble(rate);
					totalexpense += price;
				}

				//sum expenses and total for work
				double grandtotal = totalexpense + TotalForWorkInMonth;
				InvoiceGrandTotal = grandtotal.ToString("F") + InvoiceCurrency;
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
				var result = await _supabaseClient.From<ServiceReportModel>().Where(x => x.UID == UID).Get();
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
				var result = await _supabaseClient.From<ExpenseModel>().Where(x => x.UID == UID).Get();
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
		private async Task GetContractorFromDb()
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
		private async Task GetInvoiceNumber()
		{
			//get the last invoicenumber from database and add 1
			try
			{
				//get last invoice number
				var result = await _supabaseClient.From<InvoiceModel>().Where(x => x.UID == UID).Get();
				if (result.Models.Count > 0)
				{
					InvoiceNumber = result.Models.Last().InvoiceNumber + 1;
				}
				else
				{
					InvoiceNumber = 1;
				}
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
		}
		private async Task GetCurrencySymbole()
		{
			try
			{
				//load the currency symbole from internet depend on user currency selection
				var symbole = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
					.Select(culture => new RegionInfo(culture.Name))
					.GroupBy(region => region.ISOCurrencySymbol)
					.Select(group => group.First())
					.ToDictionary(region => region.ISOCurrencySymbol, region => region.CurrencySymbol);

				InvoiceCurrency = symbole[selectedContractor.Currency];
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
			}
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
				InvoiceDueDate = DateTime.Now.AddDays(Convert.ToInt32(SelectedContractor.PaymentTerms)).ToShortDateString();
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

