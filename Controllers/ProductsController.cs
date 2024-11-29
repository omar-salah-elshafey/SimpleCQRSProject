using CQRSProject.Domain;
using CQRSProject.Features.Products.Commands.Create;
using CQRSProject.Features.Products.Commands.Delete;
using CQRSProject.Features.Products.Commands.Update;
using CQRSProject.Features.Products.DTOs;
using CQRSProject.Features.Products.Queries.Get;
using CQRSProject.Features.Products.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> ListProducts()
        {
            return Ok(await _mediator.Send(new ListProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductQuery(id));
                return product != null ? Ok(product) : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            try
            {
                var productId = await _mediator.Send(command);
                return productId != null ? Ok(productId) : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            try
            {
                var productId = await _mediator.Send(command);
                return productId != null ? Ok(productId) : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }
    }
}
