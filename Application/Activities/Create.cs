using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
  public class Create
  {
    public class Command : IRequest
    {
      public Activity Activity { get; set; }

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
        _context.Activities.Add(request.Activity); // adding activity in memory, so "Add" it does not need to be async

        await _context.SaveChangesAsync(); // save change to the database, now this needs to be async

        return Unit.Value; // this is equivalent to nothing, it lets our API controller now that we are finished
      }
    }
  }
}
