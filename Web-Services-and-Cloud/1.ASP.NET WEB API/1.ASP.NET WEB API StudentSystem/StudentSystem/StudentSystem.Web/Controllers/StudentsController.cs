namespace StudentSystem.Web.Controllers
{
    using System.Web.Http;

    public class StudentsController : ApiController
    {
        public IHttpActionResult Get()
        {

            return this.Ok();
        }

        public IHttpActionResult Get(int id)
        {

            return this.Ok();
        }

        public IHttpActionResult Post(StudentResponseModel model)
        {

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {

            return this.Ok();
        }
    }
}