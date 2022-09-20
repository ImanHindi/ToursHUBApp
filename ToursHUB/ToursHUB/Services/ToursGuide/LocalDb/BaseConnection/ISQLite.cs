using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToursHUB.Services.ToursGuide.LocalDb.BaseConnection
{
    public interface ISQLite
    {

        SQLiteAsyncConnection GetDbConnection(string DbFileName);
        //string GetCityDbPath(string DbFileName);
        //string GetUserDbPath(string DbFileName);
        //string GetDistinationDbPath(string DbFileName);
        //string GetCountryDbPath(string DbFileName);

    }
}
