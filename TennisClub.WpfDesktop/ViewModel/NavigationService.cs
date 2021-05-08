using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class NavigationService : BaseViewModel, INavigationService
    {
        private string _currentPageKey;
        private readonly Stack<string> _history;
        private readonly Dictionary<string, Uri> _pagesByKey;

        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _history = new Stack<string>();
        }

        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(key))
                    _pagesByKey.Add(key, pageType);
                
                _pagesByKey[key] = pageType;
            }
        }
        

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (string.IsNullOrEmpty(pageKey))
                    return;

                if (!_pagesByKey.ContainsKey(pageKey))
                    return;

                if (GetDescendantFromName(Application.Current.MainWindow, "MainFrame") is Frame frame)
                    frame.Source = _pagesByKey[pageKey];
                Parameter = parameter;
                _history.Push(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        private FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            if (count < 1) return null;

            for (var i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name) return frameworkElement;
                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null) return frameworkElement;
                }
            }
            return null;
        }
        
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }
        
        public void GoBack()
        {
            if (_history.Count > 1)
            {
                _history.Pop();
                NavigateTo(_history.Last(), null);
            }
        }
        
        public object Parameter { get; private set; }
        public string CurrentPageKey
        {
            get => _currentPageKey;
            private set
            {
                if (_currentPageKey == value) return;
                
                _currentPageKey = value;
                RaisePropertyChanged("CurrentPageKey");
            }
        }
    }
}
