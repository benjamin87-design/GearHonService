namespace GearHonService.Views;

public partial class UserSettingPage : ContentPage
{
	public UserSettingPage(UserSettingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}