using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class StatisticsController : Controller
    {        [Route("Index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
