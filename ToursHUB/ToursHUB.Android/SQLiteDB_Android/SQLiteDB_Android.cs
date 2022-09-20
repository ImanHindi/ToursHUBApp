using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ToursHUB.Droid.SQLiteDB_Android;
using Xamarin.Forms;
using System.IO;
using Environment = System.Environment;
using SQLite;
using ToursHUB.Services.ToursGuide.LocalDb.BaseConnection;

[assembly: Dependency(typeof(SQLiteDB_Android))]
namespace ToursHUB.Droid.SQLiteDB_Android
{
    class SQLiteDB_Android : ISQLite
    {
        public  SQLiteAsyncConnection DbConnection;
        public SQLiteAsyncConnection GetDbConnection(string _fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbFolder = Path.Combine(docFolder, "databases");
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }
            //return Path.Combine(dbFolder, _fileName);
            string FileDbPath= Path.Combine(dbFolder, _fileName);
            DbConnection = new SQLiteAsyncConnection(FileDbPath);
            return DbConnection;
        }
        //public string _fileName;

        //public SQLiteDB_Android(string FileName)
        //{
        //    _fileName = FileName;
        //}

        //public string _UserFile= "User.db3";
        //public string _CountryFile = "Country.db3";
        //public string _CityFile = "City.db3";
        //public string _DistinationFile = "Distination.db3";

        //public string GetDistinationDbPath(string _fileName)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string dbFolder = Path.Combine(docFolder, "databases");
        //    if (!Directory.Exists(dbFolder))
        //    {
        //        Directory.CreateDirectory(dbFolder);
        //    }
        //    return Path.Combine(dbFolder, _fileName);
        //}
        //public string GetCityDbPath(string _fileName)
        //    {
        //        string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //        string dbFolder = Path.Combine(docFolder, "database");
        //        if (!Directory.Exists(dbFolder))
        //        {
        //            Directory.CreateDirectory(dbFolder);
        //        }
        //        return Path.Combine(dbFolder, _fileName);
        //    }

        //    public string GetUserDbPath(string _fileName)
        //    {
        //        string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //        string dbFolder = Path.Combine(docFolder, "databases");
        //        if (!Directory.Exists(dbFolder))
        //        {
        //            Directory.CreateDirectory(dbFolder);
        //        }
        //        return Path.Combine(dbFolder, _fileName);
        //    }
        //public string GetCountryDbPath(string _fileName)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string dbFolder = Path.Combine(docFolder, "databases");
        //    if (!Directory.Exists(dbFolder))
        //    {
        //        Directory.CreateDirectory(dbFolder);
        //    }
        //    return Path.Combine(dbFolder, _fileName);
        //}
    }
    
}