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

namespace coursWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TaquinWindow : Window
    {
        private int taille = 4;
        public TaquinWindow()
        {
            InitializeComponent();
            MakeGrid();

        }


        private void MakeGrid()
        {
            //Création des lignes et des colonnes
            for(int i=1; i <= taille;i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            char c = 'A';
            for(int i=0; i< taille; i++)
            {
                for(int j= 0; j < taille; j++)
                {
                    if(!(j == taille-1 && i == taille -1))
                    {
                        Button b = new Button()
                        {
                            Content = c
                        };
                        grid.Children.Add(b);
                        Grid.SetRow(b, i);
                        Grid.SetColumn(b, j);
                        c++;
                    }
                }
            }
        }
       
    }
}
