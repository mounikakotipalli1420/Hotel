using HotelBookingApp.Interfaces;
using HotelBookingApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomService;

        public RoomController(IRoomRepository roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpGet("hotel/{hotelId}")]
        public IActionResult GetRoomsByHotelId(int hotelId)
        {
            var rooms = _roomService.GetRoomsByHotelId(hotelId);
            return Ok(rooms);
        }

        [HttpPost]
        public IActionResult CreateRoom(RoomDTO room)
        {
            if (ModelState.IsValid)
            {
                _roomService.CreateRoom(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, room);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, RoomDTO room)
        {
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _roomService.UpdateRoom(room);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            _roomService.DeleteRoom(id);
            return NoContent();
        }
    }
}
