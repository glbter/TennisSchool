using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Views;
using TennisClub.WpfDesktop.Controls;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class ViewLocator
    {
        private static readonly Dictionary<ControlType, Lazy<UserControl>> Controls =
            new Dictionary<ControlType, Lazy<UserControl>>();

        public const string ChildCredentialsPage = "ChildCredentialsPage";
        public const string StartPage = "StartPage";
        
        
        public ViewLocator(IServiceProvider serviceProvider)
        {
            NavigationService navigationService = new NavigationService();
            NavigationService = navigationService;
            
            Controls.Add(ControlType.ChildCredentials, new Lazy<UserControl>(() => new ChildCredentials()));
            
            navigationService.Configure(ChildCredentialsPage, new Uri("../Pages/ChildCredentialsPage.xaml", UriKind.Relative));
            navigationService.Configure(StartPage, new Uri("../Pages/StartPage.xaml", UriKind.Relative));

            MainViewModel = new MainViewModel(navigationService, serviceProvider);
        }

        public MainViewModel MainViewModel { get; }
        public INavigationService NavigationService { get; }
        public static UserControl GetControl(ControlType controlType)
        {
            if (Controls.ContainsKey(controlType))
                return Controls[controlType].Value;

            return new UserControl();
        }
    }
    
    public enum ControlType
    {
        ChildCredentials,
        StartPage
    }
}
