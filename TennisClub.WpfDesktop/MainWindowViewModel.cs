using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClub.WpfDesktop.model;
using System.Windows.Input;


namespace TennisClub.WpfDesktop
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Child> Children { get; private set; }
        private Child _selectedChild { get; set; }
        MainWindowViewModel()
        {

        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get => _addCommand ??= new RelayCommand<Child>(obj => 
                {
                   //do something  
                });
        }

        public Child SelectedChild
        {
            get => _selectedChild;
            set
            {
                _selectedChild = value;
                OnPropertyChanged("SelectedChild");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
