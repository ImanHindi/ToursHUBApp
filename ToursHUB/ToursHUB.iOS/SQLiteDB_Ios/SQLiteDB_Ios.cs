using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ToursHUB.iOS.SQLiteDB_Ios;
using Xamarin.Forms;
using SQLite;
using ToursHUB.Services.ToursGuide.LocalDb.BaseConnection;

[assembly: Dependency(typeof(SQLiteDB_Ios))]
namespace ToursHUB.iOS.SQLiteDB_Ios
{
  public  class SQLiteDB_Ios : ISQLite
    {
        public SQLiteAsyncConnection DbConnection;

        public SQLiteAsyncConnection GetDbConnection(string _fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbFolder = Path.Combine(docFolder, "databases");
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }
            //return Path.Combine(dbFolder, _fileName);
            string FileDbPath = Path.Combine(dbFolder, _fileName);
            DbConnection = new SQLiteAsyncConnection(FileDbPath);
            return DbConnection;
        }

        //public string _fileName;
        //public SQLiteDB_Ios(string FileName)
        //{
        //    _fileName = FileName;
        //}


        //public string GetCityDbPath(string _fileName)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //     string libFolder= Path.Combine(docFolder,"..","Library","Databases");
        //    if (!Directory.Exists(libFolder))
        //    {
        //        Directory.CreateDirectory(libFolder);
        //    }
        //    return Path.Combine(libFolder, _fileName);
        //}

        //public string GetUserDbPath(string _fileName)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
        //    if (!Directory.Exists(libFolder))
        //    {
        //        Directory.CreateDirectory(libFolder);
        //    }
        //    return Path.Combine(libFolder, _fileName);
        //}
        //public string GetCountryDbPath(string _fileName)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
        //    if (!Directory.Exists(libFolder))
        //    {
        //        Directory.CreateDirectory(libFolder);
        //    }
        //    return Path.Combine(libFolder, _fileName);
        //}
        //public string GetDistinationDbPath(string _fileName)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
        //    if (!Directory.Exists(libFolder))
        //    {
        //        Directory.CreateDirectory(libFolder);
        //    }
        //    return Path.Combine(libFolder, _fileName);
        //}
    }
}
