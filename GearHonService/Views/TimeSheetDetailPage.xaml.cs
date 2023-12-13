namespace GearHonService.Views;

public partial class TimeSheetDetailPage : ContentPage
{
	public TimeSheetDetailPage(TimeSheetDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void ContentPage_Appearing(object sender, EventArgs e)
	{
		CustomerNamePicker.SelectedItem = null;
		MachineNumberPicker.SelectedItem = null;
		WorkTypePicker.SelectedItem = null;

		OnAppearing();
    }

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var viewModel = BindingContext as TimeSheetDetailViewModel;
		await viewModel.OnNavigatedTo();

		CustomerNamePicker.SelectedItem = viewModel.SelectedCustomer;
		MachineNumberPicker.SelectedItem = viewModel.SelectedMachine;
		WorkTypePicker.SelectedItem = viewModel.SelectedWorkType;
	}
}