namespace TraverseWindowsDir
{
    using System;
    using System.IO;
    using System.Text;

    public static class Startup
    {
        private static string WinDir = "C:\\WINDOWS";
        private static string EndsWith = ".exe";

        public static void Main()
        {
            var sb = new StringBuilder();

            TraverseDirectory(WinDir, sb);

            Console.WriteLine(sb.ToString());
        }

        private static void TraverseDirectory(string path, StringBuilder sb)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    TraverseDirectory(dir, sb);

                    foreach (var file in Directory.GetFiles(dir))
                    {
                        var fileName = Path.GetFileName(file);

                        if (fileName.EndsWith(EndsWith))
                        {
                            sb.AppendLine(file);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
