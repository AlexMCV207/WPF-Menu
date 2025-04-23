using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aW = new AboutWindow();
            aW.Show();
            this.Close();
        }

        private void NewRecord_Click(object sender, RoutedEventArgs e)
        {
            InputWindow iW = new InputWindow();
            iW.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
        }
        private void RemoveSel_Click(object sender, RoutedEventArgs e)
        {
            while (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }
    }
}