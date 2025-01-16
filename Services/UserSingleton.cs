using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPokedex.Services
{
    //classe singleton (qui ne peut être instanciée qu'une fois et dont l'instance est accésible globalement) pour stocker les informations de l'utilisateur et pouvoir les utiliser dans toute l'application
    public class UserSingleton
    {
        private static UserSingleton _instance;

        public int valeurUser { get; set; }
        public int valeurMdp { get; set; }

        private UserSingleton() { }

        public static UserSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSingleton();
                }
                return _instance;
            }
        }
    }
}
