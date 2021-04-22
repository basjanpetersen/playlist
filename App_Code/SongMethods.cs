
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace playlistApp.App_Code
{
    public class SongMethods
    {
        DataSet ds = new DataSet("playlist");

                                                                                                     //functies en variabelen.
        public DataSet GetAllSongs(string filePath)
        {
                                                                                                    //structuur die de database in memory kan bevatten.            
            DataTable song = new DataTable("song");
            DataColumn artist = new DataColumn("artist");
            DataColumn title = new DataColumn("title");
            DataColumn year = new DataColumn("year");
            DataColumn album = new DataColumn("album");


                                                                                                     //kolommen in detabel zetten. 

            song.Columns.Add(artist);
            song.Columns.Add(title);
            song.Columns.Add(album);
            song.Columns.Add(year);

                                                                                                     //tabel in de db zetten 
            ds.Tables.Add(song);



                                                                                                      //hier moeten we het bestand playlist.xml inlezen....


            ds.ReadXml(HttpContext.Current.Server.MapPath(filePath));
            return ds;
        }

        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }

        public void CreateSong(DataRow dataRow, string file)
        {
            ds.Tables["song"].Rows.Add(dataRow);
            ds.WriteXml(HttpContext.Current.Server.MapPath(file));
        }

    }
    // crud acties komen hieronder. 
}
