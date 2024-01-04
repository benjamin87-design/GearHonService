using Postgrest.Attributes;
using Postgrest.Models;

namespace GearHonService.Models
{
	[Table("Invoice")]
	public class InvoiceModel : BaseModel
	{
		[PrimaryKey("id")]
		public int ID { get; set; }
		[Column("UID")]
		public string UID { get; set; }
		[Column("InvoiceNumber")]
		public int InvoiceNumber { get; set; }
		[Column("InvoiceDate")]
		public DateTime InvoiceDate { get; set; }
		[Column("InvoiceDueDate")]
		public DateTime InvoiceDueDate { get; set; }
		[Column("InvoiceTotal")]
		public string InvoiceTotal { get; set; }
	}
}
