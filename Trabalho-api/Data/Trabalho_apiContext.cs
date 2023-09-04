using Microsoft.EntityFrameworkCore;
using Trabalho_api.Models;

namespace Trabalho_api.Data
{
    public class Trabalho_apiContext : DbContext
    {
        public Trabalho_apiContext (DbContextOptions<Trabalho_apiContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> user { get; set; } = default!;
        public DbSet<Endereco> endereco { get; set; } = default!;
        public DbSet<Produto> produto { get; set; } = default!;
        public DbSet<Pedido> pedido { get; set; } = default!;
    }
}
