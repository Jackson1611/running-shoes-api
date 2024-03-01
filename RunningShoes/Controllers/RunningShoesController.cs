using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunningShoes.Models;

namespace RunningShoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoesController : ControllerBase
    {
        private readonly RunningShoesDbContext _context;

        public ShoesController(RunningShoesDbContext context)
        {
            _context = context;
        }

        // Get all shoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetShoes()
        {
            return await _context.Shoes.ToListAsync();
        }

        // Get a specific shoe by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Shoe>> GetShoe(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);

            if (shoe == null)
            {
                return NotFound();
            }

            return shoe;
        }
    }
}
