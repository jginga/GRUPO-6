namespace MeetingRoomBooking.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }

