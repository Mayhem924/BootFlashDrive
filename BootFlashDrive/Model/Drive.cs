using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootFlashDrive
{
    public class Drive
    {
        public string Title { get; private set; }
        public string Type { get; private set; }
        public string Filesystem { get; private set; }
        public int FreeSpace { get; private set; }

        public Drive(string title, string type, string filesystem, int freeSpace)
        {
            switch (type)
            {
                case "Fixed":
                    Title = "Local drive: " + title;
                    break;
                case "Removable":
                    Title = "USB storage: " + title;
                    break;
            }

            Type = type;
            Filesystem = filesystem;
            FreeSpace = freeSpace;
        }
    }
}
