using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command> // Event subscriber
        {
            private readonly DataContext _context;
            public Handler (DataContext context) 
            {
                _context = context;  
            }
            // method is called by publisher when the event is raised
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

            }
        }
    }
}