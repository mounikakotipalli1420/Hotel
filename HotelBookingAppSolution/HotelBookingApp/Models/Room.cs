using HotelBookingApp.Models;
using HotelBookingApp.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models
{
    public class Room
    {


        [Key] public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public decimal Price { get; set; }
        // Add other room details as needed
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }


    }
}