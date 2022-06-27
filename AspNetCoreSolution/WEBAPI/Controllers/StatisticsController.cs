using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        public StatisticsController()
        {
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

    }
}
