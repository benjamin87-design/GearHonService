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
}