using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.APIResultTypes;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly PeopleContext _context;
        public StatisticsController(PeopleContext context)
        {
            _context = context;
            Data.DataSet.LoadFromXML(@"C:\Users\StudentEN\source\repos\kubicek-skoleni\aspnetcore\dataset.xml");
        }

        [Route("People/All")]
        [Route("People")]
        [Route("/People")]
        [HttpGet]
        public int PeopleCount()
        {
            return Data.DataSet.People.Count();
        }

        [HttpGet("People/WithContract")]
        public int PeopleWithContract()
        {
            return Data.DataSet.People
                        .Where(p => p.Contracts.Count() > 0)
                        .Count();
        }


        [HttpGet("Contracts/Active")]
        public int ContractsCount()
        {
            // pocet vsech aktivnich smluv
            //int cnt = 0;

            //foreach(var person in Data.DataSet.People)
            //{
            //    cnt += person.Contracts
            //        .Where(c => c.IsActive)
            //        .Count();
            //}

            return Data.DataSet.People
                .SelectMany(p => p.Contracts)
                .Where(c => c.IsActive)
                .Count();

            //return cnt;
        }

        // lidi kteri jsou v danem meste 
        [HttpGet("People/City/{city}")]
        public List<Person> GetPeopleByCity(string city)
        {
            return _context.Persons
                .Include(p => p.HomeAddress)
                .Where(p => p.HomeAddress.City.ToLower() == city.ToLower())
                .ToList();
        }

        [HttpGet("Emails/City/{city}")]
        public List<string> GetEmailsByCity(string city)
        {
            return _context.Persons
                .Include(p => p.HomeAddress)
                .Where(p => p.HomeAddress.City.ToLower() == city.ToLower())
                //.Select(p => new { p.Email, p.FirstName, p.LastName }) //anonymni typ
                .Select(p => p.Email)
                .ToList();


            //foreach(var emailName in emailWithNames)
            //{
            //    var firstname = emailName.FirstName;
            //}

        }



        [HttpGet("Cities")]
        public IEnumerable<CityPoepleCount> CityPeopleCount()
        {
            return _context.Persons
                .Include(x => x.HomeAddress)
                .ToList()
                .GroupBy(p => p.HomeAddress.City)
                .ToList()
                .Select(g => new CityPoepleCount() { City = g.Key, PeopleCount = g.Count() });
        }

    }
}
