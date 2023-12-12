using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
	[Table("Customer")]
	public class CustomerModel : BaseModel
	{
		[PrimaryKey("id")]
		public int ID { get; set; }
		[Column("CustomerName")]
		public string CustomerName { get; set; }
		[Column("StreetName")]
		public string StreetName { get; set; }
		[Column("StreetNumber")]
		public string StreetNumber { get; set; }
		[Column("ZIPCode")]
		public string ZIPCode { get; set; }
		[Column("City")]
		public string City { get; set; }
		[Column("Country")]
		public string Country { get; set; }
		[Column("FullAddress")]
		public string FullAddress { get; set; }
	}
}