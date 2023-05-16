namespace DTOLayer.DTOs.AccountUowDTOs
{
    public class SendOperationModelDto
    {
        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public decimal Amount { get; set; }
    }
}
