using GalaSoft.MvvmLight.Views;
using System;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigationService Navigation;
        private ChildAddViewModel _childAddViewModel;

        public MainViewModel(INavigationService navigation, IServiceProvider serviceProvider)
        {
            Navigation = navigation;
            _childAddViewModel = new ChildAddViewModel(this, serviceProvider);
        }
        
        public ChildAddViewModel ChildAddViewModel
        {
            get => _childAddViewModel;
            set
            {
                _childAddViewModel = value;
                RaisePropertyChanged(nameof(ChildAddViewModel));
            }
        }
    }
}
