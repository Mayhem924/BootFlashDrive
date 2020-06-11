using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Notifications;
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

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        public string GetAppTitleFromSystem()
        {
            return Windows.ApplicationModel.Package.Current.DisplayName;
        }

        private async void RefreshList(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            
            foreach (var localDrive in drives)
            {
                try
                {
                    if (true) // TODO IsReady issue
                    {
                        var drive = new Drive(localDrive);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToastContent content = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
            {
                new AdaptiveText()
                {
                    Text = "Test toast"
                },

                new AdaptiveProgressBar()
                {
                    Title = "Windows ISO Image",
                    Value = 0.5,
                    ValueStringOverride = "50%",
                    Status = "Downloading..."
                }
            }
                    }
                }
            };

            var toast = new ToastNotification(content.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}