using Microsoft.AspNetCore.Mvc;
using MeetingRoomBooking.Data;
using MeetingRoomBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations.Include(r => r.MeetingRoom).ToListAsync();
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }
    }
}