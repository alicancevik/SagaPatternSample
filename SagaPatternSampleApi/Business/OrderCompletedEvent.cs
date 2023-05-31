namespace SagaPatternSampleApi.Business
{
    public class OrderCompletedEvent
    {
        public string OrderId { get; set; }

        public OrderCompletedEvent(string orderId)
        {
            OrderId = orderId;
        }
    }



}
