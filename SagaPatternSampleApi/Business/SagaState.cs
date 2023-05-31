namespace SagaPatternSampleApi.Business
{
    public enum SagaState
    {
        Started,
        StockChecked,
        PaymentProcessed,
        ShippingCreated,
        Completed,
        PaymentFailed,
        InsufficientStock,
        Cancelled,
        Error
    }



}
