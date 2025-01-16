using ApplicationPokedex.ViewModel;

namespace ApplicationPokedex.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}

	public void btnClick(object sender, EventArgs e)
    {
        //vers page MenuAccueil
        Navigation.PushAsync(new MenuPage());
    }
}