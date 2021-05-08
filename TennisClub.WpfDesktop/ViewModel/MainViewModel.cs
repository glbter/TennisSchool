using GalaSoft.MvvmLight.Views;
using System;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigationService Navigation;
        private ChildAddViewModel _childAddViewModel;
        private StartViewModel _startViewModel;

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

        public StartViewModel StartViewModel
        {
            get => _startViewModel;
            set
            {
                _startViewModel = value;
                RaisePropertyChanged(nameof(StartViewModel));
            }
        }
    }
}
