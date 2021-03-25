using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.pipelines;
using TennisClub.WpfDesktop.mapppers;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
         
        private ChildWpf _newChild;
        
        private ICommand _addCommand;
        
        public ObservableCollection<ChildWpf> Children { get; private set; }
        public ObservableCollection<DayOfWeek> DaysOfWeek { get; private set; }
        public ObservableCollection<GameLevel> GameLevels { get; private set; }

        private readonly IChildFacade _childFacade;
        private readonly IMapper<Child, ChildWpf> _toUiChildMapper;
        private readonly IMapper<ChildWpf, Child> _fromUiChildMapper;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _newChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
            _childFacade = serviceProvider.GetRequiredService<IChildFacade>();
            serviceProvider.GetService<UnitOfWork>();
            _fromUiChildMapper = new FromUiChildMapper();
            _toUiChildMapper = new ToUiChildMapper();
            
            
            Children = new ObservableCollection<ChildWpf>(
                _childFacade.GetAll()
                    .Select(_toUiChildMapper.Map)
                    .ToList());

            DaysOfWeek = new ObservableCollection<DayOfWeek>(
                Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>());

            GameLevels = new ObservableCollection<GameLevel>(
                Enum.GetValues(typeof(GameLevel)).OfType<GameLevel>());
        }
        
        public ICommand AddCommand
        {
            get {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand<ChildWpf>(obj =>
                    {
                        if (obj == null) return;
                        bool isAdded = _childFacade.AddChild(
                            _fromUiChildMapper.Map(obj));
                        if (isAdded) Children.Add(NewChild);
                        NewChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
                    }
                    // obj => notEmptyStr(obj?.Name) 
                    //        && notEmptyStr(obj?.LastName)
                    //        && obj.Birthday != null
                    );
                }
                return _addCommand;
            }
        }

        
        public ChildWpf NewChild
        {
            get => _newChild;
            set
            {
                _newChild = value;
                OnPropertyChanged("NewChild");
            }
        }

        private bool notEmptyStr(string str)
        {
            return str != String.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}