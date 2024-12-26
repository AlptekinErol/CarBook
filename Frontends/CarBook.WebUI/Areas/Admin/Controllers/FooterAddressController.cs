using CarBook.DTO.FooterAddressDtos;
using CarBook.DTO.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FooterAddress")]
    public class FooterAddressController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public FooterAddressController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm FooterAddress'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>FooterAddress listesini içeren View döner.</returns>
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/FooterAddresses");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir FooterAddress'ı siler.
        /// </summary>
        /// <param name="id">Silinecek FooterAddress'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveFooterAddress/{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/FooterAddresses/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterAddress", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Yeni bir FooterAddress oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni FooterAddress oluşturma görünümü döner.</returns>
        [HttpGet]
        [Route("CreateFooterAddress")]
        public IActionResult CreateFooterAddress()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir FooterAddress oluşturur.
        /// </summary>
        /// <param name="createFooterAddressDto">Oluşturulacak FooterAddress'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFooterAddressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/FooterAddresses", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterAddress", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir FooterAddress'ın güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek FooterAddress'ın benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek FooterAddress'ın bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/FooterAddresses/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir FooterAddress'ı günceller.
        /// </summary>
        /// <param name="updateFooterAddressDto">Güncellenecek FooterAddress'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/FooterAddresses/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterAddress", new { area = "Admin" });
            }
            return View();
        }
    }
}
