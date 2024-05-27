using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MeetingRoomBooking.Controllers
{
    public class CartController : Controller
    {
        [HttpGet("/cart.json")]
        public IActionResult GetCartJson()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cart.json");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Retorna 404 se o arquivo não for encontrado
            }
            var json = System.IO.File.ReadAllText(filePath);
            return Content(json, "application/json");
        }
    }
}