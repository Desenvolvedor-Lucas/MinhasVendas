using MinhasVendas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasVendas.DataBase
{
    public class CustomersDataBase
    {
        readonly SQLiteAsyncConnection _db;

        public CustomersDataBase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Customer>().Wait();
        }

        public Task<List<Customer>> Get_DB_Customer_Async()
        {
            return _db.Table<Customer>().ToListAsync();
        }

        public Task<int> Save_DB_Customer_Async(Customer name)
        {
            return _db.InsertAsync(name);
        }

        public Task<int> Update_DB_Customer_Asysnc(Customer name)
        {
            return _db.UpdateAsync(name);
        }

        public Task<int> Delete_DB_Customer_Async(Customer name)
        {
            return _db.DeleteAsync<Customer>(name.ID);
        }
    }
}
