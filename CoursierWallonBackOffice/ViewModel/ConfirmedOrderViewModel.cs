﻿using CoursierWallonBackOffice.Model;
using CoursierWallonBackOffice.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursierWallonBackOffice.ViewModel
{
    public class ConfirmedOrderViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ConfirmedOrderViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        } 

        private ObservableCollection<OrderWithNbItems> _orders = null;
        public ObservableCollection<OrderWithNbItems> Orders
        {
            get
            {
                return _orders;
            }

            set
            {
                if (_orders == value)
                {
                    return;
                }
                _orders = value;
                RaisePropertyChanged("Orders");
            }
        }

        private OrderWithNbItems _selectedOrder;
        public OrderWithNbItems SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                if (_selectedOrder != null)
                {
                    RaisePropertyChanged("SelectedOrder");
                }
            }
        }

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
                if (this._homeCommand == null)
                {
                    this._homeCommand = new RelayCommand(() => GoToHome());
                }
                return this._homeCommand;
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (this._refreshCommand == null)
                {
                    this._refreshCommand = new RelayCommand(() => InitializeAsync());
                }
                return this._refreshCommand;
            }
        }

        public void OrderDetails()
        {
            if (CanExecute())
            {
                this._navigationService.NavigateTo("OrderDetailsPage", SelectedOrder);
            }
        }

        public void GoToHome()
        {
            this._navigationService.NavigateTo("HomePage");
        }

        public async Task InitializeAsync()
        {
            var service = new OrderService();
            var orderslist = await service.GetAllOrderConfirmed(Token.tokenCurrent);
            Orders = new ObservableCollection<OrderWithNbItems>(orderslist);
        }

        public void OnNavigatedTo()
        {
            InitializeAsync();
        }

        private bool CanExecute()
        {
            return SelectedOrder != null;
        }
    }
}
