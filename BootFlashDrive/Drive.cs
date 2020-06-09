using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootFlashDrive
{
    public class Drive
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Filesystem { get; set; }
        public int FreeSpace { get; set; }

        public Drive(string title, string type, string filesystem, int freeSpace)
        {
            Title = title;
            Type = type;
            Filesystem = filesystem;
            FreeSpace = freeSpace;
        }
    }
}
