namespace GearHonService.Views;

public partial class ContractorPage : ContentPage
{
	public ContractorPage(ContractorViewModel viewModel)
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

		ContractorListView.SelectedItem = null;
	}
}