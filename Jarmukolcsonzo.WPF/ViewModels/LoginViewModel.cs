using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jarmukolcsonzo.Shared.Repositories;
using Jarmukolcsonzo.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmukolcsonzo.WPF.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly ILoginRepository _repository;
        public LoginViewModel(ILoginRepository repository)
        {
            _repository = repository;
        }
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        private async Task Login()
        {
            string response = await _repository.AuthenticateAsync(Username, Password);
            if (string.IsNullOrEmpty(response))
            {
                //Todo: új ablak   
                MainWindow mainWindow = new();
                mainWindow.Show();//Új ablak megjelenítése
                //Bezárjuk a jelenlegi ablakot
                App.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
            }
            else
            {
                ErrorMessage = response;
            }
        }
    }
}
