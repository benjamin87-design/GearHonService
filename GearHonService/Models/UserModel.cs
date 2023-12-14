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
		[Column("Location")]
		public string Location { get; set; }
		[Column("Email")]
		public string Email { get; set; }
		[Column("Phone")]
		public string Phone { get; set; }
		[Column("UserId")]
		public string UserId { get; set; }
	}
}
