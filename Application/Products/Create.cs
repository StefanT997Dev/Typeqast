using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    // I have decided to implement the CQRS pattern
    // so that we can separate querys and commands.
    // The reason this is effective is that we can 
    // have two different databases, one is denormalized 
    // and optimized for reading (MongoDB for example)
    // and the other is normalized and optimized for commands
    public class Create
    {
        public class Command : IRequest
        {
            public Product Product { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Products.Add(request.Product);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}