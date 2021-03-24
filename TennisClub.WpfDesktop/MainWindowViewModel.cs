using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TennisClub.AppCore.model.impl;
using TennisClub.Infrastructure.pipelines;
using TennisClub.WpfDesktop.mapppers;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Child> Children { get; private set; }
        private Child _selectedChild { get; set; }

        private readonly ChildFacade _childPipeline;
        private readonly IMapper<Child, ChildWpf> _toUiChildMapper;
        private readonly IMapper<ChildWpf, Child> _fromUiChildMapper;

        MainWindowViewModel()
        {
            //_childPipeline = new ChildFacade();
            _fromUiChildMapper = new FromUiChildMapper();
            _toUiChildMapper = new ToUiChildMapper();
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand<ChildWpf>(obj =>
                    {
                        if (obj == null) return;
                        _childPipeline.AddChild(
                            _fromUiChildMapper.Map(obj));
                    });
                }
                return _addCommand;
            }
        }

        /*public Child SelectedChild
        {
            get => _selectedChild;
            set
            {
                _selectedChild = value;
                OnPropertyChanged("SelectedChild");
            }
        }*/



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}