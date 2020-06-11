using System;
using System.Collections.Generic;
using System.IO;
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
        public long FreeSpace { get; private set; }

        public Drive(DriveInfo drive)
        {
            switch (drive.DriveType.ToString())
            {
                case "Fixed":
                    Title = "Local drive: " + drive.Name;
                    break;
                case "Removable":
                    Title = "USB storage: " + drive.Name;
                    break;
            }

            Type = drive.DriveType.ToString();
            Filesystem = "NTFS";

            Random rand = new Random();
            FreeSpace = rand.Next(100);
        }
    }
}
