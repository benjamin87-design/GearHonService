using GearHonService.Services;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GearHonService.ViewModels
{
	public partial class MachineViewModel : BaseViewModel
	{
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

		private readonly Supabase.Client _supabaseClient;

		public MachineViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			//TODO: Add the export list to excel
			
			Machines = new ObservableCollection<MachineModel>();

			LoadMachineFromDb();
		}

		[RelayCommand]
		private async Task LoadXMLInfo()
		{
			string action = await Shell.Current.DisplayActionSheet("Choose the XML version", "Cancel", null, "Sysinfo 1.0.9", "Sysinfo 1.0.5", "Sysinfo 1.0.2");

			switch (action)
			{
				case "Sysinfo 1.0.9":
					Debug.WriteLine("Sysinfo 1.0.9");

					var result9 = await FilePicker.PickAsync();

					if (result9 != null)
					{
						string filePath = result9.FullPath;

						try
						{
							
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					break;
				case "Sysinfo 1.0.5":
					Debug.WriteLine("Sysinfo 1.0.5");

					var result5 = await FilePicker.PickAsync();

					if (result5 != null)
					{
						string filePath = result5.FullPath;

						try
						{
							XmlSerializer serializer = new XmlSerializer(typeof(Sysinfo1_0_5));

							using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
							{
								Sysinfo1_0_5 systemInformationen = serializer.Deserialize(fileStream) as Sysinfo1_0_5;

								if (systemInformationen.Version == "1.0.5.0")
								{
									SelectedMachine = new MachineModel();
									{
										selectedMachine.Id = 0;
										selectedMachine.MachineNumber = systemInformationen.Präwema.Licences.Licence.MachineNo.ToString();
										selectedMachine.NCVersion = systemInformationen.Präwema.SoftwareComponents.NC.Version.ToString();
										selectedMachine.HMIVersion = systemInformationen.Präwema.SoftwareComponents.HoningHMI.Version.ToString();
										selectedMachine.HRIVersion = systemInformationen.Präwema.SoftwareComponents.PräwemaHRI.Version.ToString();
										selectedMachine.AHSVersion = systemInformationen.Präwema.SoftwareComponents.AdaptivHonServer.Version.ToString();
										selectedMachine.ACIControls = systemInformationen.Präwema.SoftwareComponents.PraewemaAciControlsdll.Version.ToString();
										selectedMachine.EnergyMonitoringACIControls = systemInformationen.Präwema.SoftwareComponents.PraewemaEnergyMonitoringAciControlsdll.Version.ToString();
										selectedMachine.ACIControlsHeader = systemInformationen.Präwema.SoftwareComponents.PraewemaAciControlsHeaderdll.Version.ToString();
										selectedMachine.IndraWorks = systemInformationen.BoschRexroth.SoftwareComponents.IndraWorks.Version.ToString();
										selectedMachine.IndraLogic2G = systemInformationen.BoschRexroth.SoftwareComponents.IndraLogic_2G.Version.ToString();
										selectedMachine.IndraMotionMTX = systemInformationen.BoschRexroth.SoftwareComponents.IndraMotion_MTX.Version.ToString();
										selectedMachine.MTXBasisFirmware = systemInformationen.BoschRexroth.SoftwareComponents.MTXBasisFirmware.Version.ToString();
										selectedMachine.IWMTX = systemInformationen.BoschRexroth.SoftwareComponents.IWHMI.Version.ToString();
										selectedMachine.IWHMI = systemInformationen.BoschRexroth.SoftwareComponents.IWHMI.Version.ToString();
										selectedMachine.WinStudio = systemInformationen.BoschRexroth.SoftwareComponents.WinStudio.Version.ToString();
										selectedMachine.MTXFirmware = systemInformationen.BoschRexroth.SoftwareComponents.MTXFirmware.Version.ToString();
										selectedMachine.CardType = systemInformationen.BoschRexroth.MTXHardware.CardType.Version.ToString();
										selectedMachine.LPNo = systemInformationen.BoschRexroth.MTXHardware.LPNo.Version.ToString();
										selectedMachine.MTXHardwareVersion = systemInformationen.BoschRexroth.MTXHardware.Version.Version.ToString();
										selectedMachine.SerialNumber = systemInformationen.BoschRexroth.MTXHardware.SerialNo.Version.ToString();
									}

									//Send with weak reference to MachineDetailPage
									WeakReferenceManager.AddReference("SelectedMachine", SelectedMachine);

									//go to MachinedetailPage
									await Shell.Current.GoToAsync($"//{nameof(MachineDetailPage)}");
								}
								else
								{
									await Shell.Current.DisplayAlert("Error", "Wrong XML version selected", "OK");
								}
							}
						}
						catch (Exception ex)
						{
							await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
						}
					}
					break;
				case "Sysinfo 1.0.2":
					Debug.WriteLine("Sysinfo 1.0.2");

					var result2 = await FilePicker.PickAsync();

					if (result2 != null)
					{
						string filePath = result2.FullPath;

						try
						{
							XmlSerializer serializer = new XmlSerializer(typeof(Sysinfo1_0_2));

							using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
							{
								Sysinfo1_0_2 systemInformationen = serializer.Deserialize(fileStream) as Sysinfo1_0_2;

								if (systemInformationen.Version == "1.0.2")
								{
									Id = 0;
									MachineNumber = systemInformationen.Präwema.Licences.Licence.MachineNo.ToString();
									NCVersion = systemInformationen.Präwema.SoftwareComponents.NC.Version.ToString();
									HMIVersion = systemInformationen.Präwema.SoftwareComponents.HoningHMI.Version.ToString();
									HRIVersion = systemInformationen.Präwema.SoftwareComponents.PräwemaHRI.Version.ToString();
									AHSVersion = systemInformationen.Präwema.SoftwareComponents.AdaptivHonServer.Version.ToString(); ;
									ACIControls = systemInformationen.Präwema.SoftwareComponents.PraewemaAciControlsdll.Version.ToString();
									EnergyMonitoringACIControls = systemInformationen.Präwema.SoftwareComponents.PraewemaEnergyMonitoringAciControlsdll.Version.ToString();
									ACIControlsHeader = systemInformationen.Präwema.SoftwareComponents.PraewemaAciControlsHeaderdll.Version.ToString();
									IndraWorks = systemInformationen.BoschRexroth.SoftwareComponents.IndraWorks.Version.ToString();
									IndraLogic2G = systemInformationen.BoschRexroth.SoftwareComponents.IndraLogic_2G.Version.ToString();
									IndraMotionMTX = systemInformationen.BoschRexroth.SoftwareComponents.IndraMotion_MTX.Version.ToString();
									MTXBasisFirmware = systemInformationen.BoschRexroth.SoftwareComponents.MTXBasisFirmware.Version.ToString();
									IWMTX = systemInformationen.BoschRexroth.SoftwareComponents.IWHMI.Version.ToString();
									IWHMI = systemInformationen.BoschRexroth.SoftwareComponents.IWHMI.Version.ToString();
									WinStudio = systemInformationen.BoschRexroth.SoftwareComponents.WinStudio.Version.ToString();
									MTXFirmware = systemInformationen.BoschRexroth.SoftwareComponents.MTXFirmware.Version.ToString();
									CardType = systemInformationen.BoschRexroth.MTXHardware.CardType.Version.ToString();
									LPNo = systemInformationen.BoschRexroth.MTXHardware.LPNo.Version.ToString();
									MTXHardwareVersion = systemInformationen.BoschRexroth.MTXHardware.Version.Version.ToString();
									SerialNumber = systemInformationen.BoschRexroth.MTXHardware.SerialNo.Version.ToString();

									//go to MachinedetailPage
									await Shell.Current.GoToAsync($"//{nameof(MachineDetailPage)}");
								}
								else
								{
									await Shell.Current.DisplayAlert("Error", "Wrong XML version selected", "OK");
								}
							}
						}
						catch (Exception ex)
						{
							await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
						}
					}
					break;
				default:
					// Handle other cases
					break;
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
