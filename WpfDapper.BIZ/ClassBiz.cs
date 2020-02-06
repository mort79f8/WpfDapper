using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfDapper.DAL;
using WpfDapper.Entities;
using WpfDapper.Services;
using WpfDapper.Services.Entities;

namespace WpfDapper.BIZ
{
    public class ClassBiz
    {
        DataAccess db = new DataAccess();
        FilmService filmService = new FilmService() { AppId = "6880371f" };
        
        //public void GetAllMovies(TextBox textBox)
        //{
        //    List<Movie> movies = new List<Movie>();
        //    movies = db.GetAllMovies();
        //    string text = "";
            
        //    foreach (Movie movie in movies)
        //    {
        //        text = text + $"Titel: {movie.Titel} \nLand: {movie.Land} \nÅr: {movie.Year} \nGenre: {movie.Genre} \nOscars: {movie.Oscars} \n\n";
        //    }
            
        //    textBox.Text = text;
        //}

        public List<Movie> GetAllMovies()
        {
            return db.GetAllMovies();            
        }

        public void CreateMovie(string titel, string land, int year, string genre, int oscars)
        {
            db.InsertMovie(titel, land, year, genre, oscars);
        }

        public void UpdateMovie(int id, string titel, string land, int year, string genre, int oscars)
        {
            db.UpdateMovie(id, titel, land, year, genre, oscars);
        }

        public void DeleteMovie(int id, string titel, string land, int year)
        {
            db.DeleteMovie(id, titel, land, year);
        }

        public void GetImage()
        {

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri("HttpS://via.placeholder.com/150.png"), @"d:\test\image.png");
            }

        }

        public Film GetFilm(string titel)
        {
            filmService.Titel = titel;
            return filmService.GetFilmFromApi();
        }
    }
}
