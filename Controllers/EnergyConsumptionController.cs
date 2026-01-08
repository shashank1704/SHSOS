using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyConsumptionController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public EnergyConsumptionController(SHSOSDb context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpGet("/api/energy")]
        [HttpGet("/energy")]
        public async Task<ActionResult<IEnumerable<EnergyConsumption>>> Get()
        {
            var list = await _context.EnergyConsumption.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [HttpGet("/api/energy/{id:int}")]
        [HttpGet("/energy/{id:int}")]
        public async Task<ActionResult<EnergyConsumption>> Get(int id)
        {
            var item = await _context.EnergyConsumption.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
