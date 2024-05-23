using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeetingRoomBooking.Services;
using System;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MeetingRoomController : ControllerBase
{
    private readonly MeetingRoomService _meetingRoomService;

    public MeetingRoomController(MeetingRoomService meetingRoomService)
    {
        _meetingRoomService = meetingRoomService;
    }

    [HttpGet]
    public IActionResult GetAllMeetingRooms()
    {
        var meetingRooms = _meetingRoomService.GetAllMeetingRooms();
        return Ok(meetingRooms);
    }

    [HttpPost("reserve")]
    public IActionResult ReserveMeetingRoom([FromBody] ReservationRequest request)
    {
        if (_meetingRoomService.ReserveMeetingRoom(request.MeetingRoomId, request.StartTime, request.EndTime, request.ReservedBy))
        {
            return Ok();
        }
        return BadRequest("Room is already reserved for the given time period.");
    }

    [HttpPost("cancel")]
    public IActionResult CancelReservation([FromBody] int reservationId)
    {
        if (_meetingRoomService.CancelReservation(reservationId))
        {
            return Ok();
        }
        return BadRequest("Reservation not found.");
    }
}

public class ReservationRequest
{
    public int MeetingRoomId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string ReservedBy { get; set; }
}
