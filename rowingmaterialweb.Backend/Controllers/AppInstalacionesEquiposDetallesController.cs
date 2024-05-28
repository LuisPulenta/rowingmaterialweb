using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rowingmaterialweb.Backend.Data;

namespace rowingmaterialweb.Backend.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AppInstalacionesEquiposDetallesController : ControllerBase
    {
        private readonly DataContext _context;

        public AppInstalacionesEquiposDetallesController(DataContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------------
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetCombo(int Id)
        {
            return Ok(await _context.AppInstalacionesEquiposDetalles
                .Where(x => x.IDINSTALACIONEQUIPO == Id)
                .OrderBy(c => c.IDDETALLE)
                .ToListAsync());
        }
    }
}