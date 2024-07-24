using Hospital.Data.Repository.IRepository;
using Hospital.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.ViewModels
{
    public class DoctorPatientsReservationsViewModel : BaseViewModel
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

        public DoctorPatientsReservationsViewModel(IReservationRepository reservationRepository, IServiceProvider serviceProvider)
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
                UserSessionService userSessionService = _serviceProvider.GetService<UserSessionService>();

                var fetchedReservations = await _reservationRepository.GetAllReservationsByDoctorIdAsync(userSessionService.LoggedInId);
                Reservations = new ObservableCollection<Reservation>(fetchedReservations);
            }
            catch (Exception ex)
            {
                // Handle exceptions that occur during data fetching
               // MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
