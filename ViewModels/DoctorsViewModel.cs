using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.Models;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class DoctorsViewModel : BaseViewModel
    {
        private ObservableCollection<Doctor> _doctors;
        private readonly IDoctorRepository _doctorRepository;
           
        private readonly IServiceProvider _serviceProvider;
        public static DoctorsViewModel Instance { get; private set; }

        public ICommand OpenAddDoctorCommand { get; }
        public ObservableCollection<Doctor> Doctors
        {
            get => _doctors;
            set
            {
                _doctors = value;
                OnPropertyChanged(nameof(Doctors));
            }
        }

        public DoctorsViewModel(IDoctorRepository doctorRepository, IServiceProvider serviceProvider)
        {
            Instance = this;
            _doctorRepository = doctorRepository;
           
            _serviceProvider = serviceProvider;
            OpenAddDoctorCommand = new RelayCommand(ExecuteOpenAddDoctor, CanExecuteOpenAddDoctor);
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
                var fetchedDoctors = await _doctorRepository.GetAllDoctorsAsync();
                Doctors = new ObservableCollection<Doctor>(fetchedDoctors);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while fetching doctors: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanExecuteOpenAddDoctor(object parameter)
        {
            return true;
        }

        private void ExecuteOpenAddDoctor(object parameter)
        {

            var addDoctorView = _serviceProvider.GetRequiredService<AddDoctorView>();
            addDoctorView.Show();
        }


    }
}
