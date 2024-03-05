using Microsoft.AspNetCore.Mvc;
using RunningShoes.Interfaces;
using RunningShoes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using RunningShoes.Repository;

namespace RunningShoes.Controllers
{
    [ApiController]
    [Route("shoes/")]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeRepository _shoeRepository;

        public ShoesController(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetAllShoes()
        {
            var shoes = await _shoeRepository.GetAllAsync();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(shoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shoe>> GetShoeById(int id)
        {
            var shoe = await _shoeRepository.GetByIdAsync(id);
            if (shoe == null)
                return NotFound();

            return shoe;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Shoe>>> SearchShoes([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required.");

            var matchingShoes = await _shoeRepository.SearchAsync(query);
            return Ok(matchingShoes);
        }

        [HttpPost]
        public async Task<ActionResult<Shoe>> AddShoe(Shoe shoe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _shoeRepository.AddAsync(shoe);
            return CreatedAtAction(nameof(GetShoeById), new { id = shoe.Id }, shoe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoe(int id, Shoe shoe)
        {
            if (id != shoe.Id)
                return BadRequest();

            await _shoeRepository.UpdateAsync(shoe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoe(int id)
        {
            await _shoeRepository.DeleteAsync(id);
            return NoContent();
        }

        
    }
}
