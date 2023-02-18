using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Contexts
{
    public class PontualContext : DbContext
    {
        public PontualContext(DbContextOptions<PontualContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
