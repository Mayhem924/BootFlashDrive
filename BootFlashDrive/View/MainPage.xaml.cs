using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BootFlashDrive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Drive> Drives { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Drives = new List<Drive>();
            RefreshList(this, null);
        }

        private async void RefreshList(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            Random random = new Random();
            
            foreach (var localDrive in drives)
            {
                try
                {
                    if (true) // IsReady issue
                    {
                        //var drive = new Drive(localDrive.Name, localDrive.DriveFormat, localDrive.TotalFreeSpace);
                        var drive = new Drive(localDrive.Name, localDrive.DriveType.ToString(), "NTFS", random.Next(100));
                        Drives.Add(drive);
                        listView.Items.Add(drive); 
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    ContentDialog deleteFileDialog = new ContentDialog()
                    {
                        Title = "Ошибка при доступе к файловой системе",
                        Content = ex.Message,
                        PrimaryButtonText = "Пропустить",
                        SecondaryButtonText = "Завершить"
                    };

                    ContentDialogResult result = await deleteFileDialog.ShowAsync();

                    if (result == ContentDialogResult.Secondary)
                    {
                        break;
                    }
                }
                
            }
        }
    }
}