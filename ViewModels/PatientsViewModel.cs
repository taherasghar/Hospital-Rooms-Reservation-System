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
    public class PatientsViewModel : BaseViewModel
    {
        private ObservableCollection<Patient> _patients;
        private readonly IPatientRepository _patientRepository;
        private readonly IServiceProvider _serviceProvider;
        public static PatientsViewModel Instance { get; private set; }

        public ICommand OpenAddPatientCommand { get; }

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public PatientsViewModel(IPatientRepository patientRepository, IServiceProvider serviceProvider)
        {
            Instance = this;
            _serviceProvider = serviceProvider;
            _patientRepository = patientRepository;
            Patients = new ObservableCollection<Patient>();
            OpenAddPatientCommand = new RelayCommand(ExecuteOpenAddPatient, CanExecuteOpenAddPatient);
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
                var fetchedPatients = await _patientRepository.GetAllPatientsAsync();
                Patients = new ObservableCollection<Patient>(fetchedPatients);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"An error occurred while fetching patients: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanExecuteOpenAddPatient(object parameter)
        {
            return true;
        }

        private void ExecuteOpenAddPatient(object parameter)
        {
            var addPatientView = _serviceProvider.GetRequiredService<AddPatientView>();
            addPatientView.Show();
        }
    }
}
