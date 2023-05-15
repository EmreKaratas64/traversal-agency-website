namespace OnlineTravel.CQRS.Results.GuideResults
{
    public class GetGuideQueryResult
    {
        public int GuideID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
