using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace Galery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<PaintOutPut> Paints { get; set; }
        public int SelectedTime { get => selectedTime; set { selectedTime = value; Sort(); } }
        private GalleryContext galleryContext;
        private int selectedTime;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<string> Time { get; set; }
        public string SearchText { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            galleryContext = new GalleryContext();
            Time = galleryContext.Times.Select(a => a.Time1).ToList();
            Time.RemoveAt(Time.Count - 1);
            Time.Add("Все эпохи");
            SelectedTime = Time.Count - 1;
        }
        public void Sort()
        {
            var r = galleryContext.Paints.ToList();
            Paints = new();
            for (int i = 0; i < r.Count; i++)
            {
                Paints.Add(new PaintOutPut
                {
                    Creator = galleryContext.Creators.Where(a =>
                    a.Id == galleryContext.Crosscreatorpaints.Where(a =>
                    a.IdPaint == r[i].Id).Select(a=>
                    a.IdCreator).FirstOrDefault()).FirstOrDefault().Name,
                    Time = r[i].TimeNavigation.Time1,
                    DateOfCreate = r[i].DateOfCreate,
                    Genre = r[i].GenreNavigation.Genre1,
                    Location = r[i].Location,
                    Material = r[i].Material,
                    PhotoPaint = r[i].PhotoPaint,
                    Title = r[i].Title,
                    TimeId = r[i].Time

                });
            }
            if (SelectedTime != Time.Count - 1)
            {
                var times = galleryContext.Times.ToArray();
                int id = times[selectedTime].Id;
                Paints = Paints.Where(a => a.TimeId == id).ToList();
            }
            OnPropertyChanged(nameof(Paints));
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
