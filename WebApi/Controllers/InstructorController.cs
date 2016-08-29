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
        public List<Instructor> GetInstructorList()
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            var errors = new List<string>();
            return service.GetInstructorList(ref errors);
        }

        [HttpGet]
        public Instructor GetInstructor(string id)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            var errors = new List<string>();
            return service.GetInstructor(id, ref errors);
        }

        [HttpPost]
        public string InsertInstructor(Instructor Instructor)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            var errors = new List<string>();
            service.InsertInstructor(Instructor, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateInstructor(Instructor Instructor)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            var errors = new List<string>();
            service.UpdateInstructor(Instructor, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteInstructor(string id)
        {
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            var errors = new List<string>();
            service.DeleteInstructor(id, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }
    }
}