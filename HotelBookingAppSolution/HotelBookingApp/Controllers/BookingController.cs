using HotelBookingApp.Interfaces;
using HotelBookingApp.Models;
using HotelBookingSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HotelBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{bookingId}")]
        public ActionResult<Booking> GetBookingById(int bookingId)
        {
            var booking = _bookingService.GetBookingById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<Booking>> GetBookingsByUserId(string userId)
        {
            var bookings = _bookingService.GetBookingsByUserId(userId);
            return Ok(bookings);
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            try
            {
                _bookingService.CreateBooking(booking);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{bookingId}")]
        public ActionResult UpdateBooking(int bookingId, Booking booking)
        {
            try
            {
                if (bookingId != booking.BookingId)
                {
                    return BadRequest("Invalid booking ID.");
                }

                _bookingService.UpdateBooking(booking);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{bookingId}")]
        public ActionResult DeleteBooking(int bookingId)
        {
            try
            {
                _bookingService.DeleteBooking(bookingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
