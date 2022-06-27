using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController()
        {
            Data.DataSet.LoadFromXML(@"C:\Users\StudentEN\source\repos\kubicek-skoleni\aspnetcore\dataset.xml");
        }

        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return Data.DataSet.People;
        }

        // GET api/Person/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return Data.DataSet.People[id];
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
