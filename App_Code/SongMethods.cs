using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace playlistApp.App_Code
{
    public class SongMethods
    {
        //functies en variabelen.
        public DataSet GetAllSongs()
        {
            //structuur die de database in memory kan bevatten.

            DataSet ds = new DataSet("playlist");

            DataTable song = new DataTable("song");

            DataColumn artist = new DataColumn("artist");
            DataColumn title = new DataColumn("title");
            DataColumn album = new DataColumn("album");
            DataColumn year = new DataColumn("year");

            //kolommen in detabel zetten. 

            song.Columns.Add(artist);
            song.Columns.Add(title);
            song.Columns.Add(album);
            song.Columns.Add(year);

            //tabel in de db zetten 
            ds.Tables.Add(song);



            //hier moeten we het bestand playlist.xml inlezen....
            //????


            ds.ReadXml(HttpContext.Current.Server.MapPath("~/playlist.xml"));
            return ds;
        }
    }
    // crud acties komen hieronder. 
}
