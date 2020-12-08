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
        private int taille = 3;

        private char[] tab;
        public TaquinWindow()
        {
            InitializeComponent();
            GenerateCharTab();
            MakeRowsAndCols();
            MakeShuffleButton();
            MakeGrid();

        }

        private void GenerateCharTab()
        {
            tab = new char[taille*taille - 1];
            char c = 'A';
            for(int i=0; i < tab.Length; i++)
            {
                tab[i] = c;
                c++;
            }
        }

        #region methode rendu
        private void MakeShuffleButton()
        {
            Button b = new Button()
            {
                Content = "Melanger"
            };
            b.Click += ShuffleClick;
            grid.Children.Add(b);
            Grid.SetColumn(b,0);
            Grid.SetRow(b,0);
            Grid.SetColumnSpan(b, 4);
        }
        private void MakeRowsAndCols()
        {
            //Création des lignes et des colonnes
            for (int i = 1; i <= taille; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.RowDefinitions.Add(new RowDefinition());
        }
        private void MakeGrid()
        {
            int k = 0;
            for(int i=1; i< taille+1; i++)
            {
                for(int j= 0; j < taille; j++)
                {
                    if(!(j == taille-1 && i == taille))
                    {
                        Button b = new Button()
                        {
                            Content = tab[k]
                        };
                        b.Click += ClickButton;
                        grid.Children.Add(b);
                        Grid.SetRow(b, i);
                        Grid.SetColumn(b, j);
                        k++;
                    }
                }
            }
        }
        #endregion

        #region methode event
        private void ShuffleClick(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            for(int i=0; i < tab.Length; i++)
            {
                int tmpIndex = r.Next(0, tab.Length);
                char tmpChar = tab[i];
                tab[i] = tab[tmpIndex];
                tab[tmpIndex] = tmpChar;
            }
            grid.Children.Clear();
            MakeShuffleButton();
            MakeGrid();
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                int x = Grid.GetRow(b);
                int y = Grid.GetColumn(b);
                if(y < taille - 1 && TestMove(x, y + 1))
                {
                    Grid.SetColumn(b, y + 1);
                }
                else if(y > 0 && TestMove(x, y - 1))
                {
                    Grid.SetColumn(b, y - 1);
                }
                else if(x < taille && TestMove(x + 1, y))
                {
                    Grid.SetRow(b, x + 1);
                }
                else if(x > 1 && TestMove(x - 1, y))
                {
                    Grid.SetRow(b, x - 1);
                }
            }
        }

        private bool TestMove(int x, int y)
        {
            UIElement element = grid.Children.Cast<UIElement>()
                .FirstOrDefault(e => Grid.GetColumn(e) == y && Grid.GetRow(e) == x);
            return element == null;
        }
        #endregion
    }
}
