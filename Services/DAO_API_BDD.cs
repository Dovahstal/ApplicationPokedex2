using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
using ApplicationPokedex.Model;
using ApplicationPokedex.ViewModel;
using ApplicationPokedex.View;
using Newtonsoft.Json.Linq;

namespace ApplicationPokedex.Services
{
    public class DAO_API_BDD
    {
        private readonly HttpClient _httpClient;

        public DAO_API_BDD()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://172.31.254.166/apiApp.php/")
            };
        }

        public async Task<List<utilisateur>> GetAllUtilisateurAsync()
        {
            var response = await _httpClient.GetAsync("GetAllUtilisateur");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<utilisateur>>(jsonResponse);
        }

        public async Task<List<pokemon>> GetPokeByUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"GetPokeByUser/{userId}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<pokemon>>(jsonResponse);
        }

        public int GetUserIDByName(string txtUtilisateur)
        {
            var response = _httpClient.GetAsync($"GetUserIDByName/{txtUtilisateur}").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            if (result.Contains("User not found"))
            {
                return 0;
            }
            var user = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);
            return user["IDUser"];
        }

        public int GetUserIDByMdp(string txtMdp)
        {
            var response = _httpClient.GetAsync($"GetUserIDByMdp/{txtMdp}").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            if (result.Contains("User not found"))
            {
                return 0;
            }
            var mdp = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);
            return mdp["IDUser"];
        }


        public int GetPokeIDNumber(string nomPoke)
        {

            using (HttpClient client = new HttpClient())
            {
                // Récupérer la réponse du serveur
                var response = client.GetAsync($"https://pokebuildapi.fr/api/v1/pokemon/{nomPoke}").Result;
                var result = response.Content.ReadAsStringAsync().Result;

                // Désérialiser la réponse JSON
                JObject jsonResponse = JObject.Parse(result);

                // Extraire le numéro de Pokédex
                int pokeID = (int)jsonResponse["pokedexId"];

                return pokeID;
            }
        }

        public async Task CreateUtilisateurAsync(string txtUtilisateur, string txtMdp)
        {         
            var response = await _httpClient.PostAsync($"CreateUtilisateur/{txtUtilisateur}/{txtMdp}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddPokeCollecAsync(string nomPoke, string photoPoke, int collecId, int numPoke)
        {
            var response = await _httpClient.PostAsync($"AddPokeCollec/{nomPoke}/{photoPoke}/{collecId}/{numPoke}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<int> GetIDCollecAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"GetIDCollec/{userId}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var collectionData = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonResponse);

            if (collectionData.ContainsKey("IDCollection"))
            {
                return collectionData["IDCollection"];
            }

            return 0;
        }


    }
}
