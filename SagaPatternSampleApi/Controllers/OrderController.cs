using Microsoft.AspNetCore.Mvc;
using SagaPatternSampleApi.Business;

namespace SagaPatternSampleApi.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderSaga _orderSaga;

        public OrderController(OrderSaga orderSaga)
        {
            _orderSaga = orderSaga;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderPlacedEvent orderPlacedEvent)
        {
            await _orderSaga.Handle(orderPlacedEvent);

            return Ok();
        }
    }
}
