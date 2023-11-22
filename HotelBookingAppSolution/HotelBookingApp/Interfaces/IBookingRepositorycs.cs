using HotelBookingApp.Models;
using HotelBookingApp.Models;
using System.Collections.Generic;

namespace HotelBookingApp.Interfaces
{
    public interface IBookingRepository
    {
        Booking GetBookingById(int bookingId);
        List<Booking> GetBookingsByUserId(string userId);
        void CreateBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int bookingId);
    }
}
