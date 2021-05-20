using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ShoppingBaskets
{
    // I am storing the basket on the backend so the user can have the same products
    // if he/she logs out and changes his/her device.
    public class Create
    {
        public class Command : IRequest
        {

        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(x=>x.UserName == _userAccessor.GetUsername());

                var shoppingBasket = new ShoppingBasket
                {
                    NumberOfItems = 0,
                    TotalPrice = 0,
                    Customer = user
                };

                _context.ShoppingBaskets.Add(shoppingBasket);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}