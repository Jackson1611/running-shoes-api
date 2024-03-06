using Microsoft.AspNetCore.Mvc;
using RunningShoes.Interfaces;
using RunningShoes.Models;
using System.Collections.Generic;
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
        public List<Shoe> GetAllShoes()
        {
            return _shoeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Shoe GetShoeById(int id)
        {
            var shoe = _shoeRepository.GetById(id);
            if (shoe == null)
                NotFound();

            return shoe;
        }

        [HttpGet("search")]
        public List<Shoe> SearchShoes([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                BadRequest("Query parameter is required.");

            return _shoeRepository.Search(query);
        }

        [HttpPost]
        public Shoe AddShoe(Shoe shoe)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            _shoeRepository.Add(shoe);
            return shoe;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShoe(int id, Shoe shoe)
        {
            if (id != shoe.Id)
                BadRequest();

            _shoeRepository.Update(shoe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShoe(int id)
        {
            _shoeRepository.Delete(id);
            return NoContent();
        }
    }
}