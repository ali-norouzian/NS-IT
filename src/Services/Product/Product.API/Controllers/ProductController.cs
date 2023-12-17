using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.Products.Queries.GetAllProducts;
using Product.Application.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Product.Application.Features.Products.Commands.CreateProduct;
using Product.Application.Features.Products.Commands.UpdateProduct;

namespace Product.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly HttpContext _httpContext;
        private readonly int? CurrentUserId;

        public ProductController(IMediator mediator, IHttpContextAccessor accessor) : base(mediator)
        {
            _httpContext = accessor.HttpContext;
            var userIdClaim = _httpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId");
            CurrentUserId = userIdClaim != null ? int.Parse(userIdClaim.Value) : (int?)null;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllProductsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> ListProduct()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            var response = new ResponseMessage(result: products);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<GetAllProductsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetProduct(int id)
        {
            var query = new GetAllProductsQuery(id);
            var products = await _mediator.Send(query);

            var response = new ResponseMessage(result: products);
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(CreateProductCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create(CreateProductCommand command)
        {
            // Override it
            command.CreatorUserId = CurrentUserId;
            var result = await _mediator.Send(command);

            var response = new ResponseMessage(result: new { productId = result });
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateProductCommand command)
        {
            /*  We can use input classes instead of commands in action for masking this 
               override properties from ui but ... */
            command.UpdatorUserId = CurrentUserId;
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
