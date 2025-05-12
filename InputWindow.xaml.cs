using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy InputWindow.xaml
    /// </summary>
    
    
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
        }
        public bool InputDataReturned = false;
        Color red = Colors.Red;
        Color white = Colors.White;
        Color black = Colors.Black;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            if (u_pesel.Text != "" || u_name.Text != "" || u_sname.Text != "" || u_lname.Text != "" || u_date.Text != "" || u_phone.Text != "" || u_address.Text != "" || u_city.Text != "" || u_postcode.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć to okno?","",MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string dzien = "00";
            string miesiac = "00";
            string rok = "0000";

            bool isPeselFilled = false;
            bool isPeselCorrect = false;
            bool isNameCorrect = false;
            bool isLnameCorrect = false;
            bool isDateCorrect = false;
            bool isAddressCorrect = false;
            bool isCityCorrect = false;
            bool isPostcodeCorrect = false;

            if (u_date.Text != "" && u_date.Text.Length >= 8)
            {
                u_date.Background = new SolidColorBrush(white);
                u_date.Foreground = new SolidColorBrush(black);
                string date = u_date.Text;
                date.Replace(" ", "");
                date.Replace("/", ".");
                if(date.Length == 8)
                {
                    date = date.Substring(0,2) + "." + date.Substring(2,2) + "." + date.Substring(4,4);
                }
                dzien = date.Substring(0, 2);
                miesiac = date.Substring(3, 2);
                rok = date.Substring(6, 4);
                u_date.Text = date;
                isDateCorrect = true;
            } else {
                u_date.Background = new SolidColorBrush(red);
                u_date.Foreground = new SolidColorBrush(white);
                isDateCorrect = false;
            }
            if(u_pesel.Text != "")
            {
                string pesel = u_pesel.Text;
                isPeselFilled = true;
                if(pesel.Length != 11 || int.TryParse(pesel,out _) != false)
                {
                    u_pesel.Background = new SolidColorBrush(red);
                    u_pesel.Foreground = new SolidColorBrush(white);
                    isPeselCorrect = false;
                }
                else
                {
                    int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                    int sumaK = 0;
                    for(int i = 0; i < 10; i++)
                    {
                        sumaK += (pesel[i] * wagi[i]);
                    }
                    sumaK = (10 - (sumaK % 10) % 10);

                    if (int.Parse(rok) > 1799 && int.Parse(rok) < 1900)
                    {
                        miesiac = (int.Parse(miesiac) + 80).ToString();
                    } else if (int.Parse(rok) > 1899 && int.Parse(rok) < 2100)
                    {
                        miesiac = (int.Parse(rok) + 20).ToString();
                    }

                    if (dzien != pesel.Substring(4, 2) && miesiac != pesel.Substring(2, 2) && rok.Substring(2, 2) != pesel.Substring(0, 2) && sumaK.ToString() != pesel.Substring(10,1))
                    {
                        u_pesel.Background = new SolidColorBrush(red);
                        u_pesel.Foreground = new SolidColorBrush(white);
                        isPeselCorrect = false;
                    } else
                    {
                        u_pesel.Background = new SolidColorBrush(white);
                        u_pesel.Foreground = new SolidColorBrush(black);
                        isPeselCorrect = true;
                    }
                }
            } else
            {
                u_pesel.Background = new SolidColorBrush(red);
                u_pesel.Foreground = new SolidColorBrush(white);
                isPeselFilled = false;
            }
            if (u_name.Text != "")
            {
                u_name.Background = new SolidColorBrush(white);
                u_name.Foreground = new SolidColorBrush(black);
                string name = u_name.Text;
                name.Trim();
                name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
                name.Replace(" ", "");
                u_name.Text = name;
                isNameCorrect = true;

            }
            else
            {
                u_name.Background = new SolidColorBrush(red);
                u_name.Foreground = new SolidColorBrush(white);
                isNameCorrect = false;
            }

            if (u_sname.Text != "")
            {
                u_sname.Background = new SolidColorBrush(white);
                u_sname.Foreground = new SolidColorBrush(black);
                string sname = u_sname.Text;
                sname.Trim();
                sname = sname.Substring(0, 1).ToUpper() + sname.Substring(1).ToLower();
                sname.Replace(" ", "");
                u_sname.Text = sname;

            }

            if (u_lname.Text != "")
            {
                u_lname.Background = new SolidColorBrush(white);
                u_lname.Foreground = new SolidColorBrush(black);
                string lname = u_lname.Text;
                lname.Trim();
                lname = lname.Substring(0, 1).ToUpper() + lname.Substring(1).ToLower();
                lname.Replace(" ", "");
                u_lname.Text = lname;
                isLnameCorrect = true;

            }
            else
            {
                u_lname.Background = new SolidColorBrush(red);
                u_lname.Foreground = new SolidColorBrush(white);
                isLnameCorrect = false;
            }

            if (u_phone.Text != "")
            {
                u_phone.Background = new SolidColorBrush(white);
                u_phone.Foreground = new SolidColorBrush(black);
                string phone = u_phone.Text;
                phone.Trim();
                phone.Replace(" ", "");
                if (phone.Length == 9)
                {
                    phone = "+48" + phone;
                }
                u_phone.Text = phone;
            }

            if (u_address.Text != "")
            {
                u_address.Background = new SolidColorBrush(white);
                u_address.Foreground = new SolidColorBrush(black);
                string address = u_address.Text;
                address.Trim();
                address = address.Substring(0, 1).ToUpper() + address.Substring(1).ToLower();
                u_address.Text = address;
                isAddressCorrect = true;
            }
            else
            {
                u_address.Background = new SolidColorBrush(red);
                u_address.Foreground = new SolidColorBrush(white);
                isAddressCorrect = false;
            }

            if (u_city.Text != "")
            {
                u_city.Background = new SolidColorBrush(white);
                u_city.Foreground = new SolidColorBrush(black);
                string city = u_city.Text;
                city.Trim();
                city = city.Substring(0, 1).ToUpper() + city.Substring(1).ToLower();
                u_city.Text = city;
                isCityCorrect = true;
            }
            else
            {
                u_city.Background = new SolidColorBrush(red);
                u_city.Foreground = new SolidColorBrush(white);
                isCityCorrect = false;
            }

            if (u_postcode.Text != "")
            {
                u_postcode.Background = new SolidColorBrush(white);
                u_postcode.Foreground = new SolidColorBrush(black);
                string postcode = u_postcode.Text;
                postcode.Trim();
                u_postcode.Text = postcode;
                isPostcodeCorrect = true;
            }
            else
            {
                u_postcode.Background = new SolidColorBrush(red);
                u_postcode.Foreground = new SolidColorBrush(white);
                isPostcodeCorrect = false;
            }
            if (isPeselFilled == true && isNameCorrect == true && isLnameCorrect == true && isDateCorrect == true && isAddressCorrect == true && isCityCorrect == true && isPostcodeCorrect == true)
            {
                if(isPeselCorrect == true)
                {
                    InputDataReturned = true;
                    this.Close();
                } else
                {
                    MessageBox.Show("Niepoprawny numer pesel!", "Błąd", MessageBoxButton.OK);
                }
                
            }
            else
            {
                MessageBox.Show("Wymagane pola są puste!", "Błąd", MessageBoxButton.OK);
            }
        }
    }
}
