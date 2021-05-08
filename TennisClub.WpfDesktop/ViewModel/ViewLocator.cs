using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using TennisClub.WpfDesktop.Controls;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class ViewLocator
    {
        private static Dictionary<ControlType, Lazy<UserControl>> controls =
            new Dictionary<ControlType, Lazy<UserControl>>();

        public const string ChildCredentialsPage = "ChildCredentialsPage";
        
        
        public ViewLocator(IServiceProvider serviceProvider)
        {
            NavigationService = new NavigationService();
            //NavigationService navigationService = new NavigationService();
            //SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            
            controls.Add(ControlType.ChildCredentials, new Lazy<UserControl>(() => new ChildCredentials()));
            
            NavigationService.Configure(ChildCredentialsPage, new Uri("../Pages/ChildCredentialsPage.xaml", UriKind.Relative));

            MainViewModel = new MainViewModel(NavigationService, serviceProvider);
            //SimpleIoc.Default.Register<MainViewModel>(() => MainViewModel);
        }

        public MainViewModel MainViewModel { get; }
        public NavigationService NavigationService { get; }
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
