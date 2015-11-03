namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        public CoursesController()
            :this(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Courses
                .All()
                .ProjectTo<CourseResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(string id)
        {
            var result = this.data.Courses
                .SearchFor(x => 
                    x.Id.ToString().ToLowerInvariant() == id.ToLowerInvariant())
                .FirstOrDefault();

            if (result == null)
            {
                return this.BadRequest("No course with that Id was found!");
            }

            var resultModel = Mapper.Map<CourseResponseModel>(result);

            return this.Ok(resultModel);
        }

        public IHttpActionResult Post([FromBody] CourseResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var courseToAdd = Mapper.Map<Course>(model);

            this.data.Courses.Add(courseToAdd);
            this.data.SaveChanges();

            return this.Ok(courseToAdd.Id);
        }

        public IHttpActionResult Delete(string id)
        {
            var result = this.data.Courses
                .SearchFor(x =>
                    x.Id.ToString().ToLowerInvariant() == id.ToLowerInvariant())
                .FirstOrDefault();

            if (result == null)
            {
                return this.BadRequest("No course with that Id was found!");
            }

            this.data.Courses.Delete(result);
            this.data.SaveChanges();

            return this.Ok(result);
        }
    }
}