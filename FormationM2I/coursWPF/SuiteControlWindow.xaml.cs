using coursWPF.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace coursWPF
{
    /// <summary>
    /// Logique d'interaction pour SuiteControlWindow.xaml
    /// </summary>
    public partial class SuiteControlWindow : Window
    {
        public SuiteControlWindow()
        {
            InitializeComponent();
            List<Personne> personnes = new List<Personne>();
            data.ItemsSource = personnes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "tout fichier|*.*";
            if((bool)fileDialog.ShowDialog())
            {
                MessageBox.Show(fileDialog.FileName);
            }
        }
    }
}
