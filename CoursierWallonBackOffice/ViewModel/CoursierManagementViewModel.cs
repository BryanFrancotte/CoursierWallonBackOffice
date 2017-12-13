using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.ViewModel
{
    public class CoursierManagementViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public CoursierManagementViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
    }
}
