using Domain.Entities;

namespace Application.Contracts
{
    public interface IFuncionarioService
    {
        Task<Funcionario> AddFuncionario(Funcionario entity);

        Task<bool> DeleteFuncionario(long id);

        Task<Funcionario> UpdateFuncionario(Funcionario entity, long id);

        Task<Funcionario[]> GetFuncionarios();
    }
}
