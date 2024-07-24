using Hospital.DTOs;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repository.IRepository
{
    public interface IRoomRepository
    {
        Task<Room> CreateNewRoomAsync(NewRoomDTO newRoom);
        Task<IEnumerable<Bed>> GetSharedRoomsWithUnoccupiedBedsAsync();
        Task<IEnumerable<Bed>> GetPrivateRoomsWithUnoccupiedBedsAsync();
        Task<IEnumerable<RoomWithBedsDTO>> GetPrivateRoomsAsync();
        Task<IEnumerable<RoomWithBedsDTO>> GetSharedRoomsAsync();
    }
}
