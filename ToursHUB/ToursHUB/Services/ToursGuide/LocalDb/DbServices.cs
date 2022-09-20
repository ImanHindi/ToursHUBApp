using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Extensions;
using ToursHUB.Models;
using ToursHUB.Models.TourMedia;
using ToursHUB.Models.ToursGuide;
using ToursHUB.Models.User;
using ToursHUB.Services.ToursGuide.LocalDb.BaseConnection;
using Xamarin.Forms;

namespace ToursHUB.ToursGuide.Services.LocalDb
{
   public  class DbServices: IDbServices
    {
        public readonly SQLiteAsyncConnection Db;

        public static readonly string FileName = "ToursHUB.db3";

        public DbServices()
        {
            Db = DependencyService.Get<ISQLite>().GetDbConnection(FileName);
            // CreateDbTables(Data);
            // Db = App.ToursHubDb;
           // Db.CreateTableAsync<T>().Wait();
            Db.CreateTableAsync<UserInfo>().Wait();
            Db.CreateTableAsync<Favourite>().Wait();
            Db.CreateTableAsync<MyTrips>().Wait();
            Db.CreateTableAsync<Country>().Wait();
            Db.CreateTableAsync<City>().Wait();
            Db.CreateTableAsync<Distination>().Wait();
            Db.CreateTableAsync<VedioID>().Wait();
            Db.CreateTableAsync<Event>().Wait();
        }

        //public async Task CreateDbTables(T Data)
        //{
        //   await  Db.CreateTableAsync<T>();
        //}
        public async Task<T> GetDataWithChildrenAsync<T>(int id) where T : class,new()
        {
            T result = await Db.GetWithChildrenAsync<T>(id);
            return result;

        }
        public async Task<ObservableCollection<T>> GetAllDataWithChildrenAsync<T>() where T : class, new()
        {
            ObservableCollection<T>  result =  (await  Db.GetAllWithChildrenAsync<T>()).ListToObservableCollection();
            return result;
        }

       
        public async Task AddWithChildrenAsync<T>(T Data)
        {
            await Db.InsertWithChildrenAsync(Data);
        }
        public async Task AddAllWithChildrenAsync<T>(ObservableCollection<T> Data)
        {
            await Db.InsertAllWithChildrenAsync(Data);
        }
        public async Task AddorReplaceAllWithChildrenAsync<T>(ObservableCollection<T> Data)
        {
            await Db.InsertOrReplaceAllWithChildrenAsync(Data);
        }
        public async Task AddWithChildrenAsync<T>(ObservableCollection<T> Data)
        {
            await Db.InsertWithChildrenAsync(Data);
        }
        public async Task UpdateWithChildrenAsync<T>(T Data)
        {
            await Db.UpdateWithChildrenAsync(Data);
        }

        public async Task UpdateAllWithChildrenAsync<T>(ObservableCollection<T> Data)
        {
            await Db.UpdateAllAsync(Data);
        }
      
        public async Task DeleteAllWithChildrenAsync<T>(ObservableCollection<T> Data)
        {
             await Db.DeleteAllAsync(Data);
        }

        public async Task<int> DeleteWithChildrenAsync<T>(T Data)
        {
           return await Db.DeleteAsync(Data);
        }
    }
}
