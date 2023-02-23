using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly PontualContext _context;

        public FuncionarioRepository(PontualContext context)
        {
            _context = context;
        }

        public async Task<Funcionario[]> GetFuncionariosAsync()
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioByIdAsync(long id)
        {
            IQueryable<Funcionario> query = _context.Funcionarios.Where(x => x.Id == id);

            query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public Task<Funcionario> GetFuncionarioAsync(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
