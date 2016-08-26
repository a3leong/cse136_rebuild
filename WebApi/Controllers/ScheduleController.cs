namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using IRepository;
    using Repository;
    using Service;

    public class ScheduleController : ApiController
    {
        [HttpGet]
        public List<Schedule> GetScheduleList(string year, string quarter)
        {
            var repository = new ScheduleRepository();
            var service = new ScheduleService(repository);
            var errors = new List<string>();
            return service.GetScheduleList(year, quarter, ref errors);
        }        
    }
}