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
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private ICommand _CoursierManagementCommand;
        public ICommand CoursierManagementCommand
        {
            get
            {
                if (this._CoursierManagementCommand == null)
                {
                    this._CoursierManagementCommand = new RelayCommand(() => CoursierManagement());
                }
                return this._CoursierManagementCommand;
            }
        }

        private ICommand _OrderManagementCommand;
        public ICommand OrderManagementCommand
        {
            get
            {
                if (this._OrderManagementCommand == null)
                {
                    this._OrderManagementCommand = new RelayCommand(() => OrderManagement());
                }
                return this._OrderManagementCommand;
            }
        }

        private ICommand _confirmedOrderManagementCommand;
        public ICommand ConfirmedOrderManagementCommand
        {
            get
            {
                if(this._confirmedOrderManagementCommand == null)
                {
                    this._confirmedOrderManagementCommand = new RelayCommand(() => ConfirmedOrder());
                }
                return this._confirmedOrderManagementCommand;
            }
        }

        public HomeViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
        
        public void CoursierManagement()
        {
            this._navigationService.NavigateTo("CoursierManagementPage");
        }
        public void OrderManagement()
        {
            this._navigationService.NavigateTo("OrderManagementPage");
        }
        public void ConfirmedOrder()
        {
            this._navigationService.NavigateTo("ConfirmedOrder");
        }
    }
}
