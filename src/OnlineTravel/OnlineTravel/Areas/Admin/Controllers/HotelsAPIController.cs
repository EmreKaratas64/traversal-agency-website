using DTOLayer.DTOs.HotelDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace OnlineTravel.Areas.Admin
{
    [Area("Admin")]
    public class HotelsAPIController : Controller
    {
        public async Task<IActionResult> ShowHotels()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=USD&dest_id=20088325&locale=en-gb&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
                var data = JsonConvert.DeserializeObject<HotelModelDto>(body);
                return View(data?.results);
            }

        }

    }
}
