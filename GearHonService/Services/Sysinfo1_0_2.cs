using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Services
{

	// HINWEIS: Für den generierten Code ist möglicherweise mindestens .NET Framework 4.5 oder .NET Core/Standard 2.0 erforderlich.
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Sysinfo1_0_2
	{

		private SystemInformationenPräwema präwemaField;

		private SystemInformationenBoschRexroth boschRexrothField;

		private string versionField;

		private string dateField;

		private string deviceField;

		private string infoField;

		/// <remarks/>
		public SystemInformationenPräwema Präwema
		{
			get
			{
				return this.präwemaField;
			}
			set
			{
				this.präwemaField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexroth BoschRexroth
		{
			get
			{
				return this.boschRexrothField;
			}
			set
			{
				this.boschRexrothField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Device
		{
			get
			{
				return this.deviceField;
			}
			set
			{
				this.deviceField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Info
		{
			get
			{
				return this.infoField;
			}
			set
			{
				this.infoField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwema
	{

		private SystemInformationenPräwemaSoftwareComponents softwareComponentsField;

		private SystemInformationenPräwemaLicences licencesField;

		/// <remarks/>
		public SystemInformationenPräwemaSoftwareComponents SoftwareComponents
		{
			get
			{
				return this.softwareComponentsField;
			}
			set
			{
				this.softwareComponentsField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenPräwemaLicences Licences
		{
			get
			{
				return this.licencesField;
			}
			set
			{
				this.licencesField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponents
	{

		private SystemInformationenPräwemaSoftwareComponentsHoningHMI honingHMIField;

		private SystemInformationenPräwemaSoftwareComponentsAdaptivHonServer adaptivHonServerField;

		private SystemInformationenPräwemaSoftwareComponentsPräwemaHRI präwemaHRIField;

		private SystemInformationenPräwemaSoftwareComponentsPraewemaAciControlsdll praewemaAciControlsdllField;

		private SystemInformationenPräwemaSoftwareComponentsPraewemaEnergyMonitoringAciControlsdll praewemaEnergyMonitoringAciControlsdllField;

		private SystemInformationenPräwemaSoftwareComponentsPraewemaAciControlsHeaderdll praewemaAciControlsHeaderdllField;

		private SystemInformationenPräwemaSoftwareComponentsNC ncField;

		/// <remarks/>
		public SystemInformationenPräwemaSoftwareComponentsHoningHMI HoningHMI
		{
			get
			{
				return this.honingHMIField;
			}
			set
			{
				this.honingHMIField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenPräwemaSoftwareComponentsAdaptivHonServer AdaptivHonServer
		{
			get
			{
				return this.adaptivHonServerField;
			}
			set
			{
				this.adaptivHonServerField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenPräwemaSoftwareComponentsPräwemaHRI PräwemaHRI
		{
			get
			{
				return this.präwemaHRIField;
			}
			set
			{
				this.präwemaHRIField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Praewema.AciControls.dll")]
		public SystemInformationenPräwemaSoftwareComponentsPraewemaAciControlsdll PraewemaAciControlsdll
		{
			get
			{
				return this.praewemaAciControlsdllField;
			}
			set
			{
				this.praewemaAciControlsdllField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Praewema.EnergyMonitoring.AciControls.dll")]
		public SystemInformationenPräwemaSoftwareComponentsPraewemaEnergyMonitoringAciControlsdll PraewemaEnergyMonitoringAciControlsdll
		{
			get
			{
				return this.praewemaEnergyMonitoringAciControlsdllField;
			}
			set
			{
				this.praewemaEnergyMonitoringAciControlsdllField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Praewema.AciControls.Header.dll")]
		public SystemInformationenPräwemaSoftwareComponentsPraewemaAciControlsHeaderdll PraewemaAciControlsHeaderdll
		{
			get
			{
				return this.praewemaAciControlsHeaderdllField;
			}
			set
			{
				this.praewemaAciControlsHeaderdllField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenPräwemaSoftwareComponentsNC NC
		{
			get
			{
				return this.ncField;
			}
			set
			{
				this.ncField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsHoningHMI
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsAdaptivHonServer
	{

		private string versionField;

		private string dateField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsPräwemaHRI
	{

		private string versionField;

		private string dateField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsPraewemaAciControlsdll
	{

		private string versionField;

		private string dateField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsPraewemaEnergyMonitoringAciControlsdll
	{

		private string versionField;

		private string dateField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsPraewemaAciControlsHeaderdll
	{

		private string versionField;

		private string dateField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaSoftwareComponentsNC
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaLicences
	{

		private SystemInformationenPräwemaLicencesLicence licenceField;

		private string serialNoField;

		/// <remarks/>
		public SystemInformationenPräwemaLicencesLicence Licence
		{
			get
			{
				return this.licenceField;
			}
			set
			{
				this.licenceField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string SerialNo
		{
			get
			{
				return this.serialNoField;
			}
			set
			{
				this.serialNoField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenPräwemaLicencesLicence
	{

		private string customerField;

		private string machineNoField;

		private string validDateField;

		private string permissionsField;

		private string keyField;

		private bool isTestLicenceField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Customer
		{
			get
			{
				return this.customerField;
			}
			set
			{
				this.customerField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string MachineNo
		{
			get
			{
				return this.machineNoField;
			}
			set
			{
				this.machineNoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ValidDate
		{
			get
			{
				return this.validDateField;
			}
			set
			{
				this.validDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Permissions
		{
			get
			{
				return this.permissionsField;
			}
			set
			{
				this.permissionsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Key
		{
			get
			{
				return this.keyField;
			}
			set
			{
				this.keyField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool IsTestLicence
		{
			get
			{
				return this.isTestLicenceField;
			}
			set
			{
				this.isTestLicenceField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexroth
	{

		private SystemInformationenBoschRexrothSoftwareComponents softwareComponentsField;

		private SystemInformationenBoschRexrothMTXHardware mTXHardwareField;

		private SystemInformationenBoschRexrothSystemOverview systemOverviewField;

		private SystemInformationenBoschRexrothDrive[] driveInformationField;

		/// <remarks/>
		public SystemInformationenBoschRexrothSoftwareComponents SoftwareComponents
		{
			get
			{
				return this.softwareComponentsField;
			}
			set
			{
				this.softwareComponentsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("MTX-Hardware")]
		public SystemInformationenBoschRexrothMTXHardware MTXHardware
		{
			get
			{
				return this.mTXHardwareField;
			}
			set
			{
				this.mTXHardwareField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("System-Overview")]
		public SystemInformationenBoschRexrothSystemOverview SystemOverview
		{
			get
			{
				return this.systemOverviewField;
			}
			set
			{
				this.systemOverviewField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute("Drive-Information")]
		[System.Xml.Serialization.XmlArrayItemAttribute("Drive", IsNullable = false)]
		public SystemInformationenBoschRexrothDrive[] DriveInformation
		{
			get
			{
				return this.driveInformationField;
			}
			set
			{
				this.driveInformationField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponents
	{

		private SystemInformationenBoschRexrothSoftwareComponentsIndraWorks indraWorksField;

		private SystemInformationenBoschRexrothSoftwareComponentsIndraLogic_2G indraLogic_2GField;

		private SystemInformationenBoschRexrothSoftwareComponentsIndraMotion_MTX indraMotion_MTXField;

		private SystemInformationenBoschRexrothSoftwareComponentsMTXBasisFirmware mTXBasisFirmwareField;

		private SystemInformationenBoschRexrothSoftwareComponentsIWMTX iWMTXField;

		private SystemInformationenBoschRexrothSoftwareComponentsIWHMI iWHMIField;

		private SystemInformationenBoschRexrothSoftwareComponentsWinStudio winStudioField;

		private SystemInformationenBoschRexrothSoftwareComponentsMTXFirmware mTXFirmwareField;

		/// <remarks/>
		public SystemInformationenBoschRexrothSoftwareComponentsIndraWorks IndraWorks
		{
			get
			{
				return this.indraWorksField;
			}
			set
			{
				this.indraWorksField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothSoftwareComponentsIndraLogic_2G IndraLogic_2G
		{
			get
			{
				return this.indraLogic_2GField;
			}
			set
			{
				this.indraLogic_2GField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothSoftwareComponentsIndraMotion_MTX IndraMotion_MTX
		{
			get
			{
				return this.indraMotion_MTXField;
			}
			set
			{
				this.indraMotion_MTXField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("MTX-Basis-Firmware")]
		public SystemInformationenBoschRexrothSoftwareComponentsMTXBasisFirmware MTXBasisFirmware
		{
			get
			{
				return this.mTXBasisFirmwareField;
			}
			set
			{
				this.mTXBasisFirmwareField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("IW-MTX")]
		public SystemInformationenBoschRexrothSoftwareComponentsIWMTX IWMTX
		{
			get
			{
				return this.iWMTXField;
			}
			set
			{
				this.iWMTXField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("IW-HMI")]
		public SystemInformationenBoschRexrothSoftwareComponentsIWHMI IWHMI
		{
			get
			{
				return this.iWHMIField;
			}
			set
			{
				this.iWHMIField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothSoftwareComponentsWinStudio WinStudio
		{
			get
			{
				return this.winStudioField;
			}
			set
			{
				this.winStudioField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("MTX-Firmware")]
		public SystemInformationenBoschRexrothSoftwareComponentsMTXFirmware MTXFirmware
		{
			get
			{
				return this.mTXFirmwareField;
			}
			set
			{
				this.mTXFirmwareField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsIndraWorks
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsIndraLogic_2G
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsIndraMotion_MTX
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsMTXBasisFirmware
	{

		private decimal versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsIWMTX
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsIWHMI
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsWinStudio
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSoftwareComponentsMTXFirmware
	{

		private string versionField;

		private System.DateTime dateField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
		public System.DateTime Date
		{
			get
			{
				return this.dateField;
			}
			set
			{
				this.dateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothMTXHardware
	{

		private SystemInformationenBoschRexrothMTXHardwareCardType cardTypeField;

		private SystemInformationenBoschRexrothMTXHardwareLPNo lPNoField;

		private SystemInformationenBoschRexrothMTXHardwareVersion versionField;

		private SystemInformationenBoschRexrothMTXHardwareSerialNo serialNoField;

		/// <remarks/>
		public SystemInformationenBoschRexrothMTXHardwareCardType CardType
		{
			get
			{
				return this.cardTypeField;
			}
			set
			{
				this.cardTypeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LP-No")]
		public SystemInformationenBoschRexrothMTXHardwareLPNo LPNo
		{
			get
			{
				return this.lPNoField;
			}
			set
			{
				this.lPNoField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothMTXHardwareVersion Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Serial-No.")]
		public SystemInformationenBoschRexrothMTXHardwareSerialNo SerialNo
		{
			get
			{
				return this.serialNoField;
			}
			set
			{
				this.serialNoField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothMTXHardwareCardType
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothMTXHardwareLPNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothMTXHardwareVersion
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothMTXHardwareSerialNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSystemOverview
	{

		private SystemInformationenBoschRexrothSystemOverviewChannels channelsField;

		private SystemInformationenBoschRexrothSystemOverviewRotaryORLinear rotaryORLinearField;

		private SystemInformationenBoschRexrothSystemOverviewSpindleAndCaxis spindleAndCaxisField;

		private SystemInformationenBoschRexrothSystemOverviewSpindle spindleField;

		/// <remarks/>
		public SystemInformationenBoschRexrothSystemOverviewChannels Channels
		{
			get
			{
				return this.channelsField;
			}
			set
			{
				this.channelsField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothSystemOverviewRotaryORLinear RotaryORLinear
		{
			get
			{
				return this.rotaryORLinearField;
			}
			set
			{
				this.rotaryORLinearField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothSystemOverviewSpindleAndCaxis SpindleAndCaxis
		{
			get
			{
				return this.spindleAndCaxisField;
			}
			set
			{
				this.spindleAndCaxisField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothSystemOverviewSpindle Spindle
		{
			get
			{
				return this.spindleField;
			}
			set
			{
				this.spindleField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSystemOverviewChannels
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSystemOverviewRotaryORLinear
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSystemOverviewSpindleAndCaxis
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothSystemOverviewSpindle
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDrive
	{

		private SystemInformationenBoschRexrothDriveInfo infoField;

		private SystemInformationenBoschRexrothDriveMLD mLDField;

		private SystemInformationenBoschRexrothDriveManufacturVersion manufacturVersionField;

		private SystemInformationenBoschRexrothDriveMotorType motorTypeField;

		private SystemInformationenBoschRexrothDrivePowerSection powerSectionField;

		private SystemInformationenBoschRexrothDriveControllerSection controllerSectionField;

		private SystemInformationenBoschRexrothDriveActivePackages activePackagesField;

		private SystemInformationenBoschRexrothDriveSafetyParamters safetyParamtersField;

		private string nameField;

		private string functionField;

		private string info1Field;

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveInfo Info
		{
			get
			{
				return this.infoField;
			}
			set
			{
				this.infoField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveMLD MLD
		{
			get
			{
				return this.mLDField;
			}
			set
			{
				this.mLDField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveManufacturVersion ManufacturVersion
		{
			get
			{
				return this.manufacturVersionField;
			}
			set
			{
				this.manufacturVersionField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveMotorType MotorType
		{
			get
			{
				return this.motorTypeField;
			}
			set
			{
				this.motorTypeField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDrivePowerSection PowerSection
		{
			get
			{
				return this.powerSectionField;
			}
			set
			{
				this.powerSectionField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveControllerSection ControllerSection
		{
			get
			{
				return this.controllerSectionField;
			}
			set
			{
				this.controllerSectionField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveActivePackages ActivePackages
		{
			get
			{
				return this.activePackagesField;
			}
			set
			{
				this.activePackagesField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveSafetyParamters SafetyParamters
		{
			get
			{
				return this.safetyParamtersField;
			}
			set
			{
				this.safetyParamtersField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Function
		{
			get
			{
				return this.functionField;
			}
			set
			{
				this.functionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Info")]
		public string Info1
		{
			get
			{
				return this.info1Field;
			}
			set
			{
				this.info1Field = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveInfo
	{

		private string nameField;

		private string physicalDriveNoField;

		private string sercosAddressField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string PhysicalDriveNo
		{
			get
			{
				return this.physicalDriveNoField;
			}
			set
			{
				this.physicalDriveNoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string SercosAddress
		{
			get
			{
				return this.sercosAddressField;
			}
			set
			{
				this.sercosAddressField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveMLD
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveManufacturVersion
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveMotorType
	{

		private SystemInformationenBoschRexrothDriveMotorTypePartNo partNoField;

		private SystemInformationenBoschRexrothDriveMotorTypeSerialNo serialNoField;

		private string versionField;

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveMotorTypePartNo PartNo
		{
			get
			{
				return this.partNoField;
			}
			set
			{
				this.partNoField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveMotorTypeSerialNo SerialNo
		{
			get
			{
				return this.serialNoField;
			}
			set
			{
				this.serialNoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveMotorTypePartNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveMotorTypeSerialNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDrivePowerSection
	{

		private SystemInformationenBoschRexrothDrivePowerSectionBasicUnitPartNo basicUnitPartNoField;

		private SystemInformationenBoschRexrothDrivePowerSectionBasicUnitSerialNo basicUnitSerialNoField;

		private string versionField;

		/// <remarks/>
		public SystemInformationenBoschRexrothDrivePowerSectionBasicUnitPartNo BasicUnitPartNo
		{
			get
			{
				return this.basicUnitPartNoField;
			}
			set
			{
				this.basicUnitPartNoField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDrivePowerSectionBasicUnitSerialNo BasicUnitSerialNo
		{
			get
			{
				return this.basicUnitSerialNoField;
			}
			set
			{
				this.basicUnitSerialNoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDrivePowerSectionBasicUnitPartNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDrivePowerSectionBasicUnitSerialNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveControllerSection
	{

		private SystemInformationenBoschRexrothDriveControllerSectionPartNo partNoField;

		private SystemInformationenBoschRexrothDriveControllerSectionSerialNo serialNoField;

		private string versionField;

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveControllerSectionPartNo PartNo
		{
			get
			{
				return this.partNoField;
			}
			set
			{
				this.partNoField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveControllerSectionSerialNo SerialNo
		{
			get
			{
				return this.serialNoField;
			}
			set
			{
				this.serialNoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveControllerSectionPartNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveControllerSectionSerialNo
	{

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveActivePackages
	{

		private string countField;

		private string activeField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Active
		{
			get
			{
				return this.activeField;
			}
			set
			{
				this.activeField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveSafetyParamters
	{

		private SystemInformationenBoschRexrothDriveSafetyParamtersSMOconf sMOconfField;

		private SystemInformationenBoschRexrothDriveSafetyParamtersSMOparameter sMOparameterField;

		private SystemInformationenBoschRexrothDriveSafetyParamtersSMOchecksumConf sMOchecksumConfField;

		private SystemInformationenBoschRexrothDriveSafetyParamtersSMOchecksumPara sMOchecksumParaField;

		private SystemInformationenBoschRexrothDriveSafetyParamtersSafetyDeactivated safetyDeactivatedField;

		private string siDescriptionField;

		private string negInfoField;

		private string percInfoField;

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveSafetyParamtersSMOconf SMOconf
		{
			get
			{
				return this.sMOconfField;
			}
			set
			{
				this.sMOconfField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveSafetyParamtersSMOparameter SMOparameter
		{
			get
			{
				return this.sMOparameterField;
			}
			set
			{
				this.sMOparameterField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveSafetyParamtersSMOchecksumConf SMOchecksumConf
		{
			get
			{
				return this.sMOchecksumConfField;
			}
			set
			{
				this.sMOchecksumConfField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveSafetyParamtersSMOchecksumPara SMOchecksumPara
		{
			get
			{
				return this.sMOchecksumParaField;
			}
			set
			{
				this.sMOchecksumParaField = value;
			}
		}

		/// <remarks/>
		public SystemInformationenBoschRexrothDriveSafetyParamtersSafetyDeactivated SafetyDeactivated
		{
			get
			{
				return this.safetyDeactivatedField;
			}
			set
			{
				this.safetyDeactivatedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string SiDescription
		{
			get
			{
				return this.siDescriptionField;
			}
			set
			{
				this.siDescriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string negInfo
		{
			get
			{
				return this.negInfoField;
			}
			set
			{
				this.negInfoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string PercInfo
		{
			get
			{
				return this.percInfoField;
			}
			set
			{
				this.percInfoField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveSafetyParamtersSMOconf
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveSafetyParamtersSMOparameter
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveSafetyParamtersSMOchecksumConf
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveSafetyParamtersSMOchecksumPara
	{

		private string countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SystemInformationenBoschRexrothDriveSafetyParamtersSafetyDeactivated
	{

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}
}
