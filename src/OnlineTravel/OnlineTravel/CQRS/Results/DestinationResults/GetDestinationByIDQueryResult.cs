namespace OnlineTravel.CQRS.Results.DestinationResults
{
    public class GetDestinationByIDQueryResult
    {
        public int DestinationID { get; set; }

        public string? City { get; set; }

        public string? DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
