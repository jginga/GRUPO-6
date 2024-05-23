using System;


namespace MeetingRoomBooking.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int MeetingRoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ReservedBy { get; set; }
        public MeetingRoom MeetingRoom { get; set; }
    }
}