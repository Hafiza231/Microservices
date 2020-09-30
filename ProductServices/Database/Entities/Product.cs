using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Database.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string productname { get; set; }
        public double productprice { get; set; }
    }
}
