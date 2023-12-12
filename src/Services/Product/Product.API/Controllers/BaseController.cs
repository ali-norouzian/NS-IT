using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public abstract class BaseController : ControllerBase
	{
	}
}
