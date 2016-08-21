namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using IRepository;
    using Repository;
    using Service;

    public class InstructorController : ApiController
    {
        [HttpGet]
        public Instructor GetInstructor(string id, ref List<string> errors)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            return service.GetInstructor(id, ref errors);
        }

        [HttpPost]
        public string InsertInstructor(Instructor Instructor, ref List<string> errors)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            service.InsertInstructor(Instructor, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateInstructor(Instructor Instructor, ref List<string> errors)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            service.UpdateInstructor(Instructor, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteInstructor(string id, ref List<string> errors)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            service.DeleteInstructor(id, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }
    }
}