using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunningShoes.Data;
using RunningShoes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningShoes.Controllers
{
    [ApiController]
    [Route("shoes/")]
    public class ShoesController : ControllerBase
    {
        private readonly RunningShoesDbContext _context;

        public ShoesController(RunningShoesDbContext context)
        {
            _context = context;
        }

        // GET: api/Shoes (Read all)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetShoes()
        {
            return await _context.Shoes.ToListAsync();
        }

        // GET: api/Shoes/5 (Read by ID)
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

        // GET: api/Shoes/search?query=example (Search by either name or brand)
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Shoe>>> SearchShoes([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query parameter is required.");
            }

            var matchingShoes = await _context.Shoes
                .Where(s => s.Name.Contains(query) || s.Brand.Contains(query))
                .ToListAsync();

            return matchingShoes;
        }

        // POST: api/Shoes (Create)
        [HttpPost]
        public async Task<ActionResult<Shoe>> PostShoe(Shoe shoe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShoe), new { id = shoe.Id }, shoe);
        }

        // PUT: api/Shoes/5 (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoe(int id, Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Shoes/5 (Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoe(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }

            _context.Shoes.Remove(shoe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoes.Any(e => e.Id == id);
        }
    }
}
