using Postgrest.Attributes;
using Postgrest.Models;

namespace GearHonService.Models
{
	[Table("Contractor")]
	public class ContractorModel : BaseModel
	{
		[PrimaryKey("id")]
		public int ID { get; set; }

		[Column("UID")]
		public string UID { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Street")]
		public string Street { get; set; }

		[Column("City")]
		public string City { get; set; }

		[Column("ZipCode")]
		public string ZipCode { get; set; }

		[Column("Country")]
		public string Country { get; set; }

		[Column("Phone")]
		public string Phone { get; set; }

		[Column("Email")]
		public string Email { get; set; }

		[Column("Contact")]
		public string Contact { get; set; }

		[Column("HoursPerMonth")]
		public string HoursPerMonth { get; set; }

		[Column("PaymentPerMonth")]
		public string PaymentPerMonth { get; set; }

		[Column("PaymentOvertime")]
		public string PaymentOvertime { get; set; }

		[Column("PaymentPerHour")]
		public string PaymentPerHour { get; set; }

		[Column("PaymentTerms")]
		public string PaymentTerms { get; set; }

		[Column("PaymentMethod")]
		public string PaymentMethod { get; set; }

		[Column("PaymentBankAccount")]
		public string PaymentBankAccount { get; set; }

		[Column("PaymentBankName")]
		public string PaymentBankName { get; set; }

		[Column("PaymentBankSwift")]
		public string PaymentBankSwift { get; set; }

		[Column("PaymentBankIban")]
		public string PaymentBankIban { get; set; }

		[Column("Currency")]
		public string Currency { get; set; }

		[Column("ExpensePerDay")]
		public string ExpensePerDay { get; set; }

		[Column("ExpenseBreakfast")]
		public string ExpenseBreakfast { get; set; }

		[Column("ExpenseLunch")]
		public string ExpenseLunch { get; set; }

		[Column("ExpenseDinner")]
		public string ExpenseDinner { get; set; }

		[Column("ExpenseHotel")]
		public string ExpenseHotel { get; set; }

		[Column("TaxText")]
		public string TaxText { get; set; }

		[Column("TaxPercent")]
		public string TaxPercent { get; set; }
	}
}
