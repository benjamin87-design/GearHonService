namespace GearHonService.Views.Navigation;

public partial class FlyoutFooter : ContentView
{
	public FlyoutFooter()
	{
		InitializeComponent();
	}

	private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
	}

	private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
	{
		Shell.Current.GoToAsync($"//{nameof(SettingPage)}");
	}
}