namespace GearHonService.Views;

public partial class ContractorPage : ContentPage
{
	public ContractorPage(ContractorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}