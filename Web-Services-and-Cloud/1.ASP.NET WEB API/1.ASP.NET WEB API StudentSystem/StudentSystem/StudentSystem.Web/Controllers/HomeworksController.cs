namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    public class HomeworksController : ApiController
    {
        private IStudentSystemData data;

        public HomeworksController(IStudentSystemData data)
        {
            this.data = data;
        }

        public HomeworksController()
            : this(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Homeworks
                .All()
                .ProjectTo<HomeworkResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.data.Homeworks
                .SearchFor(x =>
                    x.Id == id)
                .FirstOrDefault();

            if (result == null)
            {
                return this.BadRequest("No homework with that Id was found!");
            }

            var resultModel = Mapper.Map<HomeworkResponseModel>(result);

            return this.Ok(resultModel);
        }

        public IHttpActionResult Post([FromBody] HomeworkResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var homeworkToAdd = Mapper.Map<Homework>(model);

            this.data.Homeworks.Add(homeworkToAdd);
            this.data.SaveChanges();

            return this.Ok(homeworkToAdd.Id);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = this.data.Homeworks
                .SearchFor(x =>
                    x.Id == id)
                .FirstOrDefault();

            if (result == null)
            {
                return this.BadRequest("No homework with that Id was found!");
            }

            this.data.Homeworks.Delete(result);
            this.data.SaveChanges();

            return this.Ok(result);
        }
    }
}