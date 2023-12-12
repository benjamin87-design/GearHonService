using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
	public class ContractorModel
	{
		public int ID { get; set; }
		public string ContractorName { get; set; }
		public string ContractorStreet { get; set; }
		public string ContractorCity { get; set; }
		public string ContractorZipCode { get; set; }
		public string ContractorCountry { get; set; }
		public string ContractorPhone { get; set; }
		public string ContractorEmail { get; set; }
		public string ContractorContact { get; set; }

		public string ContractorHoursPerMonth { get; set; }
		public string ContractorPaymentPerMonth { get; set; }
		public string ContractorPaymentOvertime { get; set; }
		public string ContractorPaymentPerHour { get; set; }

		public string ContractorPaymentTerms { get; set; }
		public string ContractorPaymentMethod { get; set; }
		public string ContractorPaymentBankAccount { get; set; }
		public string ContractorPaymentBankName { get; set; }
		public string ContractorPaymentBankSwift { get; set; }
		public string ContractorPaymentBankIban { get; set; }
		public string ContractorCurrency { get; set; }

		public string ContractorExpensePerDay { get; set; }
		public string ContractorExpenseBreakfast { get; set; }
		public string ContractorExpenseLunch { get; set; }
		public string ContractorExpenseDinner { get; set; }
		public string ContractorExpenseHotel { get; set; }

		public string ContractorTaxText { get; set; }
		public string ContractorTaxPercent { get; set; }
	}
}
