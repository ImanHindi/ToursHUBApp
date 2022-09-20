using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Models;
using ToursHUB.Models.ToursGuide;

namespace ToursHUB.ToursGuide.Services.LocalDb
{
    public interface IDbServices

    {

      //  Task CreateDbTables(T Data);
        Task<ObservableCollection<T>>  GetAllDataWithChildrenAsync<T>() where T : class, new();

        Task<T>  GetDataWithChildrenAsync<T>(int id) where T : class, new();


        Task AddWithChildrenAsync<T>(T Data);

        Task AddAllWithChildrenAsync<T>(ObservableCollection<T> Data);
        Task AddorReplaceAllWithChildrenAsync<T>(ObservableCollection<T> Data);

        Task AddWithChildrenAsync<T>(ObservableCollection<T> Data);

        Task UpdateWithChildrenAsync<T>(T Data);


        Task UpdateAllWithChildrenAsync<T>(ObservableCollection<T> Data);

        Task<int> DeleteWithChildrenAsync<T>(T Data);
        Task DeleteAllWithChildrenAsync<T>(ObservableCollection<T> countriesLocalData);
    }
}
