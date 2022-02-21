using BlazorLocalization.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLocalization.Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Guitar> Guitars { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@$"Data Source = Guitars.sqlite");
    }
}
