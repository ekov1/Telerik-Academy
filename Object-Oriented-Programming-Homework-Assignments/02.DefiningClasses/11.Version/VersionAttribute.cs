using System;

namespace _11.Version
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
    AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]

    public class VersionAttribute : Attribute
    {
        private string version;
        private string name;

        public VersionAttribute(string version, string name)
        {
            this.Version = version;
            this.Name = name;
        }

        public string Version 
        {
            get { return this.version; }
            private set { this.version = value; }
        }
        public string Name {
            get { return this.name; }
            private set { this.name = value; }
        }


    }
}
