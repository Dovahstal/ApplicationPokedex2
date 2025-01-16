using ApplicationPokedex.ViewModel;

namespace ApplicationPokedex.View;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
		BindingContext = new ScanViewModel();
	}
}