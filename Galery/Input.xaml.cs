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

namespace Galery
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Input()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void buttonAuth(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonSignIn(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow();
            mv.Show();
            Close();
        }
    }
}
