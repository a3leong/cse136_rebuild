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
        public List<Major> GetMajorList(ref List<string> errors)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            return service.GetMajorList(ref errors);
        }

        [HttpGet]
        public Major GetMajor(string id, ref List<string> errors)
        {
            var repository = new MajorRepository();
            var service = new MajorService(repository);
            return service.GetMajor(id, ref errors);
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
        public string DeleteMajor(string id)
        {
            var errors = new List<string>();
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