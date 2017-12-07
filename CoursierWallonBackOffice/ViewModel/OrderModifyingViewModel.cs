using CoursierWallonBackOffice.Model;
using CoursierWallonBackOffice.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public string PickUpTime { get; set; }
        public string DepositTime { get; set; }
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
            SelectedOrder.Order.CoursierIdOrder = SelectedCoursier.Id;
            SelectedOrder.NameCoursier = SelectedCoursier.NormalizedUserName;
            _navigation.NavigateTo("OrderDetailsPage", SelectedOrder);
        }
    }
}
