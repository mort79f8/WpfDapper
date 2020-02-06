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
using WpfDapper.BIZ;
using WpfDapper.Entities;

namespace WpfDapper.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz biz = new ClassBiz();
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public Movie Movie { get; set; } = new Movie();
        
        public MainWindow()
        {
            InitializeComponent();
            Movies = biz.GetAllMovies();
            MovieList.ItemsSource = Movies;
            SearchMovies(TitelSearchBox,"Titel");
        }

        private void CreateMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateMovie createMovie = new CreateMovie();
            createMovie.Owner = this;
            createMovie.Show();
        }

        private void TitelSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MovieList.ItemsSource = movies.Where(f => f.Titel.ToLower().Contains(TitelSearchBox.Text.ToLower())).ToList();
            SearchMovies(TitelSearchBox, "Titel");
        }


        //Methode that gets the property of a film based on a string, then use that to search the list.
        private void SearchMovies(TextBox textBox, string searchType)
        {
            MovieList.ItemsSource = Movies.Where(f => f.GetPropertyValue(searchType).ToLower().Contains(textBox.Text.ToLower())).ToList();
        }

        private void LandSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMovies(LandSearchBox, "Land");
        }

        private void YearSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMovies(YearSearchBox, "Year");
        }

        private void GenreSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMovies(GenreSearchBox, "Genre");
        }

        private void OscarsSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMovies(OscarsSearchBox, "Oscars");
        }



        private void UpdateMovieButton_Click(object sender, RoutedEventArgs e)
        {
            Movie = (Movie)MovieList.SelectedItem;
            UpdateMovie updateMovie = new UpdateMovie(Movie);
            updateMovie.Owner = this;
            updateMovie.Show();

        }

        private void DeleteMovieButton_Click(object sender, RoutedEventArgs e)
        {
            Movie = new Movie();
            Movie = (Movie)MovieList.SelectedItem;
            if (Movie != null)
            {
                if (MessageBox.Show($"Ønsker du og slette {Movie.Titel}?", "Conformation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    biz.DeleteMovie(Movie.FilmId, Movie.Titel, Movie.Land, Movie.Year);
                    Movies = biz.GetAllMovies();
                    MovieList.ItemsSource = Movies;
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Movies = biz.GetAllMovies();
            MovieList.ItemsSource = Movies;
        }
    }
}
