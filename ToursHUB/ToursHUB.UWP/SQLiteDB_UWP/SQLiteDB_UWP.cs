using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using ToursHUB.UWP.SQLiteDB_UWP;
using ToursHUB.Services.ToursGuide.LocalDb.BaseConnection;
using Windows.Storage;

[assembly: Dependency(typeof(SQLiteDB_UWP))]

namespace ToursHUB.UWP.SQLiteDB_UWP
{
    public class SQLiteDB_UWP : ISQLite
    {
        //public string _fileName;

        //public SQLiteDB_UWP(string FileName)
        //{
        //    _fileName = FileName;
        //}
        public SQLiteAsyncConnection DbConnection;

        public SQLiteAsyncConnection GetDbConnection(string _fileName)
        {
            string docFolder = ApplicationData.Current.LocalFolder.Path;
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
        //public string GetCityDbPath(string _fileName)
        //{
        //    string docFolder = ApplicationData.Current.LocalFolder.Path;
        //    string dbFolder = Path.Combine(docFolder, "databases");
        //    if (!Directory.Exists(dbFolder))
        //    {
        //        Directory.CreateDirectory(dbFolder);
        //    }
        //    return Path.Combine(dbFolder, _fileName);
        //}

        //public string GetUserDbPath(string _fileName)
        //{
        //    string docFolder = ApplicationData.Current.LocalFolder.Path;
        //    string dbFolder = Path.Combine(docFolder, "databases");
        //    if (!Directory.Exists(dbFolder))
        //    {
        //        Directory.CreateDirectory(dbFolder);
        //    }
        //    return Path.Combine(dbFolder, _fileName);
        //}

        //public string GetPlaceDbPath(string _fileName)
        //{
        //    string docFolder = ApplicationData.Current.LocalFolder.Path;
        //    string dbFolder = Path.Combine(docFolder, "databases");
        //    if (!Directory.Exists(dbFolder))
        //    {
        //        Directory.CreateDirectory(dbFolder);
        //    }
        //    return Path.Combine(dbFolder, _fileName);
        //}

        //public string GetCountryDbPath(string _fileName)
        //{
        //    string docFolder = ApplicationData.Current.LocalFolder.Path;
        //    string dbFolder = Path.Combine(docFolder, "databases");
        //    if (!Directory.Exists(dbFolder))
        //    {
        //        Directory.CreateDirectory(dbFolder);
        //    }
        //    return Path.Combine(dbFolder, _fileName);
        //}
    }
}



