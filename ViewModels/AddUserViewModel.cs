using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Hospital.Models;
using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Hospital.ViewModels
{
    public class AddUserViewModel : BaseViewModel
    {
        private readonly IUserRepository _userRepository;

        private string _newUsername;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _errorMessage;
        private bool _isAdminChecked;
        private bool _isRegistrarChecked;

        public ICommand AddUserCommand { get; }

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

        public bool IsAdminChecked
        {
            get => _isAdminChecked;
            set
            {
                _isAdminChecked = value;
                OnPropertyChanged(nameof(IsAdminChecked));
                ValidateInput();
            }
        }

        public bool IsRegistrarChecked
        {
            get => _isRegistrarChecked;
            set
            {
                _isRegistrarChecked = value;
                OnPropertyChanged(nameof(IsRegistrarChecked));
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

        public AddUserViewModel(IUserRepository userRepository)
        {
            AddUserCommand = new RelayCommand(ExecuteAddUser, CanExecuteAddUser);
            _userRepository = userRepository;

            
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
            else if (!_isAdminChecked && !_isRegistrarChecked)
            {
                ErrorMessage = "Role is required.";
            }
        }

        private bool CanExecuteAddUser(object parameter)
        {
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private async void ExecuteAddUser(object parameter)
        {
            if (!CanExecuteAddUser(parameter))
                return;

            NewUserDTO newUser = new NewUserDTO
            {
                Username = _newUsername,
                Password = _password,
                FirstName = _firstName,
                LastName = _lastName,
                Role = _isAdminChecked ? UserRole.Admin : UserRole.Registrar,
            };

            if (_isRegistrarChecked)
            {
                newUser.Role = UserRole.Registrar;
            }

            var result = await _userRepository.CreateNewUserAsync(newUser);
            
            if(result == null)
            {
                MessageBox.Show($"An error occurred while adding a new user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (parameter is Window window)
                {
                    UsersViewModel.Instance.Users.Add(result);
                    window.Close();
                }
            }

        }
    }
}
