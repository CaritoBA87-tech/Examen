using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Examen.Data.AppDbContext
{
    public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Examen;Trusted_Connection=true");
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=Examen; User Id=User1; Password=admin;Trusted_Connection=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
