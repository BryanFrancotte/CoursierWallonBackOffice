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
    public class OrderManagementViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private ICommand _orderDetailsCommand;
        public ICommand OrderDetailsCommand
        {
            get
            {
                if (this._orderDetailsCommand == null)
                {
                    this._orderDetailsCommand = new RelayCommand(() => OrderDetails());
                }
                return this._orderDetailsCommand;
            }
        }

        private ICommand _homeCommand;
        public ICommand HomeCommand
        {
            get
            {
                if(this._homeCommand == null)
                {
                    this._homeCommand = new RelayCommand(() => Home());
                }
                return this._homeCommand;
            }
        }

        public OrderManagementViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void OrderDetails()
        {
            this._navigationService.NavigateTo("OrderDetailsPage");
        }

        public void Home()
        {
            this._navigationService.NavigateTo("HomePage");
        }
    }
}
