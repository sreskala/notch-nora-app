using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;

namespace Application.Posts
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context) {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Post post = await _context.Posts.FindAsync(request.Id);

                _context.Remove(post);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}