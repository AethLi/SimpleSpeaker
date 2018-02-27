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
                FileInfo[] fileInfo = NextFolder.GetFiles("*.mp3");
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
            MP3Player m = new MP3Player();
            m.FilePath = (Main_list.SelectedItem as FileInfo).DirectoryName;
            m.Play();
        }
    }


    public class MP3Player
    {
        /// <summary>   
        /// 文件地址   
        /// </summary>   
        public string FilePath;

        /// <summary>   
        /// 播放   
        /// </summary>   
        public void Play()
        {
            mciSendString("close all", "", 0, 0);
            mciSendString("open " + FilePath + " alias media", "", 0, 0);
            mciSendString("play media", "", 0, 0);
        }

        /// <summary>   
        /// 暂停   
        /// </summary>   
        public void Pause()
        {
            mciSendString("pause media", "", 0, 0);
        }

        /// <summary>   
        /// 停止   
        /// </summary>   
        public void Stop()
        {
            mciSendString("close media", "", 0, 0);
        }

        /// <summary>   
        /// API函数   
        /// </summary>   
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        private static extern int mciSendString(
         string lpstrCommand,
         string lpstrReturnString,
         int uReturnLength,
         int hwndCallback
        );
    }
}
