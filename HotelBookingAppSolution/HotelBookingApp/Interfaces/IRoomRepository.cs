using HotelBookingApp.Models;
using HotelBookingApp.Models.DTOs;
using System.Collections.Generic;

namespace HotelBookingApp.Interfaces
{
    public interface IRoomRepository
    {
        RoomDTO GetRoomById(int roomId);
        List<RoomDTO> GetRoomsByHotelId(int hotelId);
        void CreateRoom(RoomDTO room);
        void UpdateRoom(RoomDTO room);
        void DeleteRoom(int roomId);
    }
}