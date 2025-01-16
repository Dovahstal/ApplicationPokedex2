namespace ApplicationPokedex.View;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}
}