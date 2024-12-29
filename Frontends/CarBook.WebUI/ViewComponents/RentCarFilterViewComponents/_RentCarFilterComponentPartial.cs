using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentCarFilterViewComponents
{
    public class _RentCarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
