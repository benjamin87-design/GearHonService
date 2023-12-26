using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.ViewModels
{
    public partial class ContractorViewModel : BaseViewModel
	{

		[ObservableProperty]
		private ObservableCollection<ContractorModel> contractors;

		private readonly Supabase.Client _supabaseClient;

		public ContractorViewModel(Supabase.Client supabaseClient)
		{
			_supabaseClient = supabaseClient;

			Contractors = new ObservableCollection<ContractorModel>();

			LoadContractorFromDb();
        }

        public async Task LoadContractorFromDb()
        {
			var result = await _supabaseClient.From<ContractorModel>().Get();
			Contractors.Clear();
			foreach (var contractor in result.Models)
			{
				Contractors.Add(contractor);
			}
		}
    }
}
