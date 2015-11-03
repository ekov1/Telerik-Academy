namespace StudentSystem.Web
{
    using System.Web.Http;

    using AutoMapper;
    using Models;
    using StudentSystem.Models;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.CreateMap<Course, CourseResponseModel>();
            Mapper.CreateMap<Student, StudentResponseModel>();
            Mapper.CreateMap<Homework, HomeworkResponseModel>();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
