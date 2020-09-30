using Microsoft.EntityFrameworkCore;
using ProductServices.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source= DSK-4104\SQL2019 ;initial catalog=Practice;persist security info=True; 
                                            user id=sa;password=Password12$;");
        }
    }
}
