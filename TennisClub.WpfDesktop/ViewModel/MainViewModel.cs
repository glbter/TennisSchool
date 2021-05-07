using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigationService Navigation;
        private ChildAddViewModel _childAddViewModel;

        public MainViewModel(INavigationService navigation)
        {
            Navigation = navigation;
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
