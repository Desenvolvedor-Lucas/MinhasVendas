using MinhasVendas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasVendas.DataBase
{
    public class SaleDataBase
    {
        readonly SQLiteAsyncConnection _db;

        public SaleDataBase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<SaleProduct>().Wait();
        }

        public Task<List<SaleProduct>> Get_DB_SaleProduct_Async()
        {
            return _db.Table<SaleProduct>().ToListAsync();
        }

        public Task<int> Save_DB_SaleProduct_Async(SaleProduct product)
        {
            return _db.InsertAsync(product);
        }

        public Task<int> Update_DB_SaleProduct_Asysnc(SaleProduct product)
        {
            return _db.UpdateAsync(product);
        }

        public Task<int> Delete_DB_SaleProduct_Async(SaleProduct product)
        {
            return _db.DeleteAsync<SaleProduct>(product.ID);
        }
    }
}
