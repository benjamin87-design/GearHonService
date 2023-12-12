using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
	[Table("Machine")]
	public class MachineModel : BaseModel
	{
		[PrimaryKey("id")]
		public int Id { get; set; }

		[Column("MachineNumber")]
		public string MachineNumber { get; set; }
		[Column("CustomerName")]
		public string CustomerName { get; set; }
		[Column("MachineType")]
		public string Type { get; set; }
		[Column("MachineBrandName")]
		public string BrandName { get; set; }
		[Column("MachineModel")]
		public string Model { get; set; }

		//Serials
		[Column("SpindleC1")]
		public string SpindleC1 { get; set; }
		[Column("SpindleC2")]
		public string SpindleC2 { get; set; }
		[Column("HoningHead")]
		public string HoningHead { get; set; }

		//Softwareversion
		[Column("NCVersion")]
		public string NCVersion { get; set; }
		[Column("HMIVersion")]
		public string HMIVersion { get; set; }
		[Column("HRIVersion")]
		public string HRIVersion { get; set; }
		[Column("AHSVersion")]
		public string AHSVersion { get; set; }
		[Column("ACIControls")]
		public string ACIControls { get; set; }
		[Column("EnergyMonitoringACIControls")]
		public string EnergyMonitoringACIControls { get; set; }
		[Column("ACIControlsHeader")]
		public string ACIControlsHeader { get; set; }

		[Column("IWProject")]
		public string IWProject { get; set; }

		[Column("File1Master")]
		public string File1Master { get; set; }

		//Bosch Rexroth

		[Column("IndraWorks")]
		public string IndraWorks { get; set; }

		[Column("IndraLogic2G")]
		public string IndraLogic2G { get; set; }

		[Column("IndraMotionMTX")]
		public string IndraMotionMTX { get; set; }

		[Column("MTXBasisFirmware")]
		public string MTXBasisFirmware { get; set; }

		[Column("IWMTX")]
		public string IWMTX { get; set; }

		[Column("IWHMI")]
		public string IWHMI { get; set; }

		[Column("WinStudio")]
		public string WinStudio { get; set; }

		[Column("MTXFirmware")]
		public string MTXFirmware { get; set; }

		//MTX Hardware

		[Column("CardType")]
		public string CardType { get; set; }

		[Column("LPNo")]
		public string LPNo { get; set; }

		[Column("MTXHardwareVersion")]
		public string MTXHardwareVersion { get; set; }

		[Column("SerialNumber")]
		public string SerialNumber { get; set; }
	}
}