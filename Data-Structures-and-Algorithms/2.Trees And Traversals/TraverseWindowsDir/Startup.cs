namespace TraverseWindowsDir
{
    using System;
    using System.IO;
    using System.Text;

    public static class Startup
    {
        private static string WinDir = "C:\\WINDOWS";
        private static string TargetEndsWith = ".exe";
        private static long bytesToGigs = 1024*1024*1024;

        public static void Main()
        {
            var sb = new StringBuilder();

            var dirTree = new Folder { Name = WinDir };

            TraverseDirectory(WinDir, sb, dirTree);

            decimal totalSize = GetTotalFileSizeInDir(dirTree, 0) / bytesToGigs;

            Console.WriteLine(sb.ToString());

            Console.WriteLine("\n\rTotal size of all files in the directory " + WinDir + " and its subdirectories is " +  totalSize + "GBs");
            Console.WriteLine("\n\rIt is possible that not all folders and files have been analyzed if access was not provided to certain folders.");
        }

        private static void TraverseDirectory(string path, StringBuilder sb, Folder dirTree)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    var folder = new Folder { Name = dir };

                    dirTree.Folders.Add(folder);

                    TraverseDirectory(dir, sb, folder);

                    foreach (var file in Directory.GetFiles(dir))
                    {
                        var fileName = Path.GetFileName(file);
                        var fileSize = new FileInfo(Path.GetFullPath(file)).Length;

                        dirTree.Files.Add(new FileObject { Name = fileName, Size = fileSize });

                        if (fileName.EndsWith(TargetEndsWith))
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

        private static long GetTotalFileSizeInDir(Folder dir, long currentSize)
        {
            foreach (var file in dir.Files)
            {
                currentSize += file.Size;
            }

            foreach (var folder in dir.Folders)
            {
                currentSize = GetTotalFileSizeInDir(folder, currentSize);
            }

            return currentSize;
        }
    }
}
