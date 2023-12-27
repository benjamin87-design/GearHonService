namespace GearHonService.Views;

public partial class ExpenseDetailPage : ContentPage
{
	public ExpenseDetailPage(ExpenseDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}