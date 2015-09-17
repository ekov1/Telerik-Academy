namespace Proxy
{
    public class Program
    {
        public static void Main()
        {
            var chineseProxy = new ChinaWebSurferProxy();

            chineseProxy.Visit("Twitter");
            chineseProxy.Visit("Facebook");
            chineseProxy.Visit("Youtube");
            chineseProxy.Visit("Two Girls One Cup");
            chineseProxy.Visit("Kawaaaaai");
        }
    }
}
