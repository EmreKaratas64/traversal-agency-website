using DTOLayer.DTOs.CurrencyDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineTravel.Areas.Admin.Models;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class CurrencyAPIController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> ShowCurrencies()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
            {
                { "X-RapidAPI-Key", "3afe765c37msh2846d271b23bb13p140d30jsn9923964c3065" },
                { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeModelDto>(body);
                return View(values?.exchange_rates);

            }
        }

        [HttpPost]
        public async Task<IActionResult> ShowCurrencies(CurrencyUnits model)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={model.SelectedValue}&locale=en-gb"),
                Headers =
            {
                { "X-RapidAPI-Key", "3afe765c37msh2846d271b23bb13p140d30jsn9923964c3065" },
                { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeModelDto>(body);
                return View(values?.exchange_rates);

            }
        }




    }
}
