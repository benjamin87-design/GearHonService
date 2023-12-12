using GearHonService.ViewModels;

namespace GearHonService.Views;

public partial class TimeSheetPage : ContentPage
{
	public TimeSheetPage(TimeSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}