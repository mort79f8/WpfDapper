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
        List<Movie> movies { get; set; } = new List<Movie>();
        
        public MainWindow()
        {
            InitializeComponent();
            movies = biz.GetAllMovies();
            MovieList.ItemsSource = movies;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //biz.GetAllMovies(SearchResultTextBox);
        }

        private void CreateMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateMovie createMovie = new CreateMovie();
            createMovie.Owner = this;
            createMovie.Show();
        }

        private void TitelSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MovieList.ItemsSource = movies.Where(f => f.Titel.ToLower().Contains(TitelSearchBox.Text.ToLower())).ToList();
        }

        private void SearchMovies(TextBox textBox, string searchType)
        {
            MovieList.ItemsSource = movies.Where(f => f.searchType.Tolower().Contains(TitelSearchBox.Text.ToLower())).ToList();
        }
    }
}
