using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
using SHSOS.Models;

namespace SHSOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteManagementController : ControllerBase
    {
        private readonly SHSOSDb _context;

        public WasteManagementController(SHSOSDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WasteManagement>>> GetWasteManagement()
        {
            return await _context.WasteManagement.ToListAsync();
        }
    }
}
