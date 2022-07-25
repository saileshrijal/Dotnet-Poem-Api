using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoemAPI.Data;
using PoemAPI.Models;

namespace PoemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PoemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (_context.Poems != null)
            {
                var poems = await _context.Poems.ToListAsync();
                return Ok(poems);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (_context.Poems != null)
            {
                var poem = await _context.Poems.FirstOrDefaultAsync(p => p.Id == id);
                if (poem != null)
                {
                    return Ok(poem);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Poem poem)
        {
            if (ModelState.IsValid)
            {
                if (_context.Poems != null)
                {
                    await _context.Poems.AddAsync(poem);
                    await _context.SaveChangesAsync();
                    return Ok(poem);
                }
            }
            return BadRequest();
        }
    }
}