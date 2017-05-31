using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProvaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheCarPage : ContentPage
    {
        Models.Car SelectedCar;
        public DetalheCarPage(Models.Car selectedCar)
        {
            InitializeComponent();
            SelectedCar = selectedCar;
            BindingContext = SelectedCar;

            btnVisitarPagina.Clicked += BtnVisitarPagina_Clicked;
        }

        private void BtnVisitarPagina_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (SelectedCar.PaginaWeb.StartsWith("http"))
                {
                    Device.OpenUri(new Uri(SelectedCar.PaginaWeb));
                }
            }
            catch (Exception)
            {

                App.Current.MainPage.DisplayAlert("Ops!, ", "Não há pagina para visitar!", "OK");
            }
        }
            
    }
}