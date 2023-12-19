using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
	[Table("User")]
	public class UserModel : BaseModel
	{
		[PrimaryKey("id")]
		public int ID { get; set; }
		[Column("UserName")]
		public string UserName { get; set; }
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
		[Column("Phone")]
		public string Phone { get; set; }
		[Column("Email")]
		public string Email { get; set; }
		[Column("UserId")]
		public string UserId { get; set; }
	}
}
