using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.Products.Queries.GetAllProducts;
using Product.Application.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Product.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllProductsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Index()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            var response = new ResponseMessage(result: products);
            return Ok(response);
        }
    }
}
