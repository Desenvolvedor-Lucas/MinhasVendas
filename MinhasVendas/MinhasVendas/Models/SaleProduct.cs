using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MinhasVendas.Models
{
    public class SaleProduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //Add auto number while update list
        public int NumberList { get; set; }

        public string DateSale { get; set; }

        public string Name { get; set; }
        public string Product { get; set; }

        public int Unit { get; set; }

        public decimal Value { get; set; }
        public decimal TotalValueProduct { get; set; }

        //Add auto informations while update list
        public string SaleInformations { get; set; }
    }
}
