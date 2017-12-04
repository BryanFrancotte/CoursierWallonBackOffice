using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.ViewModel
{
    public class OrderDetailsViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public OrderDetailsViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
    }
}
