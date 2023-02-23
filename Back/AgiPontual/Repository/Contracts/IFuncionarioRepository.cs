using Domain.Entities;

namespace Repository.Contracts
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario[]> GetFuncionariosAsync();
        Task<Funcionario> GetFuncionarioAsync(string filter);
        Task<Funcionario> GetFuncionarioByIdAsync(long id);
    }
}
