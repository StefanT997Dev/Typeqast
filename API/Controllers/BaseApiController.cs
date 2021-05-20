using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    // I have decided to use the mediator pattern because our business 
    // logic doesn't belong to the controllers, it will be in our application
    // layer.
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        // Supposing we're getting a product from the client side that doesn't exist,
        // if we don't implement proper error handling we would get a 204 no content 
        // instead of a 404 not found. This is why it's essential to handle API error
        // responses
    }
}