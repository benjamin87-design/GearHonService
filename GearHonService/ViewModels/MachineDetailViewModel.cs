namespace GearHonService.ViewModels
{
	public partial class MachineDetailViewModel : BaseViewModel
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
		[ObservableProperty]
		private string name;

		//Lists
		[ObservableProperty]
		private ObservableCollection<MachineModel> machines;
		[ObservableProperty]
		private ObservableCollection<CustomerModel> customers;
		[ObservableProperty]
		private ObservableCollection<ContractorModel> contractors;
		[ObservableProperty]
		private ObservableCollection<MachineModelModel> machineModels;
		[ObservableProperty]
		private ObservableCollection<MachineTypeModel> machineTypes;


		//Selected
		private CustomerModel selectedCustomer;
		public CustomerModel SelectedCustomer
		{
			get { return selectedCustomer; }
			set { selectedCustomer = value; }
		}

		private ContractorModel selectedContractor;
		public ContractorModel SelectedContractor
		{
			get { return selectedContractor; }
			set { selectedContractor = value; }
		}

		private MachineModelModel selectedMachineModel;
		public MachineModelModel SelectedMachineModel
		{
			get { return selectedMachineModel; }
			set { selectedMachineModel = value; }
		}

		private MachineTypeModel selectedMachineType;
		public MachineTypeModel SelectedMachineType
		{
			get { return selectedMachineType; }
			set { selectedMachineType = value; }
		}

		public MachineModel SelectedMachine { get; set; }

		private readonly Supabase.Client _supabaseClient;

		private MachineViewModel _machineViewModel;

		public MachineDetailViewModel(Supabase.Client supabaseClient, MachineViewModel machineViewModel)
		{
			_supabaseClient = supabaseClient;

			_machineViewModel = machineViewModel;

			Machines = new ObservableCollection<MachineModel>();
			Customers = new ObservableCollection<CustomerModel>();
			Contractors = new ObservableCollection<ContractorModel>();
			MachineModels = new ObservableCollection<MachineModelModel>();
			MachineTypes = new ObservableCollection<MachineTypeModel>();

			GetSelectedMachine();
			GetAllCustomers();
			AddContractorToList();
		}

		[RelayCommand]
		public async Task Save()
		{
			if (Id == 0)
			{
				if(selectedCustomer == null)
				{
					await Shell.Current.DisplayAlert("Error", "No Customer selected", "Ok");
					return;
				}
				if(selectedContractor == null)
				{
					await Shell.Current.DisplayAlert("Error", "No Contractor selected", "Ok");
					return;
				}
				if(selectedMachineModel == null)
				{
					await Shell.Current.DisplayAlert("Error", "No Model selected", "Ok");
					return;
				}
				if(selectedMachineType == null)
				{
					await Shell.Current.DisplayAlert("Error", "No Type selected", "Ok");
					return;
				}
				//insert
				var insertMachine = new MachineModel
				{
					MachineNumber = MachineNumber,
					CustomerName = selectedCustomer.CustomerName,
					Type = selectedMachineType.Type,
					BrandName = selectedContractor.Name,
					Model = selectedMachineModel.Model,
					SpindleC1 = SpindleC1,
					SpindleC2 = SpindleC2,
					HoningHead = HoningHead,
					NCVersion = NCVersion,
					HMIVersion = HMIVersion,
					HRIVersion = HRIVersion,
					AHSVersion = AHSVersion,
					ACIControls = ACIControls,
					EnergyMonitoringACIControls = EnergyMonitoringACIControls,
					ACIControlsHeader = ACIControlsHeader,
					IWProject = IWProject,
					File1Master = File1Master,
					IndraWorks = IndraWorks,
					IndraLogic2G = IndraLogic2G,
					IndraMotionMTX = IndraMotionMTX,
					MTXBasisFirmware = MTXBasisFirmware,
					IWMTX = IWMTX,
					IWHMI = IWHMI,
					WinStudio = WinStudio,
					MTXFirmware = MTXFirmware,
					CardType = CardType,
					LPNo = LPNo,
					MTXHardwareVersion = MTXHardwareVersion,
					SerialNumber = SerialNumber,
				};

				try
				{
					var insertResult = await _supabaseClient
					.From<MachineModel>()
					.Insert(insertMachine);
					await Shell.Current.DisplayAlert("Success", "Machine successfully added", "Ok");

					ClearStrings();

					await _machineViewModel.LoadMachineFromDb();
					await Shell.Current.GoToAsync($"//{nameof(MachinePage)}");
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
			else
			{
				try
				{
					var model = await _supabaseClient
						.From<MachineModel>()
						.Where(x => x.Id == Id)
						.Single();

					model.MachineNumber = MachineNumber;
					model.CustomerName = CustomerName;
					model.Type = Type;
					model.BrandName = BrandName;
					model.Model = Model;
					model.SpindleC1 = SpindleC1;
					model.SpindleC2 = SpindleC2;
					model.HoningHead = HoningHead;
					model.NCVersion = NCVersion;
					model.HMIVersion = HMIVersion;
					model.HRIVersion = HRIVersion;
					model.AHSVersion = AHSVersion;
					model.ACIControls = ACIControls;
					model.EnergyMonitoringACIControls = EnergyMonitoringACIControls;
					model.ACIControlsHeader = ACIControlsHeader;
					model.IWProject = IWProject;
					model.File1Master = File1Master;
					model.IndraWorks = IndraWorks;
					model.IndraLogic2G = IndraLogic2G;
					model.IndraMotionMTX = IndraMotionMTX;
					model.MTXBasisFirmware = MTXBasisFirmware;
					model.IWMTX = IWMTX;
					model.IWHMI = IWHMI;
					model.WinStudio = WinStudio;
					model.MTXFirmware = MTXFirmware;
					CardType = CardType;
					model.LPNo = LPNo;
					model.MTXHardwareVersion = MTXHardwareVersion;
					model.SerialNumber = SerialNumber;
					await model.Update<MachineModel>();

					await Shell.Current.DisplayAlert("Success", "Machine successfully updated", "Ok");

					ClearStrings();

					await _machineViewModel.LoadMachineFromDb();
					await Shell.Current.GoToAsync($"//{nameof(MachinePage)}");
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
		}

		[RelayCommand]
		public async Task Delete()
		{
			SelectedMachine = WeakReferenceManager.GetReference("SelectedMachine") as MachineModel;

			if (SelectedMachine.Id != 0)
			{
				try
				{
					await _supabaseClient
						.From<MachineModel>()
						.Where(x => x.Id == Id)
						.Delete();
					await Shell.Current.DisplayAlert("Success", "Machine successfully deleted", "Ok");

					ClearStrings();

					await _machineViewModel.LoadMachineFromDb();
					await Shell.Current.GoToAsync($"//{nameof(MachinePage)}");
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
				}
			}
			else
			{
				await Shell.Current.DisplayAlert("Error", "No Machine selected", "Ok");
			}
		}

		[RelayCommand]
		public async Task Cancel()
		{
			ClearStrings();

			await Shell.Current.GoToAsync($"//{nameof(MachinePage)}");
		}

		[RelayCommand]
		private async Task ContractorSelectionChanged()
		{
			if (selectedContractor != null)
			{
				switch (selectedContractor.Name)
				{
					case "Präwema Antriebstechnik GmbH":
						LoadPraewemaMachines();
						break;
					case "Reishauer AG":
						LoadReishauerMachines();
						break;
					case "KAPP":
						LoadKappMachines();
						break;
					case "Weisser":
						LoadWeisserMachines();
						break;
				}
			}
		}

		public void OnNavigatedTo()
		{
			GetSelectedMachine();
		}

		public void GetSelectedMachine()
		{
			SelectedMachine = WeakReferenceManager.GetReference("SelectedMachine") as MachineModel;

			if (SelectedMachine == null)
			{
				ClearStrings();
			}
			else
			{
				Id = SelectedMachine.Id;
				MachineNumber = SelectedMachine.MachineNumber;
				SpindleC1 = SelectedMachine.SpindleC1;
				SpindleC2 = SelectedMachine.SpindleC2;
				HoningHead = SelectedMachine.HoningHead;
				NCVersion = SelectedMachine.NCVersion;
				HMIVersion = SelectedMachine.HMIVersion;
				AHSVersion = SelectedMachine.AHSVersion;
				ACIControls = SelectedMachine.ACIControls;
				EnergyMonitoringACIControls = SelectedMachine.EnergyMonitoringACIControls;
				ACIControlsHeader = SelectedMachine.ACIControlsHeader;
				IWProject = SelectedMachine.IWProject;
				File1Master = SelectedMachine.File1Master;
				IndraWorks = SelectedMachine.IndraWorks;
				IndraLogic2G = SelectedMachine.IndraLogic2G;
				IndraMotionMTX = SelectedMachine.IndraMotionMTX;
				MTXBasisFirmware = SelectedMachine.MTXBasisFirmware;
				IWMTX = SelectedMachine.IWMTX;
				IWHMI = SelectedMachine.IWHMI;
				WinStudio = SelectedMachine.WinStudio;
				MTXFirmware = SelectedMachine.MTXFirmware;
				CardType = SelectedMachine.CardType;
				LPNo = SelectedMachine.LPNo;
				MTXHardwareVersion = SelectedMachine.MTXHardwareVersion;
				SerialNumber = SelectedMachine.SerialNumber;

				//Get Customer
				SelectedCustomer = Customers.FirstOrDefault(x => x.CustomerName == SelectedMachine.CustomerName);
				//Get Contractor
				SelectedContractor = Contractors.FirstOrDefault(x => x.Name == SelectedMachine.BrandName);
				//Get MachineModel
				SelectedMachineModel = MachineModels.FirstOrDefault(x => x.Model == SelectedMachine.Model);
				//Get MachineType
				SelectedMachineType = MachineTypes.FirstOrDefault(x => x.Type == SelectedMachine.Type);
			}
		}

		public async Task GetAllCustomers()
		{
			var result = await _supabaseClient.From<CustomerModel>().Get();

			Customers.Clear();
			foreach (var customer in result.Models)
			{
				Customers.Add(customer);
			}
		}

		public void AddContractorToList()
		{
			Contractors.Clear();
			Contractors.Add(new ContractorModel { ID = 1, Name = "Präwema Antriebstechnik GmbH" });
			Contractors.Add(new ContractorModel { ID = 1, Name = "Reishauer AG" });
			Contractors.Add(new ContractorModel { ID = 1, Name = "KAPP" });
			Contractors.Add(new ContractorModel { ID = 1, Name = "Weisser" });
		}

		public void LoadPraewemaMachines()
		{
			MachineModels.Clear();
			MachineModels.Add(new MachineModelModel { ID = 1, Model = "SynchroFine" });
			MachineModels.Add(new MachineModelModel { ID = 2, Model = "SynchroForm" });
			MachineModels.Add(new MachineModelModel { ID = 2, Model = "SynchroForm-V" });

			MachineTypes.Clear();
			MachineTypes.Add(new MachineTypeModel { ID = 1, Type = "205" });
			MachineTypes.Add(new MachineTypeModel { ID = 2, Type = "305" });
		}

		public void LoadReishauerMachines()
		{
			MachineModels.Clear();

			MachineTypes.Clear();
		}

		public void LoadKappMachines()
		{
			MachineModels.Clear();

			MachineTypes.Clear();
		}

		public void LoadWeisserMachines()
		{
			MachineModels.Clear();

			MachineTypes.Clear();
		}

		public void ClearStrings()
		{
			Id = 0;
			MachineNumber = "";
			SpindleC1 = "";
			SpindleC2 = "";
			HoningHead = "";
			NCVersion = "";
			HMIVersion = "";
			AHSVersion = "";
			ACIControls = "";
			EnergyMonitoringACIControls = "";
			ACIControlsHeader = "";
			IWProject = "";
			File1Master = "";
			IndraWorks = "";
			IndraLogic2G = "";
			IndraMotionMTX = "";
			MTXBasisFirmware = "";
			IWMTX = "";
			IWHMI = "";
			WinStudio = "";
			MTXFirmware = "";
			CardType = "";
			LPNo = "";
			MTXHardwareVersion = "";
			SerialNumber = "";

			ResetPickers();
		}
		public void ResetPickers()
		{
			SelectedCustomer = null;
			SelectedContractor = null;
			SelectedMachineModel = null;
			SelectedMachineType = null;
		}
	}
}
