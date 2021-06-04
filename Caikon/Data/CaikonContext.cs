using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caikon.Models;

namespace Caikon.Models
{
    public class CaikonContext : DbContext
    {
        public CaikonContext (DbContextOptions<CaikonContext> options)
            : base(options)
        {
        }

        public DbSet<Caikon.Models.Pessoa> Pessoa { get; set; }

        public DbSet<Caikon.Models.Login> Login { get; set; }
    }
}
