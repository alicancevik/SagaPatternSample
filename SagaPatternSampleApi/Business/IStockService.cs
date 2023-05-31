namespace SagaPatternSampleApi.Business
{
    public interface IStockService
    {
        Task<bool> CheckStock(string productId, int quantity);
        Task Restock(string productId, int quantity);
    }



}
