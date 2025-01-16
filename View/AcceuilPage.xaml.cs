using ApplicationPokedex.ViewModel;

namespace ApplicationPokedex.View;

public partial class AcceuilPage : ContentPage
{
	public AcceuilPage()
	{
		InitializeComponent();
        BindingContext = new AcceuilViewModel();
    }

	private void btnClick(object sender, EventArgs e)
    {
        //vers page MenuAccueil
        Navigation.PushAsync(new LoginPage());
    }
}