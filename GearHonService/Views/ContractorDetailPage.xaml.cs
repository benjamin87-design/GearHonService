namespace GearHonService.Views;

public partial class ContractorDetailPage : ContentPage
{
	public ContractorDetailPage(ContractorDetailViewModel viewModel)
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

		var viewModel = BindingContext as ContractorDetailViewModel;
		viewModel.OnNavigatedTo();
	}
}