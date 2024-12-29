using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentCarListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
