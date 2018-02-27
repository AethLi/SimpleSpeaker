using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Runtime.InteropServices;

namespace SimpleSpeaker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<FileInfo> audio_list = new List<FileInfo>();
            string path = Directory.GetCurrentDirectory();
            path = path + "\\音频库";
            DirectoryInfo the_folder = new DirectoryInfo(path);
            DirectoryInfo[] dirInfo = the_folder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo)
           {
                FileInfo[] fileInfo = NextFolder.GetFiles("*.txt");
                foreach (FileInfo NextFile in fileInfo)
                {
                    audio_list.Add(NextFile);
                }
            }
            foreach(FileInfo f in audio_list)
            {
                Main_list.Items.Add(f);
            }
        }

        private void MenuItem0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_play_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    class Mp3Player
    {
        string filePath = null;

        public string FilePath { get => filePath; set => filePath = value; }
        public void play()
        {
            mciSendString("close all", 0, 0);
        }
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string IpstrCommand, string IpstrReturnString, int uReturnString, int hwndCallback);
    }
}
