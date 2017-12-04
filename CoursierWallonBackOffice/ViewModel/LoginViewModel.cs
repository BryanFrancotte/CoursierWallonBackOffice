using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursierWallonBackOffice.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

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
        
        public void Login()
        {
            _navigationService.NavigateTo("HomePage");
        }
    }
}
