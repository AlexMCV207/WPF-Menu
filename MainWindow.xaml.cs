﻿using System.Text;
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
    class Osoba
    {
        public string? u_pesel { get; set; }
    public string? u_name { get; set; }
    public string? u_sname { get; set; }
    public string? u_lname { get; set; }
    public string? u_date { get; set; }
    public string? u_phone { get; set; }
    public string? u_address { get; set; }
    public string? u_city { get; set; }
    public string? u_postcode { get; set; }
    }
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
            iW.ShowDialog();
            if(iW.InputDataReturned == true)
            {
                Osoba uczen = new();
                uczen.u_pesel = iW.u_pesel.Text;
                uczen.u_name = iW.u_name.Text;
                uczen.u_sname = iW.u_sname.Text;
                uczen.u_lname = iW.u_lname.Text;
                uczen.u_date = iW.u_date.Text;
                uczen.u_phone = iW.u_phone.Text;
                uczen.u_address = iW.u_address.Text;
                uczen.u_city = iW.u_city.Text;
                uczen.u_postcode = iW.u_postcode.Text;
                listView.Items.Add(uczen);
            }

            
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            openFileDialog.Title = "Otwórz plik CSV";
            if (openFileDialog.ShowDialog() == true)
            {
                listView.Items.Clear();
                string filePath = openFileDialog.FileName;
                int selectedFilterIndex = openFileDialog.FilterIndex;
                string delimiter = ";";
                if (selectedFilterIndex == 1)
                {
                    delimiter = ",";
                }
                Encoding encoding = Encoding.UTF8;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath, encoding);
                    foreach (var line in lines)
                    {
                        string[] columns = line.Split(delimiter);
                        if (columns != null)
                        {
                            Osoba uczen = new();
                            uczen.u_pesel = columns.ElementAtOrDefault(0);
                            uczen.u_name = columns.ElementAtOrDefault(1);
                            uczen.u_sname = columns.ElementAtOrDefault(2);
                            uczen.u_lname = columns.ElementAtOrDefault(3);
                            uczen.u_date = columns.ElementAtOrDefault(4);
                            uczen.u_phone = columns.ElementAtOrDefault(5);
                            uczen.u_address = columns.ElementAtOrDefault(6);
                            uczen.u_city = columns.ElementAtOrDefault(7);
                            uczen.u_postcode = columns.ElementAtOrDefault(8);
                            listView.Items.Add(uczen);
                        }
                    }
                }
            }

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string delimiter = ";";
                if (saveFileDialog.FilterIndex == 1)
                {
                    delimiter = ",";
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Osoba item in listView.Items)
                    {
                        var row = $"{item.u_pesel}{delimiter}{item.u_name}{delimiter}{item.u_sname}{delimiter}{item.u_lname}{delimiter}{item.u_date}{delimiter}{item.u_phone}{delimiter}{item.u_address}{delimiter}{item.u_city}{delimiter}{item.u_postcode}";
                        writer.WriteLine(row);
                    }
                }
            }
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