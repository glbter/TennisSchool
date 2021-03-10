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
            Array days = Enum.GetValues(typeof(DayOfWeek));
            DayOfWeekCbx.ItemsSource = days;
            DayOfWeekCbx.SelectedItem = days.GetValue(0);
            List<Child> children = new List<Child>();
            children.Add(new Child("John", "Doe"));
            children.Add(new Child("Joe", "Doe"));
            //   childLw.Resources = children;
            //children.ForEach(it => this.childLw.Items.Add(it));
            this.childLw.ItemsSource = children;
        }
    }

    class Child
    {
        public Child(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
