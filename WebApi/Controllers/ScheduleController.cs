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
        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            var repository = new ScheduleRepository();
            var service = new ScheduleService(repository);
            return service.GetScheduleList(year, quarter, ref errors);
        }        
    }
}