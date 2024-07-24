using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class CloseReservationViewModel : BaseViewModel
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IServiceProvider _serviceProvider;
        private Guid _reservationId;
        private DateTime _exitDate = DateTime.Now;

        public Guid ReservationId
        {
            get => _reservationId;
            set
            {
                _reservationId = value;
                OnPropertyChanged(nameof(ReservationId));
            }
        }

        public DateTime ExitDate
        {
            get => _exitDate;
            set
            {
                _exitDate = value;
                OnPropertyChanged(nameof(ExitDate));
            }
        }
        public ICommand CloseReservationCommand { get; }

        public CloseReservationViewModel(IReservationRepository reservationRepository,IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _reservationRepository = reservationRepository;
            CloseReservationCommand = new RelayCommand(ExecuteCloseReservation, CanExecuteCloseReservation);
        }

        private bool CanExecuteCloseReservation(object parameter)
        {
            return true;
        }

        private async void ExecuteCloseReservation(object parameter)
        {
            UserSessionService userSessionService = _serviceProvider.GetRequiredService<UserSessionService>();
            try
            {
                var closeReservationDto = new CloseReservationDTO
                {
                    ReservationId = ReservationId,
                    ExitDate = ExitDate,
                    ClosedBy = userSessionService.LoggedInId 
                };

                var result = await _reservationRepository.CloseReservationAsync(closeReservationDto);
                if (result != null)
                {
                    MessageBox.Show("Reservation closed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (parameter is Window window)
                    {
                        await ActiveReservationsViewModel.Instance.LoadDataAsync();
                        window.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to close the reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
