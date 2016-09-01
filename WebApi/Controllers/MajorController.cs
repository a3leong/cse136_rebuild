namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Diagnostics;
    using POCO;
    using IRepository;
    using Repository;
    using Service;

    public class MajorController : ApiController
    {
        [HttpGet]
        public Major GetMajor(string id)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            var major = service.GetMajor(id, ref errors);
            if (major == null)
            {
                return null;
            }
            return major;
        }

        [HttpGet]
        public List<Major> GetMajorList()
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            List<Major> majorList = service.GetMajorList(ref errors);
            if (errors.Count!=0 || majorList.Count==0)
            {
                return null;
            }
            return majorList;
        }

        [HttpGet]
        public List<Course> GetMajorRequirements(string id)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            var courseList = service.GetMajorRequirements(id, ref errors);
            if (courseList == null || errors.Count!=0)
            {
                return null;
            }
            return courseList;
        }

        [HttpPost]
        public string InsertMajor(Major major)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            service.InsertMajor(major, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }

        [HttpPost]
        public string UpdateMajor(Major major)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            service.UpdateMajor(major, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteMajor(string id)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            service.DeleteMajor(id, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }

        [HttpPost]
        public string InsertRequirement(string major_id, string course_id)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            service.InsertRequirement(major_id, course_id, ref errors);
            if(errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteRequirement(string major_id, string course_id)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var errors = new List<string>();
            service.DeleteRequirement(major_id, course_id, ref errors);
            if(errors.Count == 0)
            {
                return "ok";
            }
            Debug.WriteLine(errors[0]);

            return "error";
        }
    }
}