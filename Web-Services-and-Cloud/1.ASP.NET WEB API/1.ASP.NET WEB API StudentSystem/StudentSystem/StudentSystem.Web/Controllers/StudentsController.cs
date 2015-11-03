namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Students
                .All()
                .ProjectTo<StudentResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.data.Students
                .SearchFor(x =>
                    x.StudentIdentification == id)
                .FirstOrDefault();

            if (result == null)
            {
                return this.BadRequest("No student with that Id was found!");
            }

            var resultModel = Mapper.Map<StudentResponseModel>(result);

            return this.Ok(resultModel);
        }

        public IHttpActionResult Post([FromBody] StudentResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = Mapper.Map<Student>(model);

            this.data.Students.Add(student);
            this.data.SaveChanges();

            return this.Ok(student.StudentIdentification);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = this.data.Students
                .SearchFor(x =>
                    x.StudentIdentification == id)
                .FirstOrDefault();

            if (result == null)
            {
                return this.BadRequest("No student with that Id was found!");
            }

            this.data.Students.Delete(result);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}