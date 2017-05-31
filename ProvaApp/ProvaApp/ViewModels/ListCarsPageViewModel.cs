using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaApp.Models;
using ProvaApp.Services;
using Xamarin.Forms;

namespace ProvaApp.ViewModels
{
    public class ListCarsPageViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ObservableCollection<Car> Cars { get; set; }

        private bool _busy;
        public bool Busy
        {
            get { return _busy; }
            set
            {
                SetProperty(ref _busy, value);
                AtualizarCommand.ChangeCanExecute();
            }
        }

        public Command AtualizarCommand { get; set; }

        public ListCarsPageViewModel()
        {
            Cars = new ObservableCollection<Car>();
            AtualizarCommand = new Command(ExecuteAtualizarCommand, CanExecuteAtualizarCommand);
            ExecuteAtualizarCommand();
        }

        public void ExecuteAtualizarCommand()
        {
            GetCars();
        }

        public async Task GetCars()
        {
            if (!Busy)
            {
                try
                {
                    Busy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetCars();

                    Cars.Clear();
                    foreach (var Car in Items)
                    {
                        Cars.Add(Car);
                    }
                }
                catch (Exception e)
                {

                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alerta", e.Message, "OK");
                }
                finally
                {
                    Busy = false;
                }
            }
            return;
        }

        public bool CanExecuteAtualizarCommand()
        {
            if (!Busy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
