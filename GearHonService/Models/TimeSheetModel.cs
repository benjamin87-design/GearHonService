using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
	[Table("TimeSheet")]
	public class TimeSheetModel : BaseModel
	{
		[PrimaryKey("id")]
		public int Id { get; set; }

		[Column("MachineId")]
		public string MachineId { get; set; }
		[Column("CustomerId")]
		public string CustomerId { get; set; }

		[Column("UId")]
		public string UId { get; set; }

		[Column("Description")]
		public string Description { get; set; }

		[Column("StartDate")]
		public DateTime StartDate { get; set; }

		[Column("EndDate")]
		public DateTime EndDate { get; set; }

		[Column("Hours")]
		public TimeSpan Hours { get; set; }

		[Column("WorkStatus")]
		public string WorkStatus { get; set; }

		[Column("WorkType")]
		public string WorkType { get; set; }


		public string MachineNumber { get;set; }
		public string CustomerName { get; set; }
	}
}
