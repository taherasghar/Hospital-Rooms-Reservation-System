using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Hospital.Models;
using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Hospital.Data.Repository.IRepository;

namespace Hospital.ViewModels
{
    public class AddPatientViewModel : BaseViewModel
    {
        private readonly IPatientRepository _patientRepository;

        private string _firstName;
        private string _lastName;
        private DateTime? _dateOfBirth;
        private string _errorMessage;
        private bool _isMaleChecked;
        private bool _isFemaleChecked;

        public ICommand AddPatientCommand { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                ValidateInput();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                ValidateInput();
            }
        }

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
                ValidateInput();
            }
        }

        public bool IsMaleChecked
        {
            get => _isMaleChecked;
            set
            {
                _isMaleChecked = value;
                OnPropertyChanged(nameof(IsMaleChecked));
                ValidateInput();
            }
        }

        public bool IsFemaleChecked
        {
            get => _isFemaleChecked;
            set
            {
                _isFemaleChecked = value;
                OnPropertyChanged(nameof(IsFemaleChecked));
                ValidateInput();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public AddPatientViewModel(IPatientRepository patientRepository)
        {
            AddPatientCommand = new RelayCommand(ExecuteAddPatient, CanExecuteAddPatient);
            _patientRepository = patientRepository;
        }

        private void ValidateInput()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(_firstName))
            {
                ErrorMessage = "First Name is required.";
            }
            else if (string.IsNullOrWhiteSpace(_lastName))
            {
                ErrorMessage = "Last Name is required.";
            }
            else if (!_dateOfBirth.HasValue)
            {
                ErrorMessage = "Date of Birth is required.";
            }
            else if (!_isMaleChecked && !_isFemaleChecked)
            {
                ErrorMessage = "Gender is required.";
            }
        }

        private bool CanExecuteAddPatient(object parameter)
        {
            return true;
        }

        private async void ExecuteAddPatient(object parameter)
        {
        
            NewPatientDTO newPatient = new NewPatientDTO
            {
                FirstName = _firstName,
                LastName = _lastName,
                DateOfBirth = _dateOfBirth.Value,
                Gender = _isMaleChecked ? "Male" : "Female",
            };

            var result = await _patientRepository.CreateNewPatientAsync(newPatient);

            if (result == null)
            {
                MessageBox.Show($"An error occurred while adding a new patient", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (parameter is Window window)
                {
                    await PatientsViewModel.Instance.LoadDataAsync();
                    window.Close();
                }
            }
        }
    }
}
