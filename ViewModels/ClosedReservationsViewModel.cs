using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class ClosedReservationsViewModel : BaseViewModel
    {
        private ObservableCollection<Reservation> _reservations;
        private readonly IReservationRepository _reservationRepository;
        private readonly IServiceProvider _serviceProvider;

        public ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public ClosedReservationsViewModel(IReservationRepository reservationRepository, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _reservationRepository = reservationRepository;
            Reservations = new ObservableCollection<Reservation>();
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
                var fetchedReservations = await _reservationRepository.GetAllClosedReservationsAsync();
                Reservations = new ObservableCollection<Reservation>(fetchedReservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching closed reservations: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
