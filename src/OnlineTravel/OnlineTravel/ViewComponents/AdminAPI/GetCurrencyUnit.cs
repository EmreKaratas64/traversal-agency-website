using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTravel.Areas.Admin.Models;

namespace OnlineTravel.ViewComponents.AdminAPI
{
    public class GetCurrencyUnit : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CurrencyUnits model = new CurrencyUnits();
            model.AvailableValues = GetAvailableValues();
            return View(model);
        }

        private List<SelectListItem> GetAvailableValues()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "TRY", Text = "TRY" },
            new SelectListItem { Value = "USD", Text = "USD" },
            new SelectListItem { Value = "GBP", Text = "GBP" }
        };
        }
    }
}
