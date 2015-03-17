using System;

namespace _11.Version
{
    [Version("v. 1.05b", "public release")]
    class VersionTest
    {
        static void Main()
        {
            object[] attr = typeof(VersionTest).GetCustomAttributes(false);

            foreach (var attribute in attr)
            {
                Console.WriteLine((attribute as VersionAttribute).Version);
                Console.WriteLine((attribute as VersionAttribute).Name);
                Console.WriteLine();
            }
        }
    }
}
