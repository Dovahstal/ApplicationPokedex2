using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPokedex.Model
{
    internal class API_BDD
    {
    }

    public class utilisateur
    {
        public int IDUser { get; set; }
        public string NomUser { get; set; }
        public string MDPUser { get; set; }
    }

    public class collection
    {
        public int IDCollection { get; set; }
        public int UTILISATEUR_IDUser { get; set; }
    }

    public class pokemon
    {
        public int IDPokemon { get; set; }
        public string NomPokemon { get; set; }
        public string PhotoPokemon { get; set; }
        public int COLLECTION_IDCollection { get; set; }
        public int NumeroPoke { get; set; }
    }
}
