using HotelBookingApp.Models.DTOs;

namespace HotelBookingApp.Interfaces
{



    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}