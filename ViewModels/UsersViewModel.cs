using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        public static UsersViewModel Instance { get; private set; }

        public ICommand OpenAddUserCommand { get; }

        public ObservableCollection<User> Users

        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public UsersViewModel(IUserRepository userRepository, IServiceProvider serviceProvider)
        {
            Instance = this;
            _serviceProvider = serviceProvider;
            _userRepository = userRepository;
            Users = new ObservableCollection<User>();
            OpenAddUserCommand = new RelayCommand(ExecuteOpenAddUser, CanExecuteOpenAddUser);
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
                var fetchedUsers = await _userRepository.GetAllUsersAsync();
                Users = new ObservableCollection<User>(fetchedUsers);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An error occurred while fetching users: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      
        private bool CanExecuteOpenAddUser(object parameter)
        {
            return true; 
        }

        private void ExecuteOpenAddUser(object parameter)
        {
 
            var addUserView = _serviceProvider.GetRequiredService<AddUserView>();
             addUserView.Show();
        }
    }
}
