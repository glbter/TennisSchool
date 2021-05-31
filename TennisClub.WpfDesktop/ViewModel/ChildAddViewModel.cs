using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using GalaSoft.MvvmLight.Command;
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
        private readonly MainViewModel _mainViewModel;

        private ChildWpf _newChild;
        private ChildWpf _prevChild;
        private GroupWpf _chosenGroup;
        private DayOfWeek _chosenDay;
        private DayOfWeek _removedDay;
        private DayOfWeek _successGroupDay;

        private AsyncCommand<ChildWpf> _addChildCommand;
        private AsyncCommand<GroupWpf> _chooseGroupCommand;
        private RelayCommand<DayOfWeek> _addDayToListCommand;
        private RelayCommand<DayOfWeek> _removeDayFromListCommand;
        private RelayCommand _moveForwardToDaysCommand;
        private RelayCommand _returnCommand;
        private RelayCommand _returnToMainMenuCommand;
        
        public ObservableCollection<DayOfWeek> DaysOfWeek { get; }
        public ObservableCollection<GameLevel> GameLevels { get; }
        public ObservableCollection<GroupWpf> GroupsToChoose { get; }
        public ObservableCollection<DayOfWeek> ChosenDays { get; }

        private readonly IChildFacadeAsync _childFacade;
        private readonly IMapper<ChildWpf, Child> _fromUiChildMapper;
        private readonly IMapper<GroupWpf, Group> _fromUiGroupMapper;
        private readonly IMapper<Group, GroupWpf> _toUiGroupMapper;

        public ChildAddViewModel(MainViewModel mainViewModel, IServiceProvider serviceProvider)
        {
            _mainViewModel = mainViewModel;
            _newChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today);
            _childFacade = serviceProvider.GetRequiredService<IChildFacadeAsync>();
            serviceProvider.GetService<UnitOfWork>();
            _fromUiChildMapper = new FromUiChildMapper();
            _fromUiGroupMapper = new FromUiGroupMapper();
            _toUiGroupMapper = new ToUiGroupMapper();
            IMapper<Child, ChildWpf> toUiChildMapper = new ToUiChildMapper();
            
            DaysOfWeek = new ObservableCollection<DayOfWeek>(
                Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>());
            GameLevels = new ObservableCollection<GameLevel>(
                Enum.GetValues(typeof(GameLevel)).OfType<GameLevel>());
            GroupsToChoose = new ObservableCollection<GroupWpf>();
            ChosenDays = new ObservableCollection<DayOfWeek>();
        }


        public AsyncCommand<ChildWpf> AddChildCommand
        {
            get
            {
                _addChildCommand ??= new AsyncCommand<ChildWpf>(AddChild);
                return _addChildCommand;
            }
        }

        public AsyncCommand<GroupWpf> ChooseGroupCommand
        {
            get
            {
                _chooseGroupCommand ??= new AsyncCommand<GroupWpf>(ChooseGroup);
                return _chooseGroupCommand;
            }
        }

        public RelayCommand<DayOfWeek> AddDayToListCommand
        {
            get
            {
                _addDayToListCommand ??= new RelayCommand<DayOfWeek>(AddDayToList);
                return _addDayToListCommand;
            }
        }

        public RelayCommand<DayOfWeek> RemoveDayFromListCommand
        {
            get
            {
                _removeDayFromListCommand ??= new RelayCommand<DayOfWeek>(RemoveDayFromList);
                return _removeDayFromListCommand;
            }
        }
        public RelayCommand MoveForwardToDaysCommand
        {
            get
            {
                _moveForwardToDaysCommand ??= new RelayCommand(MoveForwardToDays);
                return _moveForwardToDaysCommand;
            }
        }

        public RelayCommand ReturnCommand
        {
            get
            {
                _returnCommand ??= new RelayCommand(Return);
                return _returnCommand;
            }
        }

        public RelayCommand ReturnToMainMenuCommand
        {
            get
            {
                _returnToMainMenuCommand ??= new RelayCommand(ReturnToMainMenu);
                return _returnToMainMenuCommand;
            }
        }

        private void MoveForwardToDays()
        {
            _mainViewModel.Navigation.NavigateTo(
                PageType.ChildDaysPage.ToString());
        }

        private void Return()
        {
            _mainViewModel.Navigation.GoBack();
        }

        private void ReturnToMainMenu()
        {
            _mainViewModel.Navigation.NavigateTo(
                PageType.StartPage.ToString());
        }
        private async Task AddChild(ChildWpf child)
        {
            if (child == null) return;
            child.PreferableDays = ChosenDays.ToList();
            List<Group> unmappedGroups = await _childFacade.AddChildAsync(
                _fromUiChildMapper.Map(child));
            List<GroupWpf> groups = unmappedGroups
                .Select(_toUiGroupMapper.Map)
                .ToList();
            
            RefreshDays();
            if (groups.Count == 1)
            {
                NavigateToSuccessPage(groups.First());
                return;
            }

            NavigateToChooseGroupPage(groups);
        }
        
        private async Task ChooseGroup(GroupWpf group)
        {
            if (group == null) return;
            
            bool added = await _childFacade.AddChildWithChosenGroupAsync(
                _fromUiChildMapper.Map(_prevChild),
                _fromUiGroupMapper.Map(group));
            
            if (added) NavigateToSuccessPage(group);
        }
        
        private void AddDayToList(DayOfWeek day)
        {
            ChosenDays.Add(day);
            DaysOfWeek.Remove(day);
            ChosenDay = DaysOfWeek.FirstOrDefault();
        }

        private void RemoveDayFromList(DayOfWeek day)
        {
            ChosenDays.Remove(day);
            DaysOfWeek.Add(day);
            RemovedDay = ChosenDays.FirstOrDefault();
        }

        private void NavigateToSuccessPage(GroupWpf group)
        {
            SuccessGroupDay = group.LessonsDay;
            _mainViewModel.Navigation.NavigateTo(
                PageType.ChildAddSuccessPage.ToString());
            
            ClearChild();
            GroupsToChoose.Clear();
        }

        private void NavigateToChooseGroupPage(List<GroupWpf> groups)
        {
            groups.ForEach(GroupsToChoose.Add);
            _mainViewModel.Navigation.NavigateTo(
                PageType.ChildChooseGroupPage.ToString());
            
            ClearChild();
        }

        private void ClearChild()
        {
            _prevChild = _newChild;
            NewChild = new ChildWpf("", "", GameLevel.Beginner, DayOfWeek.Sunday, DateTime.Today); 
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
        
        public DayOfWeek RemovedDay
        {
            get => _removedDay;
            set
            {
                _removedDay = value;
                RaisePropertyChanged(nameof(RemovedDay));
            }
        }
        
        public DayOfWeek SuccessGroupDay
        {
            get => _successGroupDay;
            set
            {
                _successGroupDay = value;
                RaisePropertyChanged(nameof(SuccessGroupDay));
            }
        }
        
        private void RefreshDays()
        {
            ChosenDays?.ToList().ForEach(DaysOfWeek.Add);
            ChosenDays?.Clear();
        }
    }
}