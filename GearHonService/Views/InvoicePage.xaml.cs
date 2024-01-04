using CommunityToolkit.Maui.Storage;

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
			var folder = await FolderPicker.PickAsync(default);
			FolderPathSelected = folder.Folder.Path;
		}
		catch
		{
			// TODO Implement
		}
		var result = await print.CaptureAsync();
		//var stream = await result.OpenReadAsync();

		using MemoryStream memoryStream = new();
		//await stream.CopyToAsync(memoryStream);
		await result.CopyToAsync(memoryStream);

#warning ONLY WORKS ON WINDOWS!
		File.WriteAllBytes(FolderPathSelected + "/invoice.png", memoryStream.ToArray());

		//trigger the method saveinvoice in viewmodel
		var viewModel = BindingContext as InvoiceViewModel;
		await viewModel.SaveInvoice();
	}
}