using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterConsumptionController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public WaterConsumptionController(SHSOSDb context)
        {
            _context = context;
        }

        // GET /api/WaterConsumption
        // Also reachable at /api/water and /water
        [HttpGet]
        [HttpGet("/api/water")]
        [HttpGet("/water")]
        public async Task<ActionResult<IEnumerable<WaterConsumption>>> Get()
        {
            var list = await _context.WaterConsumption.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // GET /api/WaterConsumption/{id}
        [HttpGet("{id:int}")]
        [HttpGet("/api/water/{id:int}")]
        [HttpGet("/water/{id:int}")]
        public async Task<ActionResult<WaterConsumption>> Get(int id)
        {
            var item = await _context.WaterConsumption.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
