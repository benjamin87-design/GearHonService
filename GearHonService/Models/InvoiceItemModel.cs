using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
	public partial class InvoiceItemModel
	{
		public int ID { get; set; }
		public string Ammount { get; set; }
		public string AmmountPrice { get; set; }
		public string Price { get; set; }
		public string Description { get; set; }
		public string Currency { get; set; }
	}
}
