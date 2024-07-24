using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hospital.ViewModels
{
    public class AdminMainViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        private object _currentView;
        private string _firstName;
        private string _lastName;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }


        public ICommand ShowUsersViewCommand { get; }
        public ICommand ShowDoctorsViewCommand { get; set; }
        public ICommand ShowRoomsViewCommand { get; set; }
        public ICommand ShowPatientsViewCommand { get; set; }
        public ICommand ShowActiveReservationsViewCommand { get; set; }
        public ICommand ShowClosedReservationsViewCommand { get; set; }


        public AdminMainViewModel( IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            UserSessionService userSession = _serviceProvider.GetRequiredService<UserSessionService>();
            _firstName = userSession.FirstName;
            _lastName = userSession.LastName;
            ShowUsersViewCommand = new RelayCommand(ExecuteShowUsersView, CanExecuteShowUsersView);
            ShowDoctorsViewCommand = new RelayCommand(ExecuteShowDoctorsView, CanExecuteShowDoctorsView);
            ShowRoomsViewCommand = new RelayCommand(ExecuteShowRoomsView, CanExecuteShowRoomsView);
            ShowPatientsViewCommand = new RelayCommand(ExecuteShowPatientsView, CanExecuteShowPatientsView);
            ShowActiveReservationsViewCommand = new RelayCommand(ExecuteShowActiveReservationsView, CanExecuteShowActiveReservationsView);
            ShowClosedReservationsViewCommand = new RelayCommand(ExecuteShowClosedReservationsView, CanExecuteShowClosedReservationsView);
            // Load UsersView by default
            ExecuteShowUsersView(null);
        }

        private bool CanExecuteShowUsersView(object parameter)
        {
            return true;
        }

        private void ExecuteShowUsersView(object parameter)
        {
                 CurrentView = _serviceProvider.GetRequiredService<UsersView>();
        }
        private bool CanExecuteShowDoctorsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowDoctorsView(object parameter)
        {
            CurrentView = _serviceProvider.GetRequiredService<DoctorsView>();
        }
         private bool CanExecuteShowRoomsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowRoomsView(object parameter)
        {

             CurrentView = _serviceProvider.GetRequiredService<RoomsView>();
        }
        private bool CanExecuteShowPatientsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowPatientsView(object parameter)
        {

            CurrentView = _serviceProvider.GetRequiredService<PatientsView>();
        }
        private bool CanExecuteShowActiveReservationsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowActiveReservationsView(object parameter)
        {

            CurrentView = _serviceProvider.GetRequiredService<ActiveReservationsView>();
        }
        private bool CanExecuteShowClosedReservationsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowClosedReservationsView(object parameter)
        {

            CurrentView = _serviceProvider.GetRequiredService<ClosedReservationsView>();
        }

    }
}
