using HotelBookingApp.Models;
using HotelBookingApp.Models.DTOs;

namespace HotelBookingApp.Interfaces
{

    public interface IHotelRepository
    {
        HotelDTO GetHotelById(int hotelId);
        List<HotelDTO> GetAllHotels();
        void CreateHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int hotelId);

        int GetAllRoomCount(int hotelId);
        // Add more repository methods as needed
    }
}
