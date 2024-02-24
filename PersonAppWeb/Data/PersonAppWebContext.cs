using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonAppWeb.Models;

namespace PersonAppWeb.Data
{
    public class PersonAppWebContext : DbContext
    {
        public PersonAppWebContext (DbContextOptions<PersonAppWebContext> options)
            : base(options)
        {
        }

        public DbSet<PersonAppWeb.Models.PersonType> PersonType { get; set; } = default!;

        public DbSet<PersonAppWeb.Models.PersonViewModel> PersonViewModel { get; set; } = default!;
    }
}
