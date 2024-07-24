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
    public class AddDoctorViewModel : BaseViewModel
    {
        private readonly IUserRepository _userRepository;

        private string _newUsername;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _specialization;
        private string _errorMessage;

        public ICommand AddDoctorCommand { get; }

        public string newUsername
        {
            get => _newUsername;
            set
            {
                _newUsername = value;
                OnPropertyChanged(nameof(newUsername));
                ValidateInput();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                ValidateInput();
            }
        }

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

        public string Specialization
        {
            get => _specialization;
            set
            {
                _specialization = value;
                OnPropertyChanged(nameof(Specialization));
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

        public AddDoctorViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            AddDoctorCommand = new RelayCommand(ExecuteAddDoctor, CanExecuteAddDoctor);
        }

        private void ValidateInput()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(_newUsername))
            {
                ErrorMessage = "Username is required.";
            }
            else if (string.IsNullOrWhiteSpace(_password))
            {
                ErrorMessage = "Password is required.";
            }
            else if (string.IsNullOrWhiteSpace(_firstName))
            {
                ErrorMessage = "First Name is required.";
            }
            else if (string.IsNullOrWhiteSpace(_lastName))
            {
                ErrorMessage = "Last Name is required.";
            }
            else if (string.IsNullOrWhiteSpace(_specialization))
            {
                ErrorMessage = "Specialization is required.";
            }
        }

        private bool CanExecuteAddDoctor(object parameter)
        {
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private async void ExecuteAddDoctor(object parameter)
        {
            if (!CanExecuteAddDoctor(parameter))
                return;

            NewUserDTO newDoctor = new NewUserDTO
            {
                Username = _newUsername,
                Password = _password,
                FirstName = _firstName,
                LastName = _lastName,
                Role = UserRole.Doctor,
                Specialization = _specialization
            };

            var result = await _userRepository.CreateNewUserAsync(newDoctor);

            if (result == null)
            {
                MessageBox.Show("An error occurred while adding a new doctor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (parameter is Window window)
                {
                    await DoctorsViewModel.Instance.LoadDataAsync();
                    window.Close();
                }
            }
        }
    }
}
