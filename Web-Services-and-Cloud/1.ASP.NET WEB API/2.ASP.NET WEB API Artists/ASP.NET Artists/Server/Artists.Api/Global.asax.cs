namespace Artists.Api
{
    using System.Reflection;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Mapper.CreateMap<Album, AlbumResponseModel>();
            //Mapper.CreateMap<Song, SongResponseModel>();
            //Mapper.CreateMap<Artist, ArtistResponseModel>();

            AutoMapperConfig.RegisterMappings(Assembly.Load(new AssemblyName("Artists.Api")));
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
 