using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineTravel.Areas.Admin.Models
{
    public class CurrencyUnits
    {
        public string? SelectedValue { get; set; }
        public List<SelectListItem>? AvailableValues { get; set; }
    }
}
