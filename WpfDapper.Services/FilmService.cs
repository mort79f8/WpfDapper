using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfDapper.Services.Entities;

namespace WpfDapper.Services
{
    public class FilmService
    {
        private const string api = "http://www.omdbapi.com/?";
        public string Titel { get; set; }
        public string AppId { get; set; }
        public string Url
        {
            get
            {
                return $"{api}apikey={AppId}&t={Titel}";
            }
        }

        public Film GetFilmFromApi()
        {
            using(WebClient client = new WebClient())
            {
                string json = client.DownloadString(Url);
                return JsonConvert.DeserializeObject<Film>(json);
            }
        }

    }
}
