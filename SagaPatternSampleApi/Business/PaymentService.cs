namespace SagaPatternSampleApi.Business
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> ProcessPayment(string userId, decimal amount)
        {
            // Ödeme işlemini burada gerçekleştirin
            // Örnek olarak her zaman başarılı olduğunu varsayalım
            await Task.Delay(1000);
            return true;
        }
    }



}
