using static MassTransit.Logging.OperationName;

namespace SagaPatternSampleApi.Business
{
    public class OrderPlacedEvent
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
    }
}
