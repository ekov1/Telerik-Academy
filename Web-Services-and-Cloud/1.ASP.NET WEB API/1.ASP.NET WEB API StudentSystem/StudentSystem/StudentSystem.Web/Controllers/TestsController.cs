﻿namespace StudentSystem.Web.Controllers
{
    using System.Web.Http;

    public class TestsController : ApiController
    {
        public IHttpActionResult Get()
        {

            return this.Ok();
        }

        public IHttpActionResult Get(int id)
        {

            return this.Ok();
        }

        public IHttpActionResult Post(TestResponseModel model)
        {

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {

            return this.Ok();
        }
    }
}