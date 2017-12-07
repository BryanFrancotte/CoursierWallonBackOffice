using CoursierWallonBackOffice.Constant;
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
using Windows.UI.Xaml.Navigation;

namespace CoursierWallonBackOffice.ViewModel
{
    public class OrderDetailsViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public OrderWithNbItems SelectedOrder { get; set; }

        private ICommand _modifyingCommand;
        public ICommand ModifyingCommand
        {
            get
            {
                if(_modifyingCommand == null)
                {
                    _modifyingCommand = new RelayCommand(() => GoToModification());
                }
                return _modifyingCommand;
            }
        }

        private ICommand _declineCommand;
        public ICommand DeclineCommand
        {
            get
            {
                if(_declineCommand == null)
                {
                    _declineCommand = new RelayCommand(() => Decline());
                }
                return _declineCommand;
            }
        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand(() => GoBack());
                }
                return _backCommand;
            }
        }

        public OrderDetailsViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedOrder = (OrderWithNbItems)e.Parameter;
        }

        public void GoToModification()
        {
            this._navigationService.NavigateTo("OrderModifyingPage", SelectedOrder);
        }

        public async Task Decline()
        {
            var service = new OrderService();
            int resultCode = await service.DeleteOrderById(SelectedOrder.Order.OrderNumber, Token.tokenCurrent);
            
            if(resultCode != HttpResponseCode.HTTP_OK)
            {
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastElements = notificationXml.GetElementsByTagName("text");
                toastElements[0].AppendChild(notificationXml.CreateTextNode("L'élément à supprimer est introuvable"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            }
            _navigationService.NavigateTo("OrderManagementPage");
        }

        public void GoBack()
        {
            this._navigationService.GoBack();
        }
    }
}