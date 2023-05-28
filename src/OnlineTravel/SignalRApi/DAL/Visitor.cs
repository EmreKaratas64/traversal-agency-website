namespace SignalRApi.DAL
{
    public enum ECity
    {
        Erzurum = 1,
        Ankara = 2,
        Bolu = 3,
        Bursa = 4,
        Aydın = 5
    };

    public class Visitor
    {
        public int VisitorID { get; set; }

        public ECity City { get; set; }

        public int CityVisitCount { get; set; }

        public DateTime VisitDate { get; set; }
    }
}
