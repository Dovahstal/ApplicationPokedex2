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
        DAO_API_BDD dao = new DAO_API_BDD();
		int valeurUser = dao.GetUserIDByName(getUser());
		int valeurMdp = dao.GetUserIDByMdp(getMdp());

		if (valeurUser != valeurMdp)
		{
            DisplayAlert("Erreur", "Aucun compte trouv�. Voulez-vous cr�er un nouveau compte avec ces param�tres ?", "Oui", "Non");
			//dao.CreateUtilisateurAsync(getUser(), getMdp());


		}
		else if (valeurUser == 0 && valeurMdp == 0)
		{
            DisplayAlert("Connexion Admin", "Vous �tes connect� en utilisateur Admin", "OK");
            //vers page MenuAccueil
            Navigation.PushAsync(new MenuPage());
        }
		else if (valeurUser == valeurMdp)
        {
			//d�claration de l'utilisateur connect� en tant que singleton (classe qui ne peut �tre instanci�e qu'une fois sur toute l'application)
            UserSingleton.Instance.valeurUser = valeurUser;
            DisplayAlert("Connect�", "Vous �tes connect� en tant que " + getUser(), "OK");
            Navigation.PushAsync(new MenuPage());  
		}
		else
        {
            //demande de rentrer un nom d'utilisateur valide
            DisplayAlert("Erreur", "Veuillez rentrer votre nom d'utilisateur ! Si vous n'en avez pas encore, cr�e en 1 et commencer votre collection !", "OK");
        }
	}

	public string getUser()
    {
		return userTxt.Text;

    }

	public string getMdp()
	{
		return mdpTxt.Text;
	}
}