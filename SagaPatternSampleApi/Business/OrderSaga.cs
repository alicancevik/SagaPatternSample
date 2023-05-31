namespace SagaPatternSampleApi.Business
{
    public class OrderSaga
    {
        private readonly IStockService stockService;
        private readonly IPaymentService paymentService;
        private readonly IShippingService shippingService;
        private SagaState state;

        public OrderSaga(IStockService stockService, IPaymentService paymentService, IShippingService shippingService)
        {
            this.stockService = stockService;
            this.paymentService = paymentService;
            this.shippingService = shippingService;
            this.state = SagaState.Started;
        }

        public async Task Handle(OrderPlacedEvent orderPlacedEvent)
        {
            switch (state)
            {
                case SagaState.Started:
                    var stockCheckResult = await stockService.CheckStock(orderPlacedEvent.ProductId, orderPlacedEvent.Quantity);

                    if (stockCheckResult)
                    {
                        state = SagaState.StockChecked;
                    }
                    else
                    {
                        state = SagaState.InsufficientStock;
                    }

                    break;

                case SagaState.StockChecked:
                    var paymentResult = await paymentService.ProcessPayment(orderPlacedEvent.UserId, orderPlacedEvent.Amount);

                    if (paymentResult)
                    {
                        var shippingInfo = new ShippingInfo
                        {
                            Address = orderPlacedEvent.Address
                            // Diğer kargo bilgilerini burada belirtin
                        };

                        await shippingService.CreateShipping(shippingInfo);

                        state = SagaState.ShippingCreated;

                        // Sipariş tamamlandı olayını yayınlayın
                        var orderCompletedEvent = new OrderCompletedEvent(orderPlacedEvent.OrderId);
                        // Publish(orderCompletedEvent);

                        state = SagaState.Completed;
                    }
                    else
                    {
                        state = SagaState.PaymentFailed;
                    }

                    break;

                case SagaState.InsufficientStock:
                    // Stok yetersiz durumunda yapılacak işlemler
                    break;

                case SagaState.PaymentFailed:
                    // Ödeme başarısız durumunda yapılacak işlemler
                    break;

                case SagaState.ShippingCreated:
                    // Kargo oluşturuldu durumunda yapılacak işlemler
                    break;

                case SagaState.Completed:
                    // Tamamlanmış durumunda yapılacak işlemler
                    break;

                default:
                    // Hata durumunda yapılacak işlemler
                    break;
            }
        }
    }



}
