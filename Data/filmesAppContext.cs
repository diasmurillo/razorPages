using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using filmeApp.Models;

namespace filmesApp.Data
{
    public class filmesAppContext : DbContext
    {
        public filmesAppContext (DbContextOptions<filmesAppContext> options)
            : base(options)
        {
        }

        public DbSet<filmeApp.Models.Filme> Filme { get; set; } = default!;
    }
}
