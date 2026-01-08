using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WasteManagementController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public WasteManagementController(SHSOSDb context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpGet("/api/waste")]
        [HttpGet("/waste")]
        public async Task<ActionResult<IEnumerable<WasteManagement>>> Get()
        {
            var list = await _context.WasteManagement.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [HttpGet("/api/waste/{id:int}")]
        [HttpGet("/waste/{id:int}")]
        public async Task<ActionResult<WasteManagement>> Get(int id)
        {
            var item = await _context.WasteManagement.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
