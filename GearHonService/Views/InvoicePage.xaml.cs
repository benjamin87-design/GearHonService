using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using System.Threading;

namespace GearHonService.Views;

public partial class InvoicePage : ContentPage
{
	public string FolderPathSelected { get; set; }
	public InvoicePage(InvoiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			await PickFolder(CancellationToken.None);
		}
		catch
		{
			await Shell.Current.DisplayAlert("Folder Selection Canceled", "You have canceled the folder selection", "Ok");
		}
		
	}

	async Task PickFolder(CancellationToken cancellationToken)
	{
		var result = await FolderPicker.Default.PickAsync(cancellationToken);
		if (result.IsSuccessful)
		{
			FolderPathSelected = result.Folder.Path + "\\Invoice.png";

			var resultpng = await print.CaptureAsync();

			using MemoryStream memoryStream = new();
			await resultpng.CopyToAsync(memoryStream);

			File.WriteAllBytes(FolderPathSelected, memoryStream.ToArray());

			var viewModel = BindingContext as InvoiceViewModel;
			await viewModel.SaveInvoice();
		}
		else
		{
			await Toast.Make($"The folder was not picked with error: {result.Exception.Message}").Show(cancellationToken);
		}
	}
}