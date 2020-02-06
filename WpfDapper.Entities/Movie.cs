using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDapper.Entities
{
    public class Movie
    {
        public int FilmId { get; set; }
        public string Titel { get; set; }
        public string Land { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Oscars { get; set; }

        public string GetPropertyValue(string propertyName)
        {
            try
            {
                return $"{this.GetType().GetProperty(propertyName).GetValue(this, null)}";
            }
            catch { return null; }
        }
    }
}
