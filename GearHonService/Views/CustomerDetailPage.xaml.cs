using GearHonService.ViewModels;

namespace GearHonService.Views;

public partial class CustomerDetailPage : ContentPage
{
	public CustomerDetailPage(CustomerDetailViewModel viewModel)
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

		var viewModel = BindingContext as CustomerDetailViewModel;
		viewModel.OnNavigatedTo();
	}
}