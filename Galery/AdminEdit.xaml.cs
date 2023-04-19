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
    /// Логика взаимодействия для AdminEdit.xaml
    /// </summary>
    public partial class AdminEdit : Window
    {
        public string CreatorCreator { get; set; }
        public int DateDate { get; set; }
        public string GenreGenre { get; set; }
        public string TimeTime { get; set; }
        public string LocationLocation { get; set; }
        public string MaterialMaterial { get; set; }
        public AdminEdit()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
