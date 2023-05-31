using Microsoft.AspNetCore.Mvc;
using SagaPatternSampleApi.Business;

namespace SagaPatternSampleApi.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderSaga orderSaga;

        public OrderController(OrderSaga orderSaga)
        {
            this.orderSaga = orderSaga;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderPlacedEvent orderPlacedEvent)
        {
            await orderSaga.Handle(orderPlacedEvent);

            return Ok();
        }
    }
}
