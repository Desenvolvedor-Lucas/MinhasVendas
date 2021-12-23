using MinhasVendas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasVendas.DataBase
{
    public class CompanyDataBase
    {
        readonly SQLiteAsyncConnection _db;

        public CompanyDataBase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Company>().Wait();
        }

        public Task<List<Company>> Get_DB_Company_Async()
        {
            return _db.Table<Company>().ToListAsync();
        }

        public Task<int> Salve_Company_Async(Company company)
        {
            return _db.InsertAsync(company);
        }

        public Task<int> Update_Company_Async(Company company)
        {
            return _db.UpdateAsync(company);
        }

        public Task<int> Delete_DB_Company_Async(Company company)
        {
            return _db.DeleteAsync<Company>(company.ID);
        }

    }
}
