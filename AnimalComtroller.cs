using FarmManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmManagementApi
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalComtroller(AnimalDbContext _context) : ControllerBase
    {

        // GET: api/<AnimalComtroller>
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return (IEnumerable<Animal>)_context.Animals.ToList();
        }

        // GET api/<AnimalComtroller>/5
        [HttpGet("{id}")]
        public Animal Get(Guid id)
        {
            return _context.Animals.FirstOrDefault(a => a.Id == id);
        }

        // POST api/<AnimalComtroller>
        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<AnimalComtroller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Animal animal)
        {
            var exst_animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if (exst_animal == null)
            {
                return NotFound();
            }
            exst_animal.Name = animal.Name;
            _context.Update(exst_animal);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<AnimalComtroller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return Ok();
        }
    }
}
