using ApplicationPokedex.ViewModel;

namespace ApplicationPokedex.View;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}

	public void btnScanneur(object sender, EventArgs e)
    {
        //vers page du scanneur
        Navigation.PushAsync(new ScanPage());
    }

	public void btnCollec(object sender, EventArgs e)
    {
        //vers page de la collection
        Navigation.PushAsync(new CollecPage());
    }
}