using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasVendas.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //Add auto number while update list
        public int NumberList { get; set; }

        public string CustomerName { get; set; }
    }
}
