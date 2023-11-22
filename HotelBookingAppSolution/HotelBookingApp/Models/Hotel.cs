using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models
{
    public class Hotel
    {
        [Key] public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        // Add other hotel details as needed
        // public List<Room> Rooms { get; set; }
    }
}