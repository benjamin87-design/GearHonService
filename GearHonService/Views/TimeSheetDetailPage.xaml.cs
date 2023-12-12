using GearHonService.ViewModels;

namespace GearHonService.Views;

public partial class TimeSheetDetailPage : ContentPage
{
	public TimeSheetDetailPage(TimeSheetDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}