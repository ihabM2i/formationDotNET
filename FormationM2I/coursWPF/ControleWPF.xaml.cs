using coursWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace coursWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControleWPF : Window
    {
        private ObservableCollection<Personne> personnes;
        public ControleWPF()
        {
            InitializeComponent();
            personnes = new ObservableCollection<Personne>();
            listePersonnes.ItemsSource = personnes;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Personne p = new Personne()
            {
                Nom = textNom.Text,
                Prenom = textPrenom.Text
            };
            personnes.Add(p);
        }
    }
}
