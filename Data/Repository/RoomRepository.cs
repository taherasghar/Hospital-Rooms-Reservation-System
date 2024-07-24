using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Data.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _db;

        public RoomRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Room> CreateNewRoomAsync(NewRoomDTO newRoom)
        {
            bool roomExists = await _db.Rooms
               .AnyAsync(r => r.Number == newRoom.Number);

            if (roomExists)
            {
                return null;
            }

            Room room = new Room
            {
                Id = Guid.NewGuid(),
                Number = newRoom.Number,
                Floor = newRoom.Floor,
                Type = newRoom.Type,
                Capacity = newRoom.Type == RoomType.Private ? 1 : newRoom.Capacity
            };

            await _db.Rooms.AddAsync(room);
            if (room.Type == RoomType.Private)
            {
                Bed privateBed = new Bed
                {
                    Id = Guid.NewGuid(),
                    Label = "A",
                    IsOccupied = false,
                    RoomId = room.Id
                };

                await _db.Beds.AddAsync(privateBed);
            }
            else if (room.Type == RoomType.Shared)
            {
                if (newRoom.Capacity < 2 || newRoom.Capacity > 12)
                {
                    throw new ArgumentException("Shared rooms must have a capacity between 2 and 12.");
                }
                for (int i = 0; i < newRoom.Capacity; i++)
                {
                    char bedLabel = (char)('A' + i); 
                    Bed sharedBed = new Bed
                    {
                        Id = Guid.NewGuid(),
                        Label = bedLabel.ToString(),
                        IsOccupied = false,
                        RoomId = room.Id
                    };

                    await _db.Beds.AddAsync(sharedBed);
                }
            }
            await _db.SaveChangesAsync();
            return room;
        }

        public async Task<IEnumerable<Bed>> GetPrivateRoomsWithUnoccupiedBedsAsync()
        {
            var unoccupiedBeds = await _db.Beds
                .Include(b => b.Room)
                .Where(b => !b.IsOccupied && b.Room.Type == RoomType.Private)
                .OrderBy(b => b.Room.Floor) 
                .ThenBy(b => b.Room.Number) 
                .ToListAsync();

            return unoccupiedBeds;
        }

        public async Task<IEnumerable<Bed>> GetSharedRoomsWithUnoccupiedBedsAsync()
        {
            var unoccupiedBeds = await _db.Beds
                .Include(b => b.Room)
                .Where(b => !b.IsOccupied && b.Room.Type == RoomType.Shared)
                .OrderBy(b => b.Room.Floor)
                .ThenBy(b => b.Room.Number)
                .ToListAsync();

            return unoccupiedBeds;
        }



        public async Task<IEnumerable<RoomWithBedsDTO>> GetPrivateRoomsAsync()
        {
            
            var rooms = await _db.Rooms
                .Where(r => r.Type == RoomType.Private)
                .OrderBy(r => r.Floor)
                .ThenBy(r => r.Number)
                .ToListAsync();

            var beds = await _db.Beds
                .Where(b => rooms.Select(r => r.Id).Contains(b.RoomId))
                .OrderBy(b => b.Label)
                .ToListAsync();

            return rooms.Select(r => new RoomWithBedsDTO
            {
                Room = r,
                Beds = beds.Where(b => b.RoomId == r.Id).ToList()
            });
        }

        public async Task<IEnumerable<RoomWithBedsDTO>> GetSharedRoomsAsync()
        {
           
            var rooms = await _db.Rooms
                .Where(r => r.Type == RoomType.Shared)
                .OrderBy(r => r.Floor)
                .ThenBy(r => r.Number)
                .ToListAsync();

            var beds = await _db.Beds
                .Where(b => rooms.Select(r => r.Id).Contains(b.RoomId))
                .OrderBy(b => b.Label)
                .ToListAsync();

            return rooms.Select(r => new RoomWithBedsDTO
            {
                Room = r,
                Beds = beds.Where(b => b.RoomId == r.Id).ToList()
            });
        }
    }
}
