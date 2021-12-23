using Plugin.Media.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MinhasVendas.Models
{
    public class Company
    {
        [PrimaryKey]
        public int ID { get; set; }
        //Add auto number while update list
        public string PathFile { get; set; }

        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
    }
}
