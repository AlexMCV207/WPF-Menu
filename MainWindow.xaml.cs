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


        private void plik_show(object sender, MouseEventArgs e)
        {
            btn_plik_wczytaj.Opacity = 100;
            btn_plik_wczytaj.IsEnabled = true;
            btn_plik_zapisz.Opacity = 100;
            btn_plik_zapisz.IsEnabled = true;
        }
        private void plik_hide(object sender, MouseEventArgs e)
        {
            btn_plik_wczytaj.Opacity = 0;
            btn_plik_wczytaj.IsEnabled = false;
            btn_plik_zapisz.Opacity = 0;
            btn_plik_zapisz.IsEnabled = false;
        }
        private void edycja_show(object sender, MouseEventArgs e)
        {
            btn_edycja_dodaj.Opacity = 100;
            btn_edycja_dodaj.IsEnabled = true;
            btn_edycja_usun.Opacity = 100;
            btn_edycja_usun.IsEnabled = true;
        }
        private void edycja_hide(object sender, MouseEventArgs e)
        {
            btn_edycja_dodaj.Opacity = 0;
            btn_edycja_dodaj.IsEnabled = false;
            btn_edycja_usun.Opacity = 0;
            btn_edycja_usun.IsEnabled = false;
        }

        private void btn_oprog_window(object sender, RoutedEventArgs e)
        {
            AboutWindow aW = new AboutWindow();
            aW.Show();
            this.Close();
        }

        private void btn_edycja_dodaj_Click(object sender, RoutedEventArgs e)
        {
            InputWindow iW = new InputWindow();
            iW.Show();
            this.Close();
        }
    }
}