using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class StartViewModel: BaseViewModel
    {
        private readonly MainViewModel _mainViewModel;

        private RelayCommand _navigateToChildCredentialsCommand;

        public StartViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public RelayCommand NavigateToChildCredentialsCommand
        {
            get
            {
                _navigateToChildCredentialsCommand ??= 
                    new RelayCommand(NavigateToChildCredentials);
                return _navigateToChildCredentialsCommand;
            }
        }

        private void NavigateToChildCredentials()
        {
            _mainViewModel.Navigation.NavigateTo(
                PageType.ChildCredentialsPage.ToString());
        }
    }
}
