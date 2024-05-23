using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
