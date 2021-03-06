﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TennisClub.WpfDesktop.ViewModel;


namespace TennisClub.WpfDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.Navigation
                .NavigateTo(PageType.StartPage.ToString());
        }
    }
}