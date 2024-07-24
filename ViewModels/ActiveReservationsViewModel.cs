using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.Models;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class ActiveReservationsViewModel : BaseViewModel
    {
        private ObservableCollection<Reservation> _reservations;
        private readonly IReservationRepository _reservationRepository;
        private readonly IServiceProvider _serviceProvider;
        public ICommand OpenCreateNewReservationCommand { get; }
        public ICommand OpenCloseReservationCommand { get; }
        public static ActiveReservationsViewModel Instance { get; private set; }
        public ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public ActiveReservationsViewModel(IReservationRepository reservationRepository, IServiceProvider serviceProvider)
        {
            Instance = this;
            _serviceProvider = serviceProvider;
            _reservationRepository = reservationRepository;
            Reservations = new ObservableCollection<Reservation>();
            OpenCreateNewReservationCommand = new RelayCommand(ExecuteOpenCreateNewReservation, CanExecuteOpenCreateNewReservation);
            OpenCloseReservationCommand = new RelayCommand(ExecuteCloseReservation, CanExecuteOpenCloseReservation);
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            try
            {
                var fetchedReservations = await _reservationRepository.GetAllActiveReservationsAsync();
                Reservations = new ObservableCollection<Reservation>(fetchedReservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching active reservations: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanExecuteOpenCreateNewReservation(object parameter)
        {
            return true;
        }

        private void ExecuteOpenCreateNewReservation(object parameter)
        {

            var createNewReservationView = _serviceProvider.GetRequiredService<CreateNewReservationView>();
            createNewReservationView.Show();
        }
        private bool CanExecuteOpenCloseReservation(object parameter)
        {
            return true;
        }

        private void ExecuteCloseReservation(object parameter)
        {
            if (parameter is Guid reservationId)
            {
                var closeReservationWindow = _serviceProvider.GetRequiredService<CloseReservationView>();
                var closeReservationViewModel = (CloseReservationViewModel)closeReservationWindow.DataContext;
                closeReservationViewModel.ReservationId = reservationId;
                closeReservationWindow.Show();
            }
        }
    }
}
