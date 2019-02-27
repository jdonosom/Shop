using GalaSoft.MvvmLight.Command;
using Shop.UIForms.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.UIForms.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            this.Email = "jpdonosom@gmail.com";
            this.Password = "123456";
        }

        public string  Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar su Email",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar su Password",
                    "Aceptar");
                return;
            }

            if ( !(this.Email.Equals("jpdonosom@gmail.com") || this.Password.Equals("123456")) )
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Credenciales incorrectas!!",
                    "Aceptar");
                return;
            }

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
