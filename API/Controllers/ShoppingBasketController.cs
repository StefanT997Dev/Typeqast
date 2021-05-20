using System;
using System.Threading.Tasks;
using Application.ShoppingBaskets;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShoppingBasketController:BaseApiController
    {
        [HttpPost("{productId}")]
        [Authorize]
        public async Task<IActionResult> AddProduct(Guid productId)
        {
            return Ok(await Mediator.Send(new AddProduct.Command{ProductId=productId}));
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return Ok(await Mediator.Send(new Application.ShoppingBaskets.Create.Command()));
        }
    }
}