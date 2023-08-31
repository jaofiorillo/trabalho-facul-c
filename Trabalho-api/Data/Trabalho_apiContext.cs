using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabalho_api;

namespace Trabalho_api.Data
{
    public class Trabalho_apiContext : DbContext
    {
        public Trabalho_apiContext (DbContextOptions<Trabalho_apiContext> options)
            : base(options)
        {
        }

        public DbSet<Trabalho_api.teste> teste { get; set; } = default!;
    }
}
