using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ApplicationPokedex.ViewModel
{
    public class CollecViewModel
    {
        private readonly DAO_API_BDD _daoApi;
        public ObservableCollection<pokemon> ObsItemsPokemons { get; }

        public CollecViewModel()
        {
            _daoApi = new DAO_API_BDD();
            ObsItemsPokemons = new ObservableCollection<pokemon>();
            LoadPokemonsAsync();

        }

        public async Task LoadPokemonsAsync()
        {
            //rappel de la valeur de l'utilisateur (avec le singleton)
            int valeurUser = UserSingleton.Instance.valeurUser;
            try
            {
                var pokemons = await _daoApi.GetPokeByUserAsync(valeurUser);
                ObsItemsPokemons.Clear();
                foreach (var pokemon in pokemons)
                {
                    ObsItemsPokemons.Add(pokemon);
                }

            }            
            catch (Exception ex)
            {
                // Gérez les erreurs (log ou affichage d'un message d'erreur)
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
