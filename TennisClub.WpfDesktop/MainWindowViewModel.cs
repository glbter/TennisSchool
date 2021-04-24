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
using TennisClub.Infrastructure.mappers;
using TennisClub.WpfDesktop.mapppers;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
         
        private ChildWpf _newChild;
        private ChildWpf _prevChild;
        private GroupWpf _chosenGroup;
        private DayOfWeek _chosenDay;
        
        private ICommand _addCommand;
        private ICommand _chooseGroupCommand;
        private ICommand _addDayToListCommand;
        
        public ObservableCollection<ChildWpf> Children { get; private set; }
        public ObservableCollection<DayOfWeek> DaysOfWeek { get; private set; }
        public ObservableCollection<GameLevel> GameLevels { get; private set; }
        public ObservableCollection<GroupWpf> GroupsToChoose { get; private set; }
        public ObservableCollection<DayOfWeek> ChosenDays { get; private set; }

        private readonly IChildFacade _childFacade;
        private readonly IMapper<ChildWpf, Child> _fromUiChildMapper;
        private readonly IMapper<GroupWpf, Group> _fromUiGroupMapper;
        private readonly IMapper<Group, GroupWpf> _toUiGroupMapper;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _newChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
            _childFacade = serviceProvider.GetRequiredService<IChildFacade>();
            serviceProvider.GetService<UnitOfWork>();
            _fromUiChildMapper = new FromUiChildMapper();
            _fromUiGroupMapper = new FromUiGroupMapper();
            _toUiGroupMapper = new ToUiGroupMapper();
            IMapper<Child, ChildWpf> toUiChildMapper = new ToUiChildMapper();


            DaysOfWeek = new ObservableCollection<DayOfWeek>(
                Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>());
            Children = new ObservableCollection<ChildWpf>();
            GameLevels = new ObservableCollection<GameLevel>(
                Enum.GetValues(typeof(GameLevel)).OfType<GameLevel>());
            GroupsToChoose = new ObservableCollection<GroupWpf>();
            ChosenDays = new ObservableCollection<DayOfWeek>();

        }
        
        public ICommand AddCommand
        {
            get {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand<ChildWpf>(obj =>
                    {
                        if (obj == null) return;
                        obj.PreferableDays = ChosenDays.ToList();
                        List<GroupWpf> groups = _childFacade.AddChild(
                            _fromUiChildMapper.Map(obj))
                            .Select(_toUiGroupMapper.Map)
                            .ToList();
                        if (groups.Count == 1)
                        {
                            Children.Add(NewChild);
                        }
                        else
                        {
                            groups.ForEach(GroupsToChoose.Add);
                        }
                        _prevChild = _newChild;
                        RefreshDays();
                        NewChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
                    }
                    );
                }
                return _addCommand;
            }
        }
        
        public ICommand ChooseGroupCommand
        {
            get
            {
                _chooseGroupCommand ??= new RelayCommand<GroupWpf>(obj =>
                {
                    if (obj == null) return;
                    bool added = _childFacade.AddChildWithChosenGroup(
                        _fromUiChildMapper.Map(_prevChild),
                        _fromUiGroupMapper.Map(obj));
                    if (added) Children.Add(NewChild);
                    _prevChild = _newChild;
                    NewChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
                    GroupsToChoose.Clear();
                });
                return _chooseGroupCommand;
            }
        }

        public ICommand AddDayToListCommand 
        {
            get
            {
                _addDayToListCommand ??= new RelayCommand<DayOfWeek>(obj =>
                {
                    ChosenDays.Add(obj);
                    DaysOfWeek.Remove(obj);
                    ChosenDay = DaysOfWeek.FirstOrDefault();
                }, obj => !ChosenDays.Contains(obj));
                return _addDayToListCommand;
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
        
        public ChildWpf PrevChild
        {
            get => _prevChild;
            set
            {
                _prevChild = value;
                OnPropertyChanged("PrevChild");
            }
        }
        
        public GroupWpf ChosenGroup
        {
            get => _chosenGroup;
            set
            {
                _chosenGroup = value;
                OnPropertyChanged("ChosenGroup");
            }
        }

        public DayOfWeek ChosenDay
        {
            get => _chosenDay;
            set
            {
                _chosenDay = value;
                OnPropertyChanged("ChosenDay");
            }
        }
        
        private bool notEmptyStr(string str)
        {
            return str != String.Empty;
        }

        private void RefreshDays()
        {
            ChosenDays?.ToList().ForEach(DaysOfWeek.Add);
            //ChosenDays?.ToList().ForEach(it => ChosenDays.Remove(it));
            ChosenDays?.Clear();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}