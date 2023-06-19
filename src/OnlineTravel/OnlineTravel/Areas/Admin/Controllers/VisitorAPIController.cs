using DTOLayer.DTOs.VisitorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class VisitorAPIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorAPIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> ShowVisitors()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5011/api/Customer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<VisitorModelDto>>(jsonData);
                return View(data);
            }

            return View();
        }

        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5011/api/Customer/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowVisitors");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddVisitor() => View();

        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorModelDto visitorModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(visitorModel);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5011/api/Customer", content);
                if (responseMessage.IsSuccessStatusCode) return RedirectToAction("ShowVisitors");
            }
            return View(visitorModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5011/api/Customer/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<VisitorModelDto>(jsonData);
                return View(data);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorModelDto visitorModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(visitorModel);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5011/api/Customer", content);
                if (responseMessage.IsSuccessStatusCode) return RedirectToAction("ShowVisitors");
            }
            return View(visitorModel);
        }
    }
}
