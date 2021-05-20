using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ShoppingBaskets
{
    public class AddProduct
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid ProductId { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.ProductId);

                var user = await _context.Users
                    .Include(u => u.ShoppingBasket)
                    .ThenInclude(sb => sb.Customer)
                    .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var shoppingBasketPair = await _context.ShoppingBasketPairs.FindAsync(user.Id, product.Id);

                if (shoppingBasketPair == null)
                {
                    var newShoppingBasketPair = new ShoppingBasketPair
                    {
                        Customer = user,
                        Product = product,
                        Amount = 1,
                        ShoppingBasket = user.ShoppingBasket
                    };
                    product.Customers.Add(newShoppingBasketPair);
                }
                else
                {
                    shoppingBasketPair.Amount++;
                    _context.ShoppingBasketPairs.Update(shoppingBasketPair);
                }

                var result = await _context.SaveChangesAsync() > 0;

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}