using FarmManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmManagementApi
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalComtroller(AnimalDbContext _context) : ControllerBase
    {

        // GET: api/<AnimalComtroller>
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return (IEnumerable<Animal>)_context.Animals.ToList();
        }

        // POST api/<AnimalComtroller>
        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            if (_context.Animals.Contains(animal))
            {
                return Conflict("This animal already exists.");
            }

            _context.Animals.Add(animal);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<AnimalComtroller>/5
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Name == name);
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
