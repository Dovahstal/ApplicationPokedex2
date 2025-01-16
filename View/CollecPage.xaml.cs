using ApplicationPokedex.ViewModel;

namespace ApplicationPokedex.View;

public partial class CollecPage : ContentPage
{
	public CollecPage()
	{
        InitializeComponent();
		BindingContext = new CollecViewModel();
	}
}