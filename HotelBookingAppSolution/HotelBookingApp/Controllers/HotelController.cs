using HotelBookingApp.Interfaces;
using HotelBookingApp.Models;
using HotelBookingApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        // GET: api/hotel
        [HttpGet]
        public ActionResult<IEnumerable<HotelDTO>> GetHotels()
        {
            var hotels = _hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        // GET: api/hotel/1
        [HttpGet("{id}")]
        public ActionResult<HotelDTO> GetHotel(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // POST: api/hotel
        [HttpPost]
        public ActionResult<Hotel> CreateHotel(Hotel hotel)
        {
            _hotelRepository.CreateHotel(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.HotelId }, hotel);
        }

        // PUT: api/hotel/1
        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }

            _hotelRepository.UpdateHotel(hotel);

            return NoContent();
        }

        // DELETE: api/hotel/1
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _hotelRepository.DeleteHotel(id);

            return NoContent();
        }
        [HttpGet("{id}/roomcount")]
        public ActionResult<int> GetAllRoomCount(int id)
        {
            var roomCount = _hotelRepository.GetAllRoomCount(id);

            if (roomCount < 0)
            {
                return NotFound();
            }

            return Ok(roomCount);
        }


    }
}