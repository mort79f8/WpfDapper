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
using WpfDapper.BIZ;
using WpfDapper.Entities;
using WpfDapper.GUI;

namespace WpfDapper
{
    /// <summary>
    /// Interaction logic for UpdateMovie.xaml
    /// </summary>
    public partial class UpdateMovie : Window
    {
        ClassBiz biz = new ClassBiz();
        Movie Movie { get; set; } = new Movie();

        public UpdateMovie()
        {
            InitializeComponent();
        }

        public UpdateMovie(Movie movie) : this()
        {
            Movie = movie;
            DataContext = Movie;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            biz.UpdateMovie(Movie.FilmId, TitelTextBox.Text, LandTextBox.Text, int.Parse(YearTextBox.Text), GenreTextBox.Text, int.Parse(OscarsTextBox.Text));
            TitelTextBox.Text = "";
            LandTextBox.Text = "";
            YearTextBox.Text = "";
            GenreTextBox.Text = "";
            OscarsTextBox.Text = "";
            Close();
        }
    }
}
