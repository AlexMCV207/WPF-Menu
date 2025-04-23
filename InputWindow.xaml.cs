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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy InputWindow.xaml
    /// </summary>
    
    class Osoba
    {
        public string? u_pesel { get; set; }
        public string? u_name { get; set; }
        public string? u_sname { get; set; }
        public string? u_lname { get; set; }
        public string? u_date { get; set; }
        public string? u_phone { get; set; }
        public string? u_adress { get; set; }
        public string? u_city { get; set; }
        public string? u_postcode { get; set; }
    }
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
        }
        Osoba os = new Osoba();

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            os.u_pesel = u_pesel.Text;
            os.u_name = u_name.Text;
            os.u_sname = u_sname.Text;
            os.u_lname = u_lname.Text;
            os.u_date = u_date.Text;
            os.u_phone = u_phone.Text;
            os.u_adress = u_adress.Text;
            os.u_city = u_city.Text;
            os.u_postcode = u_postcode.Text;

            if (os.u_pesel != "" || os.u_name != "" || os.u_sname != "" || os.u_lname != "" || os.u_date != "" || os.u_phone != "" || os.u_adress != "" || os.u_city != "" || os.u_postcode != "")
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć to okno?","",MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MainWindow mW = new MainWindow();
                    mW.Show();
                    this.Close();
                }
            }
            else
            {
                MainWindow mW = new MainWindow();
                mW.Show();
                this.Close();
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            os.u_pesel = u_pesel.Text;
            os.u_name = u_name.Text;
            os.u_sname = u_sname.Text;
            os.u_lname = u_lname.Text;
            os.u_date = u_date.Text;
            os.u_phone = u_phone.Text;
            os.u_adress = u_adress.Text;
            os.u_city = u_city.Text;
            os.u_postcode = u_postcode.Text;

            if(os.u_pesel != "" && os.u_name != "" && os.u_lname != "" && os.u_date != "" && os.u_adress != "" && os.u_city != "" && os.u_postcode != "")
            {
                
            }
            else
            {
                MessageBox.Show("Wymagane pola są puste!", "Błąd", MessageBoxButton.OK);
            }
        }
    }
}
