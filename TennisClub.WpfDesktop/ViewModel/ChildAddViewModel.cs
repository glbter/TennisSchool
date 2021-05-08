using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Repository;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Mappers;
using TennisClub.WpfDesktop.Mapppers;
using TennisClub.WpfDesktop.Model;

namespace TennisClub.WpfDesktop.ViewModel
{
    public class ChildAddViewModel : BaseViewModel
    {
        private MainViewModel _mainViewModel;
        
        private ChildWpf _newChild;
        private ChildWpf _prevChild;
        private GroupWpf _chosenGroup;
        private DayOfWeek _chosenDay;

        private GalaSoft.MvvmLight.Command.RelayCommand<ChildWpf> _addChildCommand;
        private GalaSoft.MvvmLight.Command.RelayCommand<GroupWpf> _chooseGroupCommand;
        private GalaSoft.MvvmLight.Command.RelayCommand<DayOfWeek> _addDayToListCommand;
        
        public ObservableCollection<ChildWpf> Children { get; }
        public ObservableCollection<DayOfWeek> DaysOfWeek { get; }
        public ObservableCollection<GameLevel> GameLevels { get; }
        public ObservableCollection<GroupWpf> GroupsToChoose { get; }
        public ObservableCollection<DayOfWeek> ChosenDays { get; }

        private readonly IChildFacade _childFacade;
        private readonly IMapper<ChildWpf, Child> _fromUiChildMapper;
        private readonly IMapper<GroupWpf, Group> _fromUiGroupMapper;
        private readonly IMapper<Group, GroupWpf> _toUiGroupMapper;

        public ChildAddViewModel(MainViewModel mainViewModel, IServiceProvider serviceProvider)
        {
            _mainViewModel = mainViewModel;
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

        
        public GalaSoft.MvvmLight.Command.RelayCommand<ChildWpf> AddChildCommand
        {
            get{
                _addChildCommand ??= new GalaSoft.MvvmLight.Command.RelayCommand<ChildWpf>(AddChild);
                return _addChildCommand;
            }
        }
        
        public GalaSoft.MvvmLight.Command.RelayCommand<GroupWpf> ChooseGroupCommand
        {
            get{
                _chooseGroupCommand ??= new GalaSoft.MvvmLight.Command.RelayCommand<GroupWpf>(ChooseGroup);
                return _chooseGroupCommand;
            }
        }

        public GalaSoft.MvvmLight.Command.RelayCommand<DayOfWeek> AddDayToListCommand 
        {
            get{
                _addDayToListCommand ??= new GalaSoft.MvvmLight.Command.RelayCommand<DayOfWeek>(AddDayToList);
                return _addDayToListCommand;
            }
        }
        

        private void AddChild(ChildWpf child)
        {
            if (child == null) return;
            child.PreferableDays = ChosenDays.ToList();
            List<GroupWpf> groups = _childFacade.AddChild(
                    _fromUiChildMapper.Map(child))
                .Select(_toUiGroupMapper.Map)
                .ToList();
            if (groups.Count == 1)
                Children.Add(NewChild);
            else
                groups.ForEach(GroupsToChoose.Add);
            
            _prevChild = _newChild;
            RefreshDays();
            NewChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
        }
        
        private void ChooseGroup(GroupWpf group)
        {
            if (group == null) return;
            bool added = _childFacade.AddChildWithChosenGroup(
                _fromUiChildMapper.Map(_prevChild),
                _fromUiGroupMapper.Map(group));
            
            if (added) Children.Add(NewChild);
            _prevChild = _newChild;
            NewChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
            GroupsToChoose.Clear();
        }
        
        private void AddDayToList(DayOfWeek day)
        {
            ChosenDays.Add(day);
            DaysOfWeek.Remove(day);
            ChosenDay = DaysOfWeek.FirstOrDefault();
        }
        
        public ChildWpf NewChild
        {
            get => _newChild;
            set
            {
                _newChild = value;
                RaisePropertyChanged(nameof(NewChild));
            }
        }
        
        public ChildWpf PrevChild
        {
            get => _prevChild;
            set
            {
                _prevChild = value;
                RaisePropertyChanged(nameof(PrevChild));
            }
        }
        
        public GroupWpf ChosenGroup
        {
            get => _chosenGroup;
            set
            {
                _chosenGroup = value;
                RaisePropertyChanged(nameof(ChosenGroup));
            }
        }

        public DayOfWeek ChosenDay
        {
            get => _chosenDay;
            set
            {
                _chosenDay = value;
                RaisePropertyChanged(nameof(ChosenDay));
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
    }
}