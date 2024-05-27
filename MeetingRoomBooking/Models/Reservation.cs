using System;


namespace MeetingRoomBooking.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }  // Adicionada propriedade StartTime
        public DateTime EndTime { get; set; }    // Adicionada propriedade EndTime
        public DateTime Date { get; set; }
        public string ReservedBy { get; set; }
        public int MeetingRoomId { get; set; }
        public MeetingRoom MeetingRoom { get; set; }
    }
}