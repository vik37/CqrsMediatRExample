using CqrsMediatRExample.Commands;
using CqrsMediatRExample.Notifications;
using CqrsMediatRExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatRExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}",Name ="GetProductById")]
        public async Task<ActionResult> GetProducById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        } 

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product model)
        {
            var product = await _sender.Send(new AddProductCommand(model));

            await _publisher.Publish(new ProductAddedNotifications(product));
            return CreatedAtRoute("GetProductByid",new {id = product.Id},product);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product model)
        {
            var product = await _sender.Send(new UpdateProductCommand(model));
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sender.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
