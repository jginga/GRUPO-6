using System;
using System.Collections.Generic;
using System.Linq;
using MeetingRoomBooking.Models;
using MeetingRoomBooking.Data;

namespace MeetingRoomBooking.Services
{
    public class MeetingRoomService
    {
        private readonly ApplicationDbContext _context;

        public MeetingRoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MeetingRoom> GetAllMeetingRooms()
        {
            return _context.MeetingRooms.ToList();
        }

        public MeetingRoom GetMeetingRoomById(int id)
        {
            return _context.MeetingRooms.FirstOrDefault(mr => mr.Id == id);
        }

        public bool IsMeetingRoomAvailable(int meetingRoomId, DateTime startTime, DateTime endTime)
        {
            return !_context.Reservations.Any(r => r.MeetingRoomId == meetingRoomId &&
                                                   ((startTime >= r.StartTime && startTime < r.EndTime) ||
                                                    (endTime > r.StartTime && endTime <= r.EndTime)));
        }

        public bool ReserveMeetingRoom(int meetingRoomId, DateTime startTime, DateTime endTime, string reservedBy)
        {
            if (IsMeetingRoomAvailable(meetingRoomId, startTime, endTime))
            {
                _context.Reservations.Add(new Reservation
                {
                    MeetingRoomId = meetingRoomId,
                    StartTime = startTime,
                    EndTime = endTime,
                    ReservedBy = reservedBy
                });
                _context.SaveChanges();

                var meetingRoom = GetMeetingRoomById(meetingRoomId);
                meetingRoom.IsAvailable = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CancelReservation(int reservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                var meetingRoom = GetMeetingRoomById(reservation.MeetingRoomId);
                meetingRoom.IsAvailable = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
