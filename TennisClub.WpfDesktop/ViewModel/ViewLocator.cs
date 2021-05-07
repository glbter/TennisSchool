using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class ViewLocator
    {
        private static Dictionary<ControlType, Lazy<UserControl>> controls =
            new Dictionary<ControlType, Lazy<UserControl>>();

        public const string ChildCredentialsPage = "ChildCredentialsPage";
        
        
        public ViewLocator()
        {
            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            
            // navigationService.Configure
            // controls.Add(ControlType.Accessories, new Lazy<UserControl>(() => new AccessoriesControl()));
            // navigationService.Configure(LoginPage, new Uri("../Pages/Auth/LoginPage.xaml", UriKind.Relative));
            
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel 
            => SimpleIoc.Default.GetInstance<MainViewModel>();

        public static UserControl GetControl(ControlType controlType)
        {
            if (controls.ContainsKey(controlType))
                return controls[controlType].Value;

            return new UserControl();
        }
    }
    
    public enum ControlType
    {
        ChildCredentials
    }
}
