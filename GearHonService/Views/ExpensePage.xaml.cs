namespace GearHonService.Views;

public partial class ExpensePage : ContentPage
{
	public ExpensePage(ExpenseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}