using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyConsumptionController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public EnergyConsumptionController(SHSOSDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyConsumption>>> GetEnergyConsumption()
        {
            return await _context.EnergyConsumption.ToListAsync();
        }
    }
}
