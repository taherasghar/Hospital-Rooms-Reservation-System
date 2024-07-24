using Hospital.Commands;
using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class RoomsViewModel : BaseViewModel
    {
        private readonly IRoomRepository _roomRepository;
        private ObservableCollection<RoomWithBedsViewModel> _privateRooms;
        private ObservableCollection<RoomWithBedsViewModel> _sharedRooms;
        private readonly IServiceProvider _serviceProvider;
        public static RoomsViewModel Instance { get; private set; }
        public ICommand OpenAddNewRoomCommand { get; }
        public ObservableCollection<RoomWithBedsViewModel> PrivateRooms
        {
            get => _privateRooms;
            set
            {
                _privateRooms = value;
                OnPropertyChanged(nameof(PrivateRooms));
            }
        }

        public ObservableCollection<RoomWithBedsViewModel> SharedRooms
        {
            get => _sharedRooms;
            set
            {
                _sharedRooms = value;
                OnPropertyChanged(nameof(SharedRooms));
            }
        }

        

 

        public RoomsViewModel(IRoomRepository roomRepository, IServiceProvider serviceProvider)
        {
             Instance = this; 
            _serviceProvider = serviceProvider;
            _roomRepository = roomRepository;
            PrivateRooms = new ObservableCollection<RoomWithBedsViewModel>();
            SharedRooms = new ObservableCollection<RoomWithBedsViewModel>();
            OpenAddNewRoomCommand = new RelayCommand(ExecuteOpenAddNewRoom, CanExecuteOpenAddNewRoom);

            InitializeAsync();
           
        }

        private async void InitializeAsync()
        {
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
           
            var privateRooms = await _roomRepository.GetPrivateRoomsAsync();
            var sharedRooms = await _roomRepository.GetSharedRoomsAsync();

            PrivateRooms.Clear();
            foreach (var room in privateRooms)
            {
                var bedStatus = room.Beds.Any() ? (room.Beds.First().IsOccupied ? "Occupied" : "Unoccupied") : "Unknown";
                var background = room.Beds.Any() ? (room.Beds.First().IsOccupied ? "Red" : "Green") : "Gray";

                PrivateRooms.Add(new RoomWithBedsViewModel
                {
                    Room = room.Room,
                    BedStatus = bedStatus,
                    StatusBackground = background
                });
            }

            SharedRooms.Clear();
            foreach (var room in sharedRooms)
            {
                var beds = room.Beds.Select(b => new BedViewModel
                {
                    Label = b.Label,
                    Status = b.IsOccupied ? "Occupied" : "Unoccupied",
                    StatusBackground = b.IsOccupied ? "Red" : "Green"
                }).ToList();

                SharedRooms.Add(new RoomWithBedsViewModel
                {
                    Room = room.Room,
                    Beds = beds
                });
            }
        }
        private bool CanExecuteOpenAddNewRoom(object parameter)
        {
            return true;
        }

        private void ExecuteOpenAddNewRoom(object parameter)
        {

            var addRoomView = _serviceProvider.GetRequiredService<AddRoomView>();
            addRoomView.Show();
        }

    }

    public class RoomWithBedsViewModel
    {
        public Room Room { get; set; }
        public List<BedViewModel> Beds { get; set; }
        public string BedStatus { get; set; }
        public string StatusBackground { get; set; }
    }

    public class BedViewModel
    {
        public string Label { get; set; }
        public string Status { get; set; }
        public string StatusBackground { get; set; }
    }
}
