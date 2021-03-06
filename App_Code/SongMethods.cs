
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace playlistApp.App_Code
{
    public class SongMethods
    {
        public DataSet ds;
                     
        public DataSet GetAllSongs(string filePath)
        {
            ds = new DataSet("playlist");

            DataTable song = new DataTable("song");
            DataColumn ID = new DataColumn("id");
            DataColumn artist = new DataColumn("artist");
            DataColumn title = new DataColumn("title");
            DataColumn year = new DataColumn("year");
            DataColumn album = new DataColumn("album");

            song.Columns.Add(ID);
            song.Columns.Add(artist);
            song.Columns.Add(title);
            song.Columns.Add(album);
            song.Columns.Add(year);
        
            ds.Tables.Add(song);

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

        public int GetNextId()
        {
            DataRow[] drArray = ds.Tables["song"].Select();
            if (drArray != null && drArray.Length > 0)
            {
                int highestId = int.Parse(drArray[drArray.Length - 1]["id"].ToString());
                return highestId + 1;
            }
            else
            {
                return 1;
            }
        }

        public void DeleteSong(string id, string file)
        {
            DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + " ' ");
            if (drArray != null && drArray.Length > 0)
            {
                drArray[0].Delete();
                ds.WriteXml(HttpContext.Current.Server.MapPath(file));
            }
        }

        public DataRow GetSong(string id)
        {
            DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + " ' ");
            if (drArray != null && drArray.Length > 0)
            {
                return drArray[0];
            }
            else
            {
                return null;
            }
        }

        public void WriteSong()
        {
            ds.WriteXml(HttpContext.Current.Server.MapPath(@"~\playlist.xml"));
        }

    }

}
