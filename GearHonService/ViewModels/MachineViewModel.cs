using ClosedXML.Excel;
using CommunityToolkit.Maui.Storage;
using System.Xml.Linq;

namespace GearHonService.ViewModels
{
	public partial class MachineViewModel : BaseViewModel
	{
		//Strings
		#region Strings
		[ObservableProperty]
		private int id;
		[ObservableProperty]
		private string machineNumber;
		[ObservableProperty]
		private string customerName;
		[ObservableProperty]
		private string type;
		[ObservableProperty]
		private string brandName;
		[ObservableProperty]
		private string model;
		[ObservableProperty]
		private string spindleC1;
		[ObservableProperty]
		private string spindleC2;
		[ObservableProperty]
		private string honingHead;
		[ObservableProperty]
		private string nCVersion;
		[ObservableProperty]
		private string hMIVersion;
		[ObservableProperty]
		private string hRIVersion;
		[ObservableProperty]
		private string aHSVersion;
		[ObservableProperty]
		private string aCIControls;
		[ObservableProperty]
		private string energyMonitoringACIControls;
		[ObservableProperty]
		private string aCIControlsHeader;
		[ObservableProperty]
		private string iWProject;
		[ObservableProperty]
		private string file1Master;
		[ObservableProperty]
		private string indraWorks;
		[ObservableProperty]
		private string indraLogic2G;
		[ObservableProperty]
		private string indraMotionMTX;
		[ObservableProperty]
		private string mTXBasisFirmware;
		[ObservableProperty]
		private string iWMTX;
		[ObservableProperty]
		private string iWHMI;
		[ObservableProperty]
		private string winStudio;
		[ObservableProperty]
		private string mTXFirmware;
		[ObservableProperty]
		private string cardType;
		[ObservableProperty]
		private string lPNo;
		[ObservableProperty]
		private string mTXHardwareVersion;
		[ObservableProperty]
		private string serialNumber;

		[ObservableProperty]
		private string contractorName;
		#endregion

		//Lists
		[ObservableProperty]
		private ObservableCollection<MachineModel> machines;

		//Selected
		private MachineModel selectedMachine;
		public MachineModel SelectedMachine
		{
			get { return selectedMachine; }
			set { selectedMachine = value; }
		}

		//Supabase client
		private readonly Supabase.Client _supabaseClient;

		public MachineViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;
			
			Machines = new ObservableCollection<MachineModel>();

			_ = LoadMachineFromDb();
		}

		[RelayCommand]
		private async Task LoadXMLInfo()
		{
			//use file picker th get the xml file
			var file = await FilePicker.PickAsync();
			if (file == null)
			{
				//user canceled the file picking
				return;
			}
			else
			{
				//parse the xml file to get the info
				var doc = XDocument.Load(file.FullPath);
				var root = doc.Root;

				//get version from systeminformation
				var systeminformationversion = root.Attribute("Version")?.Value;

				//TODO: Add new version when needed (each version has his differents)

				switch (systeminformationversion)
				{
					case "1.0.5.0":
						MachineNumber = root.Attribute("MachineNo")?.Value;
						HMIVersion = root.Descendants("HoningHMI").FirstOrDefault()?.Attribute("Version")?.Value;
						AHSVersion = root.Descendants("AdaptivHonServer").FirstOrDefault()?.Attribute("Version")?.Value;
						HRIVersion = root.Descendants("PräwemaHRI").FirstOrDefault()?.Attribute("Version")?.Value;
						ACIControls = root.Descendants("Praewema.AciControls.dll").FirstOrDefault()?.Attribute("Version")?.Value;
						EnergyMonitoringACIControls = root.Descendants("Praewema.EnergyMonitoring.AciControls.dll").FirstOrDefault()?.Attribute("Version")?.Value;
						ACIControlsHeader = root.Descendants("Praewema.AciControls.Header.dll").FirstOrDefault()?.Attribute("Version")?.Value;
						IWProject = root.Descendants("IW_Project").FirstOrDefault()?.Attribute("Version")?.Value;
						NCVersion = root.Descendants("NC").FirstOrDefault()?.Attribute("Version")?.Value;
						File1Master = root.Descendants("File1Master.npg").FirstOrDefault()?.Attribute("Version")?.Value;
						IndraWorks = root.Descendants("IndraWorks").FirstOrDefault()?.Attribute("Version")?.Value;
						IndraLogic2G = root.Descendants("IndraLogic_2G").FirstOrDefault()?.Attribute("Version")?.Value;
						IndraMotionMTX = root.Descendants("IndraMotion_MTX").FirstOrDefault()?.Attribute("Version")?.Value;
						MTXBasisFirmware = root.Descendants("MTX-Basis-Firmware").FirstOrDefault()?.Attribute("Version")?.Value;
						IWMTX = root.Descendants("IW-MTX").FirstOrDefault()?.Attribute("Version")?.Value;
						IWHMI = root.Descendants("IW-HMI").FirstOrDefault()?.Attribute("Version")?.Value;
						WinStudio = root.Descendants("WinStudio").FirstOrDefault()?.Attribute("Version")?.Value;
						MTXFirmware = root.Descendants("MTX-Firmware").FirstOrDefault()?.Attribute("Version")?.Value;
						CardType = root.Descendants("CardType").FirstOrDefault()?.Attribute("Version")?.Value;
						LPNo = root.Descendants("LP-No").FirstOrDefault()?.Attribute("Version")?.Value;
						MTXHardwareVersion = root.Descendants("Version").FirstOrDefault()?.Attribute("Version")?.Value;
						SerialNumber = root.Descendants("Serial-No").FirstOrDefault()?.Attribute("Version")?.Value;

						//load data to selectedmachine
						SelectedMachine = new MachineModel();
						{
							selectedMachine.Id = 0;
							selectedMachine.MachineNumber = MachineNumber;
							selectedMachine.HMIVersion = HMIVersion;
							selectedMachine.AHSVersion = AHSVersion;
							selectedMachine.HRIVersion = HRIVersion;
							selectedMachine.ACIControls = ACIControls;
							selectedMachine.EnergyMonitoringACIControls = EnergyMonitoringACIControls;
							selectedMachine.ACIControlsHeader = ACIControlsHeader;
							selectedMachine.IWProject = IWProject;
							selectedMachine.NCVersion = NCVersion;
							selectedMachine.File1Master = File1Master;
							selectedMachine.IndraWorks = IndraWorks;
							selectedMachine.IndraLogic2G = IndraLogic2G;
							selectedMachine.IndraMotionMTX = IndraMotionMTX;
							selectedMachine.MTXBasisFirmware = MTXBasisFirmware;
							selectedMachine.IWMTX = IWMTX;
							selectedMachine.IWHMI = IWHMI;
							selectedMachine.WinStudio = WinStudio;
							selectedMachine.MTXFirmware = MTXFirmware;
							selectedMachine.CardType = CardType;
							selectedMachine.LPNo = LPNo;
							selectedMachine.MTXHardwareVersion = MTXHardwareVersion;
							selectedMachine.SerialNumber = SerialNumber;
						}

						//Send with weak reference to MachineDetailPage
						WeakReferenceManager.AddReference("SelectedMachine", SelectedMachine);
						//go to detailpage
						await Shell.Current.GoToAsync($"//{nameof(MachineDetailPage)}");
						break;

					case "1.0.2":
						HMIVersion = root.Descendants("HoningHMI").FirstOrDefault()?.Attribute("Version")?.Value;
						AHSVersion = root.Descendants("AdaptivHonServer").FirstOrDefault()?.Attribute("Version")?.Value;
						HRIVersion = root.Descendants("PräwemaHRI").FirstOrDefault()?.Attribute("Version")?.Value;
						ACIControls = root.Descendants("Praewema.AciControls.dll").FirstOrDefault()?.Attribute("Version")?.Value;
						EnergyMonitoringACIControls = root.Descendants("Praewema.EnergyMonitoring.AciControls.dll").FirstOrDefault()?.Attribute("Version")?.Value;
						ACIControlsHeader = root.Descendants("Praewema.AciControls.Header.dll").FirstOrDefault()?.Attribute("Version")?.Value;
						NCVersion = root.Descendants("NC").FirstOrDefault()?.Attribute("Version")?.Value;
						IndraWorks = root.Descendants("IndraWorks").FirstOrDefault()?.Attribute("Version")?.Value;
						IndraLogic2G = root.Descendants("IndraLogic_2G").FirstOrDefault()?.Attribute("Version")?.Value;
						IndraMotionMTX = root.Descendants("IndraMotion_MTX").FirstOrDefault()?.Attribute("Version")?.Value;
						MTXBasisFirmware = root.Descendants("MTX-Basis-Firmware").FirstOrDefault()?.Attribute("Version")?.Value;
						IWMTX = root.Descendants("IW-MTX").FirstOrDefault()?.Attribute("Version")?.Value;
						IWHMI = root.Descendants("IW-HMI").FirstOrDefault()?.Attribute("Version")?.Value;
						WinStudio = root.Descendants("WinStudio").FirstOrDefault()?.Attribute("Version")?.Value;
						MTXFirmware = root.Descendants("MTX-Firmware").FirstOrDefault()?.Attribute("Version")?.Value;
						CardType = root.Descendants("CardType").FirstOrDefault()?.Attribute("Version")?.Value;
						LPNo = root.Descendants("LP-No").FirstOrDefault()?.Attribute("Version")?.Value;
						MTXHardwareVersion = root.Descendants("Version").FirstOrDefault()?.Attribute("Version")?.Value;
						SerialNumber = root.Descendants("Serial-No").FirstOrDefault()?.Attribute("Version")?.Value;

						//load data to selectedmachine
						SelectedMachine = new MachineModel();
						{
							selectedMachine.Id = 0;
							selectedMachine.HMIVersion = HMIVersion;
							selectedMachine.AHSVersion = AHSVersion;
							selectedMachine.HRIVersion = HRIVersion;
							selectedMachine.ACIControls = ACIControls;
							selectedMachine.EnergyMonitoringACIControls = EnergyMonitoringACIControls;
							selectedMachine.ACIControlsHeader = ACIControlsHeader;
							selectedMachine.NCVersion = NCVersion;
							selectedMachine.IndraWorks = IndraWorks;
							selectedMachine.IndraLogic2G = IndraLogic2G;
							selectedMachine.IndraMotionMTX = IndraMotionMTX;
							selectedMachine.MTXBasisFirmware = MTXBasisFirmware;
							selectedMachine.IWMTX = IWMTX;
							selectedMachine.IWHMI = IWHMI;
							selectedMachine.WinStudio = WinStudio;
							selectedMachine.MTXFirmware = MTXFirmware;
							selectedMachine.CardType = CardType;
							selectedMachine.LPNo = LPNo;
							selectedMachine.MTXHardwareVersion = MTXHardwareVersion;
							selectedMachine.SerialNumber = SerialNumber;
						}

						//Send with weak reference to MachineDetailPage
						WeakReferenceManager.AddReference("SelectedMachine", SelectedMachine);
						//go to detailpage
						await Shell.Current.GoToAsync($"//{nameof(MachineDetailPage)}");
						break;

					default:
						await Shell.Current.DisplayAlert("Error", "No such xml file version supported. Please enter the data manually", "Ok");
						break;
				}
			}
		}

		[RelayCommand]
		private async Task ExportMachineList()
		{
			//create new workbook
			var workbook = new XLWorkbook();

			//create new worksheet
			var worksheet = workbook.Worksheets.Add("MachineList");

			//Set column width to content
			worksheet.Columns().AdjustToContents();

			//add header
			worksheet.Cell("A1").Value = "MachineNumber";
			worksheet.Cell("B1").Value = "CustomerName";
			worksheet.Cell("C1").Value = "Type";
			worksheet.Cell("D1").Value = "BrandName";
			worksheet.Cell("E1").Value = "Model";
			worksheet.Cell("F1").Value = "SpindleC1";
			worksheet.Cell("G1").Value = "SpindleC2";
			worksheet.Cell("H1").Value = "HoningHead";
			worksheet.Cell("I1").Value = "NCVersion";
			worksheet.Cell("J1").Value = "HMIVersion";
			worksheet.Cell("K1").Value = "HRIVersion";
			worksheet.Cell("L1").Value = "AHSVersion";
			worksheet.Cell("M1").Value = "ACIControls";
			worksheet.Cell("N1").Value = "EnergyMonitoringACIControls";
			worksheet.Cell("O1").Value = "ACIControlsHeader";
			worksheet.Cell("P1").Value = "IWProject";
			worksheet.Cell("Q1").Value = "File1Master";
			worksheet.Cell("R1").Value = "IndraWorks";
			worksheet.Cell("S1").Value = "IndraLogic2G";
			worksheet.Cell("T1").Value = "IndraMotionMTX";
			worksheet.Cell("U1").Value = "MTXBasisFirmware";
			worksheet.Cell("V1").Value = "IWMTX";
			worksheet.Cell("W1").Value = "IWHMI";
			worksheet.Cell("X1").Value = "WinStudio";
			worksheet.Cell("Y1").Value = "MTXFirmware";
			worksheet.Cell("Z1").Value = "CardType";
			worksheet.Cell("AA1").Value = "LPNo";
			worksheet.Cell("AB1").Value = "MTXHardwareVersion";
			worksheet.Cell("AC1").Value = "SerialNumber";

			//add data
			for (int i = 0; i < Machines.Count; i++)
			{
				worksheet.Cell(i + 2, 1).Value = Machines[i].MachineNumber;
				worksheet.Cell(i + 2, 2).Value = Machines[i].CustomerName;
				worksheet.Cell(i + 2, 3).Value = Machines[i].Type;
				worksheet.Cell(i + 2, 4).Value = Machines[i].BrandName;
				worksheet.Cell(i + 2, 5).Value = Machines[i].Model;
				worksheet.Cell(i + 2, 6).Value = Machines[i].SpindleC1;
				worksheet.Cell(i + 2, 7).Value = Machines[i].SpindleC2;
				worksheet.Cell(i + 2, 8).Value = Machines[i].HoningHead;
				worksheet.Cell(i + 2, 9).Value = Machines[i].NCVersion;
				worksheet.Cell(i + 2, 10).Value = Machines[i].HMIVersion;
				worksheet.Cell(i + 2, 11).Value = Machines[i].HRIVersion;
				worksheet.Cell(i + 2, 12).Value = Machines[i].AHSVersion;
				worksheet.Cell(i + 2, 13).Value = Machines[i].ACIControls;
				worksheet.Cell(i + 2, 14).Value = Machines[i].EnergyMonitoringACIControls;
				worksheet.Cell(i + 2, 15).Value = Machines[i].ACIControlsHeader;
				worksheet.Cell(i + 2, 16).Value = Machines[i].IWProject;
				worksheet.Cell(i + 2, 17).Value = Machines[i].File1Master;
				worksheet.Cell(i + 2, 18).Value = Machines[i].IndraWorks;
				worksheet.Cell(i + 2, 19).Value = Machines[i].IndraLogic2G;
				worksheet.Cell(i + 2, 20).Value = Machines[i].IndraMotionMTX;
				worksheet.Cell(i + 2, 21).Value = Machines[i].MTXBasisFirmware;
				worksheet.Cell(i + 2, 22).Value = Machines[i].IWMTX;
				worksheet.Cell(i + 2, 23).Value = Machines[i].IWHMI;
				worksheet.Cell(i + 2, 24).Value = Machines[i].WinStudio;
				worksheet.Cell(i + 2, 25).Value = Machines[i].MTXFirmware;
				worksheet.Cell(i + 2, 26).Value = Machines[i].CardType;
			}

			//let the user select folder and save the file with the name MachineOverview to this folder
			var folder = await FolderPicker.Default.PickAsync();
			if (folder == null)
			{
				//user canceled the folder picking
				return;
			}
			else
			{
				workbook.SaveAs(folder.Folder.Path + "\\Machine_Overview.xlsx");
			}
		}

		[RelayCommand]
		public async Task LoadMachineFromDb()
		{
			var result = await _supabaseClient.From<MachineModel>().Get();

			Machines.Clear();
			foreach (var machine in result.Models)
			{
				Machines.Add(machine);
			}
		}

		[RelayCommand]
		private async Task MachineSelectionChanged()
		{
			if(selectedMachine != null)
			{
				WeakReferenceManager.AddReference("SelectedMachine", SelectedMachine);

				//Go to MachineDetailPage
				await Shell.Current.GoToAsync($"//{nameof(MachineDetailPage)}");
			}
		}

		[RelayCommand]
		private async Task AddMachine()
		{ 
			await Shell.Current.GoToAsync($"//{nameof(MachineDetailPage)}");
		}
	}
}
