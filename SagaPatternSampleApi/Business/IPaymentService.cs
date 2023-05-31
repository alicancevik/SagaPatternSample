namespace SagaPatternSampleApi.Business
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(string userId, decimal amount);
    }



}
