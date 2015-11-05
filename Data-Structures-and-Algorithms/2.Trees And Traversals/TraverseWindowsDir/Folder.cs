namespace TraverseWindowsDir
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder()
        {
            this.Files = new List<FileObject>();
            this.Folders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<FileObject> Files { get; set; }

        public List<Folder> Folders { get; set; }
    }
}
