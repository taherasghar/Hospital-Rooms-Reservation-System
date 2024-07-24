using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.ViewModels
{
    public class AddRoomViewModel : BaseViewModel
    {
        private readonly IRoomRepository _roomRepository;
        private string _number;
        private string _floor;
        private string _capacity;
        private bool _isPrivateChecked;
        private bool _isSharedChecked;
        private string _errorMessage;

        public ICommand AddRoomCommand { get; }

        public string Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
                ValidateInput();
            }
        }

        public string Floor
        {
            get => _floor;
            set
            {
                _floor = value;
                OnPropertyChanged(nameof(Floor));
                ValidateInput();
            }
        }

        public string Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                OnPropertyChanged(nameof(Capacity));
                ValidateInput();
            }
        }

        public bool IsPrivateChecked
        {
            get => _isPrivateChecked;
            set
            {
                _isPrivateChecked = value;
                OnPropertyChanged(nameof(IsPrivateChecked));
                ValidateInput();
            }
        }

        public bool IsSharedChecked
        {
            get => _isSharedChecked;
            set
            {
                _isSharedChecked = value;
                OnPropertyChanged(nameof(IsSharedChecked));
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

        public AddRoomViewModel(IRoomRepository roomRepository)
        {
            AddRoomCommand = new RelayCommand(ExecuteAddRoom, CanExecuteAddRoom);
            _roomRepository = roomRepository;
        }

        private void ValidateInput()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(_number))
            {
                ErrorMessage = "Room Number is required.";
            }
            else if (string.IsNullOrWhiteSpace(_floor))
            {
                ErrorMessage = "Floor is required.";
            }
            else if (!IsPrivateChecked && !IsSharedChecked)
            {
                ErrorMessage = "Room Type is required.";
            }
            else if (string.IsNullOrWhiteSpace(Capacity))
            {
                ErrorMessage = "Capacity must be 1 for private rooms and at least 2 for shared rooms";
            }
           
        }

        private bool CanExecuteAddRoom(object parameter)
        {
            return true;
        }

        private async void ExecuteAddRoom(object parameter)
        {
           

            RoomType roomType = IsPrivateChecked ? RoomType.Private : RoomType.Shared;

            NewRoomDTO newRoom = new NewRoomDTO
            {
                Number = int.Parse(_number),
                Floor = int.Parse(_floor),
                Capacity = int.Parse(_capacity),
                Type = roomType
            };

            var result = await _roomRepository.CreateNewRoomAsync(newRoom);

            if (result == null)
            {
                MessageBox.Show($"An error occurred while adding a new room", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (parameter is Window window)
                {
                    // Notify other views if needed and close the window
                    await RoomsViewModel.Instance.LoadDataAsync();
                    window.Close();
                }
            }
        }
    }
}
