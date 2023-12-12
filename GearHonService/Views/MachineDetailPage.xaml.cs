using GearHonService.ViewModels;

namespace GearHonService.Views;

public partial class MachineDetailPage : ContentPage
{
	public MachineDetailPage(MachineDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void ContentPage_Appearing(object sender, EventArgs e)
	{
		CustomerPicker.SelectedItem = null;
		BrandPicker.SelectedItem = null;
		ModelPicker.SelectedItem = null;
		TypePicker.SelectedItem = null;

		OnAppearing();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		var viewModel = BindingContext as MachineDetailViewModel;
		viewModel.OnNavigatedTo();
	}
}