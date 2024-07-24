using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Hospital.Data.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.ViewModels
{
    public class CreateNewReservationViewModel : BaseViewModel
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IServiceProvider _serviceProvider;

        private IEnumerable<Patient> _availablePatients;
        private IEnumerable<Doctor> _doctors;
        private IEnumerable<Bed> _privateRoomBeds;
        private IEnumerable<Bed> _sharedRoomBeds;
        private IEnumerable<Bed> _availableBeds;
        private Patient _selectedPatient;
        private Doctor _selectedDoctor;
        private Bed _selectedBed;
        private DateTime _entryDate = DateTime.Now;
        private bool _isPrivateRoomSelected;
        private bool _isSharedRoomSelected;

        public ICommand CreateReservationCommand { get; }
        public ICommand RoomTypeChangedCommand { get; }

        public IEnumerable<Patient> AvailablePatients
        {
            get => _availablePatients;
            set
            {
                _availablePatients = value;
                OnPropertyChanged(nameof(AvailablePatients));
            }
        }

        public IEnumerable<Doctor> Doctors
        {
            get => _doctors;
            set
            {
                _doctors = value;
                OnPropertyChanged(nameof(Doctors));
            }
        }

        public IEnumerable<Bed> AvailableBeds
        {
            get => _availableBeds;
            set
            {
                _availableBeds = value;
                OnPropertyChanged(nameof(AvailableBeds));
            }
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }

        public Bed SelectedBed
        {
            get => _selectedBed;
            set
            {
                _selectedBed = value;
                OnPropertyChanged(nameof(SelectedBed));
            }
        }

        public DateTime EntryDate
        {
            get => _entryDate;
            set
            {
                _entryDate = value;
                OnPropertyChanged(nameof(EntryDate));
            }
        }

        public bool IsPrivateRoomSelected
        {
            get => _isPrivateRoomSelected;
            set
            {
                _isPrivateRoomSelected = value;
                OnPropertyChanged(nameof(IsPrivateRoomSelected));
                UpdateAvailableBeds(null);
            }
        }

        public bool IsSharedRoomSelected
        {
            get => _isSharedRoomSelected;
            set
            {
                _isSharedRoomSelected = value;
                OnPropertyChanged(nameof(IsSharedRoomSelected));
                UpdateAvailableBeds(null);
            }
        }

        public CreateNewReservationViewModel(
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IReservationRepository reservationRepository,
            IRoomRepository roomRepository,
            IServiceProvider serviceProvider
             )
        {
            _serviceProvider= serviceProvider;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;

            CreateReservationCommand = new RelayCommand(ExecuteCreateReservation, CanExecuteCreateReservation);
            RoomTypeChangedCommand = new RelayCommand(UpdateAvailableBeds, CanExecuteUpdateAvailableBeds);

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
   
            AvailablePatients = await _patientRepository.GetPatientsWithNoActiveReservationsAsync();
            Doctors = await _doctorRepository.GetAllDoctorsAsync();

            _privateRoomBeds = await _roomRepository.GetPrivateRoomsWithUnoccupiedBedsAsync();
            _sharedRoomBeds = await _roomRepository.GetSharedRoomsWithUnoccupiedBedsAsync();

            UpdateAvailableBeds(null);
        }

        private bool CanExecuteUpdateAvailableBeds(object parameter)
        {
            return true;
        }
        private void UpdateAvailableBeds(object parameter)
        {
            if (IsPrivateRoomSelected)
            {
                AvailableBeds = _privateRoomBeds;
            }
            else if (IsSharedRoomSelected)
            {
                AvailableBeds = _sharedRoomBeds;
            }
            else
            {
                AvailableBeds = Enumerable.Empty<Bed>();
            }
        }

        private bool CanExecuteCreateReservation(object parameter)
        {
            return true;
          
        }

        private async void ExecuteCreateReservation(object parameter)
        {
            UserSessionService userSessionService = _serviceProvider.GetRequiredService<UserSessionService>();

            var reservationDto = new newReservationDTO
            {

                ReservedBy = userSessionService.LoggedInId,
                PatientId = SelectedPatient.Id,
                DoctorId = SelectedDoctor.Id,
                BedId = SelectedBed.Id,
                EntryDate = EntryDate
            };

            var result = await _reservationRepository.CreateNewReservationAsync(reservationDto);

            if (result == null)
            {
                MessageBox.Show("An error occurred while creating the reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Reservation created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Close the view or clear the form as needed
                if (parameter is Window window)
                {
                    await ActiveReservationsViewModel.Instance.LoadDataAsync();
                    window.Close();
                }
            }
        }
    }
}
