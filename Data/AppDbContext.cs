using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualProgBeadandoGyak.Models;

namespace VisualProgBeadandoGyak.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-UPL8QRD\SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
