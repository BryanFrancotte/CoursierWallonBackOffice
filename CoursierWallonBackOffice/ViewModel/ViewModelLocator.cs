using CoursierWallonBackOffice.View;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<CoursierManagementViewModel>();

            SimpleIoc.Default.Register<OrderManagementViewModel>();
            SimpleIoc.Default.Register<OrderDetailsViewModel>();

            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);
            navigationPages.Configure("LoginPage", typeof(LoginPage));
            navigationPages.Configure("HomePage", typeof(HomePage));
            navigationPages.Configure("CoursierManagementPage", typeof(CoursierManagmentPage));
            navigationPages.Configure("OrderManagementPage", typeof(OrderManagmentPage));
            navigationPages.Configure("OrderDetailsPage", typeof(OrderDetailsPage));
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public CoursierManagementViewModel CoursierManagement
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CoursierManagementViewModel>();
            }
        }

        public OrderManagementViewModel OrderManagement
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderManagementViewModel>();
            }
        }

        public OrderDetailsViewModel OrderDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderDetailsViewModel>();
            }
        }
    }
}
