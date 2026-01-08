using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public HospitalsController(SHSOSDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospitals>>> Get()
        {
            var list = await _context.Hospitals.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hospitals>> Get(int id)
        {
            var item = await _context.Hospitals.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}