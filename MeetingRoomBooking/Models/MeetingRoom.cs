namespace MeetingRoomBooking.Models
{
    public class MeetingRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; } // True if available, false if reserved
    }
}
