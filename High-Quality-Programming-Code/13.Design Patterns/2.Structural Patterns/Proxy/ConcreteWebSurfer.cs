using System;

namespace Proxy
{
    public class ConcreteWebSurfer : IWebSurfer
    {
        public void Visit(string webSite)
        {
            Console.WriteLine("Opening up website - " + webSite);
        }
    }
}
