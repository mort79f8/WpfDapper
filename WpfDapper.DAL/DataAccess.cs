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

        public Movie GetMovieByTitle(string titel)
        {
            throw new NotImplementedException();
        }
    }
}
