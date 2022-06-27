using Data;
using Microsoft.AspNetCore.Mvc;
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
            return _context.Persons;
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
                                .Where(p => p.Id == id)
                                .FirstOrDefault();
            }
        }


        [HttpGet("ByEmail/{email}")]
        public IEnumerable<Person> GetByEmail(string email)
        {
            return Data.DataSet.People
                .Where(p => p.Email.ToLower().Contains(email.ToLower()));
        }

        // POST api/Person
        [HttpPost]
        public void Post(Person value)
        {
            Data.DataSet.People.Add(value);
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, Person value)
        {
            Data.DataSet.People.RemoveAt(id);
            Data.DataSet.People.Insert(id, value);
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Data.DataSet.People.RemoveAt(id);
        }
    }
}
