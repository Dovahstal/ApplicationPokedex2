using ApplicationPokedex.View;

namespace ApplicationPokedex
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //vers page MenuAccueil
            Navigation.PushAsync(new AcceuilPage());
        }
    }

}
