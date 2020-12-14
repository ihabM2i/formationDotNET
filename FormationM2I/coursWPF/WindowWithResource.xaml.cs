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
    /// Logique d'interaction pour WindowWithRessource.xaml
    /// </summary>
    public partial class WindowWithResource : Window
    {
        public WindowWithResource()
        {
            InitializeComponent();
            Style style = new Style(typeof(Button));
            Setter s1 = new Setter()
            {
                Property = Button.BackgroundProperty,
                Value = new SolidColorBrush(Colors.Red)
            };
            Setter s2 = new Setter()
            {
                Property = Button.FontSizeProperty,
                Value = 20.0
            };
            style.Setters.Add(s1);
            style.Setters.Add(s2);
            Resources.Add("styleEnCSharp", style);
            b4.Style = (Style)Resources["styleEnCSharp"];
        }
    }
}
