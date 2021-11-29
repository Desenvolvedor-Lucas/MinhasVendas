using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasVendas.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //Add auto number while update list
        public int NumberList { get; set; }

        public string ProductName { get; set; }
        public string ProductMoney { get; set; }

        private decimal value;
        public decimal ProductValue 
        {
            get { return value; } 
            set 
            { 
                this.value = value; 
                ProductMoney = this.value.ToString("C"); 
            }
        }
    }
}
