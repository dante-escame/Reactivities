using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
  public class List
  {
    public class Query : IRequest<List<Activity>> {}
    public class Handler : IRequestHandler<Query, List<Activity>>
    {
      private readonly DataContext _context; // DataContext possui o atributo Activities(do tipo DbSet)
      //private readonly ILogger<List> _logger; -> for demo of cancellationToken working

      public Handler(DataContext context, ILogger<List> logger)
      {
        _context = context;
        //_logger = logger; -> for demo of cancellationToken working
      }

      public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
      {
        /* 
         * Demonstration of cancellationToken working
        try
        {
          for (var i = 0; i < 10; i++)
          {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(1000, cancellationToken);
            _logger.LogInformation($"Task {i} has completed");
          }
        } 
        catch (Exception ex) when (ex is TaskCanceledException)
        {
          _logger.LogInformation("Task was cancelled");
        }*/

        return await _context.Activities.ToListAsync(); // param -> cancellationToken
      }
    }
  }
}
