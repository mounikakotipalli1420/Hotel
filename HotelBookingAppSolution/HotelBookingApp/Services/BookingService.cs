using HotelBookingApp.Interfaces;
using HotelBookingApp.Models;
using HotelBookingApp.Interfaces;
using HotelBookingApp.Models;
using System.Collections.Generic;
using HotelBookingSystem.Interfaces;

namespace HotelBookingApp.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking GetBookingById(int bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }

        public List<Booking> GetBookingsByUserId(string userId)
        {
            return _bookingRepository.GetBookingsByUserId(userId);
        }

        public void CreateBooking(Booking booking)
        {
            _bookingRepository.CreateBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }

        public void DeleteBooking(int bookingId)
        {
            _bookingRepository.DeleteBooking(bookingId);
        }
    }
}
