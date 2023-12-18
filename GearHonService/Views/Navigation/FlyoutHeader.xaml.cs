using System.Diagnostics;

namespace GearHonService.Views.Navigation;
public partial class FlyoutHeader : ContentView
{
	private Supabase.Client supabase;
	public FlyoutHeader()
	{
		InitializeComponent();

		//initzialize supabase client
		var url = "https://pzvwsjvyfegmnuactovr.supabase.co";
		var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InB6dndzanZ5ZmVnbW51YWN0b3ZyIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTcwMjU0MDMsImV4cCI6MjAxMjYwMTQwM30.2hRWxbX3DjveekpQfjcQEz979Z46Q5mk9kVWPy-k-5I";

		supabase = new Supabase.Client(url, key);

		GetUserName();
		GetProfilePicture();
	}

	private void GetUserName()
	{
		UserNameText.Text = Preferences.Get("email", "");
	}
	private async Task GetProfilePicture()
	{

		var profilepicture = Preferences.Get("profilepicture", "");

		var bytes = await supabase.Storage
			.From("UserProfilePic")
			.Download(profilepicture, (sender, progress) => Debug.WriteLine($"{progress}%"));

		ProfilePictureImage.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
	}
}