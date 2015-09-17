using System;
using System.Collections.Generic;

namespace Proxy
{
    public class ChinaWebSurferProxy : IWebSurfer
    {
        private const string AccessDenied = "Access Denied! This website has been blocked by your lovely government!";
        private const string AccessGranted = "Access Granted! Hooooray!";

        private ConcreteWebSurfer surfer = new ConcreteWebSurfer();

        private readonly Dictionary<string, string> sitePermissions = new Dictionary<string, string>()
        {
            {
                "facebook", AccessDenied
            },
            {
                "netflix", AccessDenied
            },
            {
                "twitter", AccessDenied
            },
            {
                "youtube", AccessGranted
            },
            {
                "two girls one cup", AccessGranted
            }
        };
        
        public void Visit(string website)
        {
            if (this.sitePermissions.ContainsKey(website.ToLowerInvariant()))
            {
                this.surfer.Visit(website);
                Console.WriteLine(this.sitePermissions[website.ToLowerInvariant()]);
                Console.WriteLine("~~~\n");
            }
            else
            {
                Console.WriteLine("Le website could not be found on the interwebz!");
            }
        }
    }
}
