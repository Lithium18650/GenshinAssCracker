using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Remoting.Channels;
using winform = System.Windows.Forms;

namespace GenshinAssCrack
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\genshin_ass_crack"))
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\genshin_ass_crack\lconfig.cfg"))
                {
                    string data =File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\genshin_ass_crack\lconfig.cfg");
                    entry_path_got.Text = data;
                }
            }
            
        }
        private string root_path;

        private string get_full_path()
        {
            string add = @"\Genshin Impact Game\YuanShen_Data\Persistent\AssetBundles\blocks";
            string full_path = root_path + add;
            return full_path;
        }

        private void write_last_path()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\genshin_ass_crack\lconfig.cfg";
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\genshin_ass_crack"))
            {
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                    sw.Write(root_path);
                    sw.Close();
                }
                else
                {
                    File.Create(path);
                    StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                    sw.Write(root_path);
                    sw.Close();
                }
            }
            else
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\genshin_ass_crack");
                File.Create(path);
                File.Create(path).Close();
                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                sw.Write(root_path);
                sw.Close();
            }
        }

        private void confirm_button_Click(object sender, RoutedEventArgs e)
        {
            root_path = entry_path_got.Text;
            string path = get_full_path();
            if (Directory.Exists(path)==false)
            {
                notice_lable.Content = "无需拯救屁股,或目录错误";
                write_last_path();
            }
            else
            {
                if(Directory.Exists(path + "X") == true)
                {
                    Directory.Delete(path + "X", true);
                }
                notice_lable.Content = "正在拯救屁股！";
                Directory.Move(path,path+"X");
                notice_lable.Content = "已拯救屁股！";
                write_last_path();
            }

        }

        private void quit_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void browse_button_Click(object sender, RoutedEventArgs e)
        {
            winform.FolderBrowserDialog folderBrowserDialog = new winform.FolderBrowserDialog();
            ;
            folderBrowserDialog.Description = "选择游戏根目录";
            if(folderBrowserDialog.ShowDialog()==winform.DialogResult.OK|| folderBrowserDialog.ShowDialog() == winform.DialogResult.Yes)
            {
                entry_path_got.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
