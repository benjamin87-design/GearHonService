using GearHonService.Message;
using GearHonService.ViewModels;

namespace GearHonService.Views;

public partial class MachinePage : ContentPage
{
	public MachinePage(MachineViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void ContentPage_Appearing(object sender, EventArgs e)
	{
		MachineListView.SelectedItem = null;
    }
}