using CoursierWallonBackOffice.Model;
using CoursierWallonBackOffice.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;

namespace CoursierWallonBackOffice.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public string EmailUserEntry { get; set; }
        public string PasswordUserEntry { get; set; }
        public LoginUser LoginUser { get { return new LoginUser(this.EmailUserEntry, this.PasswordUserEntry); } }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (this._loginCommand == null)
                {
                    this._loginCommand = new RelayCommand(() => Login());
                }
                return this._loginCommand;
            }
        }

        public LoginViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public async Task Login()
        {
            var service = new UserService();
            int resultCode = await service.LoginUser(LoginUser);

            switch (resultCode)
            {
                case 200:
                    GoToHomePage();
                    break;
                case 401:
                    var messageNotAdmin = new Windows.UI.Popups.MessageDialog("Accès interdit");
                    await messageNotAdmin.ShowAsync();
                    break;
                case 404:
                    var messageNotFound = new Windows.UI.Popups.MessageDialog("Serveur non trouvé");
                    await messageNotFound.ShowAsync();
                    break;
                case 0:
                    var messageProbleme = new Windows.UI.Popups.MessageDialog("Problème de connection");
                    await messageProbleme.ShowAsync();
                    break;
            }
        }
        
        public void GoToHomePage()
        {
            _navigationService.NavigateTo("HomePage");
        }
    }
}
