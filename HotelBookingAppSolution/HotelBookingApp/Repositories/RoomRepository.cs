using HotelBookingApp.Contexts;
using HotelBookingApp.Interfaces;
using HotelBookingApp.Models.DTOs;
using HotelBookingApp.Models;
using HotelBookingApp.Contexts;
using HotelBookingApp.Interfaces;
using HotelBookingApp.Models;
using HotelBookingApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApp.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public RoomDTO GetRoomById(int roomId)
        {
            var room = _context.Rooms.SingleOrDefault(u => u.RoomId == roomId);

            if (room == null)
            {
                return null; // or throw an exception, depending on your requirements
            }

            // Map Room to RoomDTO
            return new RoomDTO
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                // Add other properties as needed
                HotelId = room.HotelId
            };
        }

        public List<RoomDTO> GetRoomsByHotelId(int hotelId)
        {
            var rooms = _context.Rooms.Where(r => r.HotelId == hotelId).ToList();

            // Map List<Room> to List<RoomDTO>
            return rooms.Select(room => new RoomDTO
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                // Add other properties as needed
                HotelId = room.HotelId
            }).ToList();
        }

        public void CreateRoom(RoomDTO room)
        {
            var newRoom = new Room
            {
                RoomNumber = room.RoomNumber,
                // Set other properties as needed
                HotelId = room.HotelId
            };

            _context.Rooms.Add(newRoom);
            _context.SaveChanges();
        }

        public void UpdateRoom(RoomDTO room)
        {
            var existingRoom = _context.Rooms.SingleOrDefault(u => u.RoomId == room.RoomId);

            if (existingRoom != null)
            {
                // Update properties as needed
                existingRoom.RoomNumber = room.RoomNumber;

                _context.Entry(existingRoom).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteRoom(int roomId)
        {
            var roomToDelete = _context.Rooms.SingleOrDefault(u => u.RoomId == roomId);

            if (roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                _context.SaveChanges();
            }
        }
    }
}
