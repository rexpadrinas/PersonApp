using Microsoft.EntityFrameworkCore;
using PersonApp.Model;
using System;

namespace PersonApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }

    }
}
