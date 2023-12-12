using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
	public class ProductController : BaseController
	{
		[HttpGet]
		public ActionResult Index()
		{
			return Ok("HI!");
		}
	}
}
