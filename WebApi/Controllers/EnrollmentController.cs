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
        public List<Enrollment> GetEnrollmentList(ref List<string> errors)
        {
            var repository = new EnrollmentRepository();
            var service = new EnrollmentService(repository);
            return service.GetEnrollmentList(ref errors);
        }
    }
}