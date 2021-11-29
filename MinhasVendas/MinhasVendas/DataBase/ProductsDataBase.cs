using MinhasVendas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasVendas.DataBase
{
    public class ProductsDataBase
    {
        readonly SQLiteAsyncConnection _db;

        public ProductsDataBase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Product>> Get_DB_Product_Async()
        {
            return _db.Table<Product>().ToListAsync();
        }

        public Task<int> Save_DB_Product_Async(Product product)
        {
            return _db.InsertAsync(product);
        }

        public Task<int> Update_DB_Product_Asysnc(Product product)
        {
            return _db.UpdateAsync(product);
        }

        public Task<int> Delete_DB_Product_Async(Product product)
        {
            return _db.DeleteAsync<Product>(product.ID);
        }
    }
}
