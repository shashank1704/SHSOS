using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterConsumptionController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public WaterConsumptionController(SHSOSDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterConsumption>>> GetWaterConsumption()
        {
            return await _context.WaterConsumption.ToListAsync();
        }
    }
}
