namespace MeetingRoomBooking.Controllers
{
    using MeetingRoomBooking.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var meetings = _context.Meetings.ToList();
            return View(meetings);
        }
    }

}
