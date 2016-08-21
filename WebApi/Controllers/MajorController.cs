namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using IRepository;
    using Repository;
    using Service;

    public class MajorController : ApiController
    {
        [HttpGet]
        public Major GetMajor(string id, ref List<string> errors)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            var major = service.GetMajor(id, ref errors);
            if (major == null)
            {
                return null;
            }
            return major;
        }

        [HttpPost]
        public string InsertMajor(Major major, ref List<string> errors)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            service.InsertMajor(major, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateMajor(Major major, ref List<string> errors)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            service.UpdateMajor(major, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteMajor(string id, ref List<string> errors)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            service.DeleteMajor(id, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            return "error";
        }
    }
}