using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XnesServer.Models
{
    using Microsoft.EntityFrameworkCore;

    public class XnesContext
        : DbContext
    {
        public XnesContext(DbContextOptions options) : base(options) { }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
