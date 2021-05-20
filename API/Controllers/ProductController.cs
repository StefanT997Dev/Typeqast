using System.Threading.Tasks;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController:BaseApiController
    {
        //Reserved for the admin to create a new product
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            return Ok(await Mediator.Send(new Create.Command{Product=product}));
        }
    }
}