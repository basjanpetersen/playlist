using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace playlistApp.App_Code
{
    public class songmethodsJSON
    {

        public List<Song> GetAllSongs(string file)
        {
            string jsonInput = File.ReadAllText(HttpContext.Current.Server.MapPath(file));
            List<Song> songs = (List<Song>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonInput, typeof(List<Song>));
            return songs;
        }

    }
}

/*    string jsonInput = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~\playlist.json"));
    List<Song> songs = (List<Song>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonInput, typeof(List<Song>));
}*/