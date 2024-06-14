using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MyDbContext
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { // asignar el nombre de la base de datos
            optionsBuilder.UseSqlServer("Server=JOSEPABLOSG\\SQLEXPRESS;Database=;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        // crear los dbset o tablas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // asignar las llaves primarias y foraneas ademas de las relaciones
        }
    }
}
