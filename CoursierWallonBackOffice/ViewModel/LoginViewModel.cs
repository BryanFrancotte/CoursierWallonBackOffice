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
            Token token = await service.LoginUser(LoginUser);



            if (token == null)
            {
                //Se renseigner sur un autre moyen de faire des notifications
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastElements = notificationXml.GetElementsByTagName("text");
                toastElements[0].AppendChild(notificationXml.CreateTextNode("Problème de connection"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            }
            else
            {
                Token.tokenCurrent = token;
                GoToHomePage();
            }
        }
        
        public void GoToHomePage()
        {
            _navigationService.NavigateTo("HomePage");
        }
    }
}
