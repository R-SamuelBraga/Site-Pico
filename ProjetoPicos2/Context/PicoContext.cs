using Microsoft.EntityFrameworkCore;
using ProjetoPicos2.Models;

namespace ProjetoPicos2.Context
{
    public class PicoContext : DbContext
    {
            public PicoContext(DbContextOptions<PicoContext> options) : base(options)
            {

            }
            public DbSet<Pico> Picos { get; set; }

    }
}
