using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class StartViewModel: BaseViewModel
    {
        private readonly MainViewModel _mainViewModel;

        private RelayCommand<object> _navigateToChildCredentialsCommand;

        public StartViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public RelayCommand<object> NavigateToChildCredentialsCommand
        {
            get
            {
                _navigateToChildCredentialsCommand ??= 
                    new RelayCommand<object>(NavigateToChildCredentials);
                return _navigateToChildCredentialsCommand;
            }
        }

        private void NavigateToChildCredentials(object obj)
        {
            _mainViewModel.Navigation.NavigateTo(ViewLocator.ChildCredentialsPage);
        }
    }
}
