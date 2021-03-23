using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisClub.AppCore.model.impl;
using TennisClub.WpfDesktop.mappers;

namespace TennisClub.WpfDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            {
                Array elems = Enum.GetValues(typeof(DayOfWeek));
                DayOfWeekCbx.ItemsSource = elems;
                DayOfWeekCbx.SelectedItem = elems.GetValue(0);

                elems = Enum.GetValues(typeof(GameLevel));
                GameLevelCbx.ItemsSource = elems;
                DayOfWeekCbx.SelectedItem = elems.GetValue(0);
            }
            var mapper = new ChildMapper();
            this.childLw.ItemsSource = mapper.Children();
        }
    }

  
}
