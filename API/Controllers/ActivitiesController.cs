using API.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using System.Threading;

namespace API.Controllers
{
  public class ActivitiesController : BaseApiController
  {
    // Each one of these streams of code below are ENDPOINTS -> important concept

    // CQRS -> Query
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities() // param -> CancellationToken ct(for demo)
    {
      return await Mediator.Send(new List.Query()); // param -> ,ct(for demo)
      //return await _context.Activities.ToListAsync(); // retorna atividades do banco
    }

    // CQRS -> Query
    [HttpGet("{id}")] // activities/id
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    // CQRS -> Command
    [HttpPost]
    // "[FromBody]" is not needed considering that the API knows automatically that it needs to look at the body of the request
    public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
    {
      return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Activity activity)
    {
      activity.Id = id;
      return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
      return Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
  }
}
