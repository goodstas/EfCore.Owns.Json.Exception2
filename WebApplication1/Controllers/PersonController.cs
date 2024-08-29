using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppDB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public PersonController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            return _dbContext.Persons.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(Guid id)
        {
            var Person = _dbContext.Persons.Find(id);
            if (Person == null)
            {
                return NotFound();
            }
            return Person;
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson([FromBody] Person Person)
        {
            _dbContext.Persons.Add(Person);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetPersonById), new { id = Person.Id }, Person);
        }
               
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var Person = _dbContext.Persons.Find(id);
            if (Person == null)
            {
                return NotFound();
            }

            _dbContext.Persons.Remove(Person);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
