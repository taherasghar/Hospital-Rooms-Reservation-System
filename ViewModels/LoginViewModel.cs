using System;
using System.Windows;
using System.Windows.Input;
using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;


        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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

        public ICommand LoginCommand { get; }

        public LoginViewModel(IUserRepository userRepository, IServiceProvider serviceProvider)
        {
            _userRepository = userRepository;
            LoginCommand = new RelayCommand(Login, CanLogin);
            _serviceProvider = serviceProvider;
        }

        private bool CanLogin(object parameter)
        {
            return true;
        }

        private async void Login(object parameter)
        {
               UserDTO user = await _userRepository.AuthenticateUserAsync(Username, Password);

            if (user != null)
            {
                UserSessionService userSession = _serviceProvider.GetRequiredService<UserSessionService>();
                userSession.LoggedInId = user.Id;
                userSession.LoggedInUsername = user.Username;
                userSession.LoggedInRole = user.Role;
                userSession.FirstName = user.FirstName;
                userSession.LastName = user.LastName;


                switch (user.Role)
                {
                    case UserRole.Admin:
                        var adminViewModel = _serviceProvider.GetRequiredService<AdminMainViewModel>();
                        var adminWindow = _serviceProvider.GetRequiredService<AdminMain>();
                        adminWindow.DataContext = adminViewModel;
                        adminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        adminWindow.WindowState = WindowState.Maximized;
                        adminWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                        Application.Current.MainWindow.Close();
                        Application.Current.MainWindow = adminWindow;
                        adminWindow.Show();
                        break;
                   
                    case UserRole.Registrar:
                        var registrarViewModel = _serviceProvider.GetRequiredService<RegistrarMainViewModel>();
                        var registrarWindow = _serviceProvider.GetRequiredService<RegistrarMain>();
                        registrarWindow.DataContext = registrarViewModel;
                        registrarWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        registrarWindow.WindowState = WindowState.Maximized;
                        registrarWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                        Application.Current.MainWindow.Close();
                        Application.Current.MainWindow = registrarWindow;
                        registrarWindow.Show();
                        break;

                    case UserRole.Doctor:
                        var doctorViewModel = _serviceProvider.GetRequiredService<DoctorMainViewModel>();
                        var doctorWindow = _serviceProvider.GetRequiredService<DoctorMain>();
                        doctorWindow.DataContext = doctorViewModel;
                        doctorWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        doctorWindow.WindowState = WindowState.Maximized;
                        doctorWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                        Application.Current.MainWindow.Close();
                        Application.Current.MainWindow = doctorWindow;
                        doctorWindow.Show();
                        break;
                }
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
           
           
        }
    }
}
