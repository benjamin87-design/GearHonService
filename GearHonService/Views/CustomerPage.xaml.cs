using GearHonService.ViewModels;

namespace GearHonService.Views;

public partial class CustomerPage : ContentPage
{
	public CustomerPage(CustomerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void ContentPage_Appearing(object sender, EventArgs e)
	{
		OnAppearing();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		CustomerListView.SelectedItem = null;
	}
}