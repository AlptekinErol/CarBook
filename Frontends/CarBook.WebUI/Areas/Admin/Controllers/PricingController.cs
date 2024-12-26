using CarBook.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Pricing")]
    public class PricingController : Controller
    {
        private static List<KeyValuePair<int, string>> pricingList = Enum.GetValues(typeof(Pricing))
            .Cast<Pricing>()
            .Select(e => new KeyValuePair<int, string>((int)e, e.ToString()))
            .ToList();

        /// <summary>
        /// Tüm Pricing enum değerlerini listeleyen sayfa.
        /// </summary>
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(pricingList);
        }

        /// <summary>
        /// Yeni bir Pricing değeri ekleme sayfası.
        /// </summary>
        [HttpGet]
        [Route("Create")]
        public IActionResult CreatePricing()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir Pricing değeri ekler.
        /// </summary>
        [HttpPost]
        [Route("Create")]
        public IActionResult CreatePricing(string name)
        {
            if (!string.IsNullOrEmpty(name) && !pricingList.Any(p => p.Value == name))
            {
                var newId = pricingList.Max(p => p.Key) + 1;
                pricingList.Add(new KeyValuePair<int, string>(newId, name));
                TempData["SuccessMessage"] = "Yeni Pricing değeri başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Pricing adı boş olamaz veya zaten mevcut.";
            return View();
        }

        /// <summary>
        /// Pricing değerini güncelleme sayfası.
        /// </summary>
        [HttpGet]
        [Route("UpdatePricing/{id}")]
        public IActionResult UpdatePricing(int id)
        {
            var pricing = pricingList.FirstOrDefault(p => p.Key == id);
            if (pricing.Key == 0)
            {
                TempData["ErrorMessage"] = "Pricing değeri bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(pricing);
        }

        /// <summary>
        /// Pricing değerini günceller.
        /// </summary>
        [HttpPost]
        [Route("UpdatePricing/{id}")]
        public IActionResult UpdatePricing(int id, string name)
        {
            var pricingIndex = pricingList.FindIndex(p => p.Key == id);
            if (pricingIndex >= 0 && !string.IsNullOrEmpty(name))
            {
                pricingList[pricingIndex] = new KeyValuePair<int, string>(id, name);
                TempData["SuccessMessage"] = "Pricing değeri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Pricing güncellenirken bir hata oluştu.";
            return View();
        }

        /// <summary>
        /// Pricing değerini siler.
        /// </summary>
        [HttpGet]
        [Route("RemovePricing/{id}")]
        public IActionResult RemovePricing(int id)
        {
            var pricing = pricingList.FirstOrDefault(p => p.Key == id);
            if (pricing.Key == 0)
            {
                TempData["ErrorMessage"] = "Pricing değeri bulunamadı.";
                return RedirectToAction("Index");
            }

            pricingList.Remove(pricing);
            TempData["SuccessMessage"] = "Pricing değeri başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
