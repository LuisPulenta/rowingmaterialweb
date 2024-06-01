using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rowingmaterialweb.Backend.Data;
using rowingmaterialweb.Backend.Helpers;
using rowingmaterialweb.Shared.DTOs;

namespace rowingmaterialweb.Backend.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AppInstalacionesEquiposController : ControllerBase
    {
        private readonly DataContext _context;

        public AppInstalacionesEquiposController(DataContext context)
        {
            _context = context;
        }


        //---------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.AppInstalacionesEquipos
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.ApellidoCliente.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.Fecha)
                .Paginate(pagination)
                .ToListAsync());
        }

        //---------------------------------------------------------------------------------------
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.AppInstalacionesEquipos
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.ApellidoCliente.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.Fecha)
                .ToListAsync());
        }

        //---------------------------------------------------------------------------------------
        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.AppInstalacionesEquipos
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.ApellidoCliente.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        //---------------------------------------------------------------------------------------
        [HttpGet("totalRegisters")]
        public async Task<ActionResult> GetRegisters([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.AppInstalacionesEquipos
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.ApellidoCliente.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            return Ok(count);
        }

        //--------------------------------------------------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var customer = await _context.VistaAppInstalacionesEquipos.FirstOrDefaultAsync(x => x.IDRegistro == id);
            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}