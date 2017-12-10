using CoursierWallonBackOffice.Model;
using CoursierWallonBackOffice.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Navigation;

namespace CoursierWallonBackOffice.ViewModel
{
    public class OrderModifyingViewModel : ViewModelBase
    {
        public INavigationService _navigation;
        public OrderWithNbItems SelectedOrder { get; set; }
        private ObservableCollection<ApplicationUser> _coursierUsers;
        public ObservableCollection<ApplicationUser> CoursierUsers
        {
            get { return _coursierUsers; }
            set
            {
                if(_coursierUsers == value)
                {
                    return;
                }
                _coursierUsers = value;
                RaisePropertyChanged("CoursierUsers");
            }
        }

        public bool _asPickUpTime;
        public bool AsPickUpTime
        {
            get { return _asPickUpTime; }
            set
            {
                if (_asPickUpTime == value)
                {
                    return;
                }
                _asPickUpTime = value;
                RaisePropertyChanged("AsPickUpTime");
            }
        }
        public bool _asDepositTime;
        public bool AsDepositTime
        {
            get { return _asDepositTime; }
            set
            {
                if (_asDepositTime == value)
                {
                    return;
                }
                _asDepositTime = value;
                RaisePropertyChanged("AsDepositTime");
            }
        }
        public TimeSpan PickUpTime { get; set; }
        public TimeSpan DepositTime { get; set; }
        public ApplicationUser SelectedCoursier { get; set; }

        private ICommand _confirmCommand;
        public ICommand ConfirmCommand
        {
            get
            {
                if(_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand(() => ConfirmModification());
                }
                return _confirmCommand;
            }
        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get
            {
                if(_backCommand == null)
                {
                    _backCommand = new RelayCommand(() => GoBack());
                }
                return _backCommand;
            }
        }

        public OrderModifyingViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            PickUpTime = DepositTime = DateTime.Now.TimeOfDay;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedOrder = (OrderWithNbItems)e.Parameter;
            Initialize();
        }

        public async Task Initialize()
        {
            var service = new UserService();
            var coursierUserList = await service.GetAllUsers(Token.tokenCurrent);
            CoursierUsers = new ObservableCollection<ApplicationUser>(coursierUserList);
        }

        public void GoBack()
        {
            _navigation.GoBack();
        }

        public void ConfirmModification()
        {
            if (CanConfirm())
            {
                SetSelectedOrder();
                _navigation.NavigateTo("OrderDetailsPage", SelectedOrder);
            }
            else
            {
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastElements = notificationXml.GetElementsByTagName("text");
                toastElements[0].AppendChild(notificationXml.CreateTextNode("Aucun coursier selectionné!!"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            }
        }

        public void SetSelectedOrder()
        {
            SelectedOrder.Order.CoursierIdOrder = SelectedCoursier.Id;
            SelectedOrder.Order.CoursierIdOrderNavigation = SelectedCoursier;
            if (AsPickUpTime)
            {
                SelectedOrder.Order.PickUpTime = PickUpTime.ToString(@"hh\:mm");
            }
            else
            {
                SelectedOrder.Order.PickUpTime = null;
            }
            if (AsDepositTime)
            {
                SelectedOrder.Order.DepositTime = DepositTime.ToString(@"hh\:mm");
            }
            else
            {
                SelectedOrder.Order.DepositTime = null;
            }
        }

        public bool CanConfirm()
        {
            return SelectedCoursier != null;
        }
    }
}
