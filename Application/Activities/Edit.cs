using AutoMapper;
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
  public class Edit
  {
    public class Command : IRequest
    {
      public Activity Activity { get; set; }

    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
        // inject the mapper into the handler
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var activity = await _context.Activities.FindAsync(request.Activity.Id);

        // we would have to set every field like this:
        //activity.Title = request.Activity.Title ?? activity.Title;

        // but auto mapper helps us reduce the amount of code written
        _mapper.Map(request.Activity, activity);
        // we are mapping every property from activity(request body) to the database activity

        await _context.SaveChangesAsync(); // save changes to db

        return Unit.Value; // does nothing, just for the API to know that we are done
      }
    }
  }
}
