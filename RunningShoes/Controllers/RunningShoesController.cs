using Microsoft.AspNetCore.Mvc;
using RunningShoes.Interfaces;
using RunningShoes.Models;


namespace RunningShoes.Controllers
{
    [ApiController]
    [Route("api/shoes/")]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeRepository _shoeRepository;

        public ShoesController(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        [HttpGet]
        public IActionResult GetAllShoes()
        {
            var shoes = _shoeRepository.GetAll();
            return Ok(shoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetShoeById(int id)
        {
            var shoe = _shoeRepository.GetById(id);
            if (shoe == null)
                return NotFound();

            return Ok(shoe);
        }

        [HttpGet("search")]
        public IActionResult SearchShoes([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required.");

            var matchingShoes = _shoeRepository.Search(query);
            return Ok(matchingShoes);
        }

        [HttpPost]
        public IActionResult AddShoe(Shoe shoe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if a shoe with the same name already exists
            var existingShoe = _shoeRepository.GetByName(shoe.Name);
            if (existingShoe != null)
            {
                ModelState.AddModelError("Name", "A shoe with the same name already exists.");
                return BadRequest(ModelState);
            }

            _shoeRepository.Add(shoe);
            return CreatedAtAction(nameof(GetShoeById), new { id = shoe.Id }, shoe);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShoe(int id, Shoe shoe)
        {
            if (id != shoe.Id)
                return BadRequest();

            _shoeRepository.Update(shoe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShoe(int id)
        {

            if (_shoeRepository.GetById(id) == null) { 
                return NotFound();
            }

            _shoeRepository.Delete(id);
            return NoContent();
        }

        

    }
}
