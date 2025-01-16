using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ApplicationPokedex.View;

namespace ApplicationPokedex.ViewModel
{
    public partial class ScanViewModel
    {

        public ScanViewModel()
        {
            OnAppearing();
        }

        async void OnAppearing()
        {
            string imagePath = @"D:\Test\pikachu.jpg";
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                throw new FileNotFoundException("Le fichier spécifié n'existe pas ou le chemin est invalide.");
            }

            // Charger l'image en bytes
            var imageBytes = File.ReadAllBytes(imagePath);

            ModelPokedex.ModelInput sampleData = new ModelPokedex.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = ModelPokedex.Predict(sampleData);
            string prediction = result.PredictedLabel;
            prediction.ToLower();
            //afficher le resultat dans un pop-up
            await App.Current.MainPage.DisplayAlert("Prediction", prediction.ToLower(), "OK");

            DAO_API_BDD dao = new DAO_API_BDD();
            await App.Current.MainPage.DisplayAlert("ID", dao.GetPokeIDNumber(prediction.ToLower()).ToString(), "OK");


            //try
            //{
            //    if (MediaPicker.IsCaptureSupported)
            //    {
            //        var dossierPhotosLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "PhotosScan");
            //        if (!Directory.Exists(dossierPhotosLocal))
            //        {
            //            Directory.CreateDirectory(dossierPhotosLocal);
            //        }

            //        var photo = await MediaPicker.CapturePhotoAsync();
            //        if (photo != null)
            //        {

            //            //copie la photo prise dans le dossier PhotosScan du projet
            //            var cheminPhoto = Path.Combine(dossierPhotosLocal, $"photo_{DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)}.jpg");
            //            using (var stream = await photo.OpenReadAsync())
            //            {
            //                using (var newStream = File.OpenWrite(cheminPhoto))
            //                {
            //                    await stream.CopyToAsync(newStream);
            //                }
            //            }

            //            // Charger l'image en tant que tableau de bytes
            //            var imageBytes = File.ReadAllBytes(cheminPhoto);

            //            // Créer l'input pour la prédiction
            //            ModelPokedex.ModelInput sampleData = new ModelPokedex.ModelInput()
            //            {
            //                ImageSource = imageBytes
            //            };

            //            // Appeler la fonction Predict du modèle
            //            var result = ModelPokedex.Predict(sampleData);
            //            string prediction = result.PredictedLabel;

            //            // Afficher les résultats de la prédiction
            //            await App.Current.MainPage.DisplayAlert("Prediction", prediction, "OK");


            //        }
            //    }
            //    else
            //    {
            //        App.Current.MainPage.DisplayAlert("Erreur", "La caméra n'est pas disponible.", "OK");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    App.Current.MainPage.DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
            //}

        }

    }
}
