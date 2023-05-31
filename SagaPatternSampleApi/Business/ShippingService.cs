namespace SagaPatternSampleApi.Business
{
    public class ShippingService : IShippingService
    {
        public async Task CreateShipping(ShippingInfo shippingInfo)
        {
            // Kargo oluşturma işlemini burada gerçekleştirin
            // Örnek olarak bir loglama işlemi yapalım
            await Task.Delay(1000);
            Console.WriteLine($"Shipping created for address: {shippingInfo.Address}");
        }
    }



}
