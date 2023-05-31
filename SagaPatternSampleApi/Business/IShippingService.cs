namespace SagaPatternSampleApi.Business
{
    public interface IShippingService
    {
        Task CreateShipping(ShippingInfo shippingInfo);
    }



}
