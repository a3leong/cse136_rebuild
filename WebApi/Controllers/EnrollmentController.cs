namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using IRepository;
    using Repository;
    using Service;

    public class EnrollmentController : ApiController
    {
        [HttpGet]
        public List<Enrollment> GetEnrollmentList()
        {
            var repository = new EnrollmentRepository();
            var service = new EnrollmentService(repository);
            var errors = new List<string>();
            return service.GetEnrollmentList(ref errors);
        }
    }
}