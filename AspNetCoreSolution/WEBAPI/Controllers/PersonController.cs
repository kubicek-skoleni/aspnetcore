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
