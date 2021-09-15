using API.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
  public class ActivitiesController : BaseApiController
  {
    private readonly DataContext _context; // DataContext possui o atributo Activities(do tipo DbSet)

    public ActivitiesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
      return await _context.Activities.ToListAsync(); // retorna atividades do banco
    }

    [HttpGet("{id}")] // activies/id
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
      return await _context.Activities.FindAsync(id);
    }
  }
}
