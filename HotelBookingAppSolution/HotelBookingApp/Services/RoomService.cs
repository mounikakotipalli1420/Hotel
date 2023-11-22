using HotelBookingApp.Interfaces;
using HotelBookingApp.Models.DTOs;
using HotelBookingApp.Interfaces;
using HotelBookingApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        public RoomDTO GetRoomById(int roomId)
        {
            return _roomRepository.GetRoomById(roomId);
        }

        public List<RoomDTO> GetRoomsByHotelId(int hotelId)
        {
            return _roomRepository.GetRoomsByHotelId(hotelId);
        }

        public void CreateRoom(RoomDTO room)
        {
            _roomRepository.CreateRoom(room);
        }

        public void UpdateRoom(RoomDTO room)
        {
            _roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(int roomId)
        {
            _roomRepository.DeleteRoom(roomId);
        }
    }
}