using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Views;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class ViewLocator
    {
        private static readonly Dictionary<ControlType, Lazy<UserControl>> Controls =
            new Dictionary<ControlType, Lazy<UserControl>>();
        
        
        public ViewLocator(IServiceProvider serviceProvider)
        {
            NavigationService navigationService = new NavigationService();
            NavigationService = navigationService;
            
            // Controls.Add(ControlType.ChildCredentials, new Lazy<UserControl>(() => new ChildCredentials()));
            
            navigationService.Configure(PageType.ChildCredentialsPage.ToString(), 
                new Uri("../Pages/ChildCredentialsPage.xaml", UriKind.Relative));
            navigationService.Configure(PageType.StartPage.ToString(),
                new Uri("../Pages/StartPage.xaml", UriKind.Relative));
            navigationService.Configure(PageType.ChildDaysPage.ToString(),
                new Uri("../Pages/ChildDaysPage.xaml", UriKind.Relative));
            navigationService.Configure(PageType.ChildAddSuccessPage.ToString(),
                new Uri("../Pages/ChildAddSuccessPage.xaml", UriKind.Relative));
            navigationService.Configure(PageType.ChildChooseGroupPage.ToString(),
                new Uri("../Pages/ChildChooseGroupPage.xaml", UriKind.Relative));
            
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
        StartPage,
        ChildDaysPage
    }

    public enum PageType
    {
        ChildCredentialsPage,
        StartPage,
        ChildDaysPage,
        ChildAddSuccessPage,
        ChildChooseGroupPage
    }
}
