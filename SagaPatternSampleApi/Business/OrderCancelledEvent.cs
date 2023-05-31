namespace SagaPatternSampleApi.Business
{
    public class OrderCancelledEvent
    {
        public string OrderId { get; set; }
        public string Reason { get; set; }

        public OrderCancelledEvent(string orderId, string reason)
        {
            OrderId = orderId;
            Reason = reason;
        }
    }



}
