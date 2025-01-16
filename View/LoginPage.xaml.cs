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
            DisplayAlert("Erreur", "Aucun compte trouvé. Voulez-vous créer un nouveau compte avec ces paramètres ?", "Oui", "Non");
			//dao.CreateUtilisateurAsync(getUser(), getMdp());


		}
		else if (valeurUser == 0 && valeurMdp == 0)
		{
            DisplayAlert("Connexion Admin", "Vous êtes connecté en utilisateur Admin", "OK");
            //vers page MenuAccueil
            Navigation.PushAsync(new MenuPage());
        }
		else if (valeurUser == valeurMdp)
        {
			//déclaration de l'utilisateur connecté en tant que singleton (classe qui ne peut être instanciée qu'une fois sur toute l'application)
            UserSingleton.Instance.valeurUser = valeurUser;
            DisplayAlert("Connecté", "Vous êtes connecté en tant que " + getUser(), "OK");
            Navigation.PushAsync(new MenuPage());  
		}
		else
        {
            //demande de rentrer un nom d'utilisateur valide
            DisplayAlert("Erreur", "Veuillez rentrer votre nom d'utilisateur ! Si vous n'en avez pas encore, crée en 1 et commencer votre collection !", "OK");
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