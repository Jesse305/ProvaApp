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
    public partial class ListCarsPage : ContentPage
    {
        public ListCarsPage()
        {
            InitializeComponent();
            BindingContext = new ListCarsPageViewModel();

            MyListView.ItemSelected += MyListView_ItemSelected;
            
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedCar = e.SelectedItem as Models.Car;
            if(SelectedCar != null)
            {
                await Navigation.PushAsync(new Views.DetalheCarPage(SelectedCar));
                MyListView.SelectedItem = null;
            }
        }
    }
}