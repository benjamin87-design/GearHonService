namespace GearHonService.Views;

public partial class UserSettingPage : ContentPage
{
	public UserSettingPage(UserSettingViewModel viewModel)
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

		var viewModel = BindingContext as UserSettingViewModel;
		viewModel.GetUser();
	}
}