using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.Products.Queries.GetAllProducts;

namespace Product.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            return Ok(products);
        }
    }
}
