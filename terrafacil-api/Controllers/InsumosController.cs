using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using terrafacil_api.Models;

namespace terrafacil_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsumosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Insumos.ToListAsync();
            return Ok(model);

        }

        [HttpPost]
        public async Task<ActionResult> Create(Insumo model)
        {
            _context.Insumos.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Insumos
                .FirstOrDefaultAsync(c => c.Id == id);

            if(model == null) NotFound();

            return Ok(model);

        }
    }
}
