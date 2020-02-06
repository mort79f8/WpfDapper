using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDapper.Entities;
using Dapper;
using System.Data;

namespace WpfDapper.DAL
{
    public class DataAccess
    {
        public List<Movie> GetAllMovies()
        {
            // Create a connection to the SQL server
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.CnnVal("FilmInfo")))
            {
                //return connection.Query<Movie>("SELECT * FROM Film").ToList(); // straight up SQL not good... use stored procedures.
                return connection.Query<Movie>("dbo.spFilm_GetAllMovies").ToList();
            } // close the connection again, NOTE: Always remember to close connection to the DB when you are done. 
        }

        public void InsertMovie(string titel, string land, int year, string genre, int oscars)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.CnnVal("FilmInfo")))
            {
                // Movie movie = new Movie { Titel = titel, Land = land, Year = year, Genre = genre, Oscars = oscars };
                List<Movie> movies = new List<Movie>();

                movies.Add(new Movie { Titel = titel, Land = land, Year = year, Genre = genre, Oscars = oscars });

                connection.Execute("dbo.spFilm_InsertMovie @Titel, @Land, @Year, @Genre, @Oscars", movies);
            }
        }

        public void UpdateMovie(int id, string titel, string land, int year, string genre, int oscars)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.CnnVal("FilmInfo")))
            {
                Movie movie = new Movie { FilmId = id, Titel = titel, Land = land, Year = year, Genre = genre, Oscars = oscars };
                List<Movie> movies = new List<Movie>();
                movies.Add(movie);

                connection.Execute("dbo.spFilm_UpdateMovie @FilmId, @Titel, @Land, @Year, @Genre, @Oscars", movies);
            }
        }

        public void DeleteMovie(int id, string titel, string land, int year)
        {
            Movie movie = new Movie { FilmId = id, Titel = titel, Land = land, Year = year };

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(helper.CnnVal("FilmInfo")))
            {
                connection.Execute("dbo.spFilm_DeleteMovie @FilmId, @Titel, @Land, @Year", movie);
            }
        }
    }
}
