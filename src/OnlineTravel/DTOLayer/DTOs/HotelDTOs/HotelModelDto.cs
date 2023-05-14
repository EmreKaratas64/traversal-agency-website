namespace DTOLayer.DTOs.HotelDTOs
{
    public class HotelModelDto
    {

        public int count { get; set; }
        public Result[]? results { get; set; }

        public class Result
        {
            public int id { get; set; }
            public string? name { get; set; }
            public string? photoMainUrl { get; set; }
            public int position { get; set; }
            public string? currency { get; set; }
            public Pricebreakdown? priceBreakdown { get; set; }
            public Checkin? checkin { get; set; }
            public Checkout? checkout { get; set; }
            public string? checkoutDate { get; set; }
            public string? checkinDate { get; set; }
            public float reviewScore { get; set; }
            public string? wishlistName { get; set; }
        }

        public class Pricebreakdown
        {
            public Grossprice? grossPrice { get; set; }

        }

        public class Grossprice
        {
            public float value { get; set; }
            public string? currency { get; set; }
        }

        public class Checkin
        {
            public string? untilTime { get; set; }
            public string? fromTime { get; set; }
        }

        public class Checkout
        {
            public string? fromTime { get; set; }
            public string? untilTime { get; set; }
        }

    }
}
