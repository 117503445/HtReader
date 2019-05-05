using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace HtReader
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string dir = "d:\\";
            string fileName = "sample.txt";
            //string fullPath = Path.Combine(dir, fileName);
            try
            {
                StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(dir);
                StorageFile writeFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                CultureInfo culture = new CultureInfo("zh-CN");
                await FileIO.WriteTextAsync(writeFile, DateTime.Now.ToString(culture));
            }
            catch (UnauthorizedAccessException)
            {
                await Launcher.LaunchUriAsync(new Uri("ms-settings:appsfeatures-app"));
            }

        }
    }
}
