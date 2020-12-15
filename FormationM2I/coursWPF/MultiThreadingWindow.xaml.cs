using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    /// Logique d'interaction pour MultiThreadingWindow.xaml
    /// </summary>
    public partial class MultiThreadingWindow : Window
    {
        public MultiThreadingWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Avec Les objets de type Thread
            //Thread t = new Thread(ActionLongue);
            //t.Start();

            //Avec les objets de type task
            img.Visibility = Visibility.Visible;
            Task t = Task.Run(ActionLongue);
            
            //une task avec un retour
            //Task<string> t = Task.Run(ActionLongueWithReturn);
            //MessageBox.Show(t.Result);
            //Version avec async et await
            //img.Visibility = Visibility.Visible;
            //string result = await Task.Run(ActionLongueWithReturn);
            //img.Visibility = Visibility.Hidden;
            //MessageBox.Show(result);
        }

        private void ActionLongue()
        {
            Thread.Sleep(5000);
            //throw new Exception("Thread Exception");
            //End of task and invoke main thread
            //Application.Current.Dispatcher
            Dispatcher.Invoke(() =>
            {
                img.Visibility = Visibility.Hidden;
            });
            MessageBox.Show("End long task");
        }

        private string ActionLongueWithReturn()
        {
            Thread.Sleep(5000);
            return "Bonjour";
        }
    }
}
