using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PeopleContext _context;
        public PersonController(PeopleContext context)
        {
            _context = context;
        }

        // GET: api/Person/All
        [HttpGet("All")]
        public IEnumerable<Person> GetAll()
        {
            return _context.Persons
                    .Include(p => p.HomeAddress)
                    .Include(p => p.Contracts);
        }

        // GET api/Person/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> Get(int id)
        {
            if(id >= _context.Persons.Count())
            {
                return NotFound();
            }
            else
            {
                return _context.Persons
                                .Include(p => p.HomeAddress)
                                .Include(p => p.Contracts)
                                .Where(p => p.Id == id)
                                .FirstOrDefault();
            }
        }


        [HttpGet("ByEmail/{email}")]
        public ActionResult<IEnumerable<Person>> GetByEmail(string email)
        {
            var query = _context.Persons
                .Where(p => p.Email.ToLower()
                .Contains(email.ToLower()));

            if (query.Count() > 0)
                return query.ToList();
            else
                return NotFound();
        }

        // POST api/Person
        [HttpPost]
        public ActionResult Post(Person value)
        {
            try
            {
                _context.Persons.Add(value);
                _context.SaveChanges();
                return Created($"/api/Person/{value.Id}", value);
            }
            catch (Exception)
            {
                //todo log 
                throw;
            }
            
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, Person value)
        {
            // zpusob 1. - vytahnu osobo z db
            // a menim jeji hodnoty podle toho co prislo (value)
            // (manualne co chci zmenit)
            //var existingPerson = _context.Persons.Find(id);
            //existingPerson.Email = value.Email;
            //existingPerson.FirstName = value.FirstName;
            //existingPerson.LastName = value.LastName;

            //zpusob 2. - nesmim vytahnout osobu z db
            // ale pouze prichozi pripojim k db contextu
            //_context.Entry<Person>(value).State = EntityState.Modified;
            //todo test edit    

            //zpusob 3. - podobny jako 1. ale vsechny property
            // automaticky aktualizuje CurrentValues.SetValues
            var currentEntity = _context.Persons.Find(id);
            
            _context.Entry(currentEntity)
                .CurrentValues.SetValues(value);

            _context.SaveChanges();
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = _context.Persons.Find(id);
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
