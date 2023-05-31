namespace SagaPatternSampleApi.Business
{
    public class StockService : IStockService
    {
        private Dictionary<string, int> stock;

        public StockService()
        {
            stock = new Dictionary<string, int>
        {
            { "P001", 5 },
            { "P002", 10 },
            { "P003", 3 }
        };
        }

        public async Task<bool> CheckStock(string productId, int quantity)
        {
            // Stok kontrolünü burada gerçekleştirin
            await Task.Delay(1000);
            return stock.ContainsKey(productId) && stock[productId] >= quantity;
        }

        public async Task Restock(string productId, int quantity)
        {
            // Stok yenileme işlemini burada gerçekleştirin
            await Task.Delay(1000);
            if (stock.ContainsKey(productId))
            {
                stock[productId] += quantity;
            }
            else
            {
                stock.Add(productId, quantity);
            }
        }
    }



}
