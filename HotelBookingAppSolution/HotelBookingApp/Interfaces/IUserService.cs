using HotelBookingApp.Models.DTOs;

namespace HotelBookingApp.Interfaces
{


    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}
