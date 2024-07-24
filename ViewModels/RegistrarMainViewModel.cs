using Hospital.Commands;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class RegistrarMainViewModel : BaseViewModel
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

        public ICommand ShowPatientsViewCommand { get; set; }
        public ICommand ShowActiveReservationsViewCommand { get; set; }
        public ICommand ShowClosedReservationsViewCommand { get; set; }
        public ICommand ShowRoomsViewCommand { get; set; }
        public RegistrarMainViewModel(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            UserSessionService userSession = _serviceProvider.GetRequiredService<UserSessionService>();
            _firstName = userSession.FirstName;
            _lastName = userSession.LastName;
            ShowPatientsViewCommand = new RelayCommand(ExecuteShowPatientsView, CanExecuteShowPatientsView);
            ShowRoomsViewCommand = new RelayCommand(ExecuteShowRoomsView, CanExecuteShowRoomsView);
            ShowActiveReservationsViewCommand = new RelayCommand(ExecuteShowActiveReservationsView, CanExecuteShowActiveReservationsView);
            ShowClosedReservationsViewCommand = new RelayCommand(ExecuteShowClosedReservationsView, CanExecuteShowClosedReservationsView);
            ExecuteShowPatientsView(null);
        }
        private bool CanExecuteShowPatientsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowPatientsView(object parameter)
        {

            CurrentView = _serviceProvider.GetRequiredService<PatientsView>();
        }
        private bool CanExecuteShowRoomsView(object parameter)
        {
            return true;
        }

        private void ExecuteShowRoomsView(object parameter)
        {

            CurrentView = _serviceProvider.GetRequiredService<RegistrarRoomsView>();
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
