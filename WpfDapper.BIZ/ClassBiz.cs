using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfDapper.DAL;
using WpfDapper.Entities;

namespace WpfDapper.BIZ
{
    public class ClassBiz
    {
        DataAccess db = new DataAccess();
        public void GetAllMovies(TextBox textBox)
        {
            List<Movie> movies = new List<Movie>();
            movies = db.GetAllMovies();
            string text = "";
            
            foreach (Movie movie in movies)
            {
                text = text + $"Titel: {movie.Titel} \nLand: {movie.Land} \nÅr: {movie.Year} \nGenre: {movie.Genre} \nOscars: {movie.Oscars} \n\n";
            }
            
            textBox.Text = text;
        }
    }
}
