namespace GearHonService.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutViewModel viewModel)
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

		var viewModel = BindingContext as AboutViewModel;
		viewModel.GetStrings();
	}
}