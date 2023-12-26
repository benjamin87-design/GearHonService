namespace GearHonService.Views;

public partial class ContractorDetailPage : ContentPage
{
	public ContractorDetailPage(ContractorDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}