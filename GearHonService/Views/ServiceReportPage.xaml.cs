namespace GearHonService.Views;

public partial class ServiceReportPage : ContentPage
{
	public ServiceReportPage(ServiceReportViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}