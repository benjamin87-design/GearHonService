namespace GearHonService.Views;

public partial class InvoicePage : ContentPage
{
	public InvoicePage(InvoiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}