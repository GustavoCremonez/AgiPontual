using Application.Contracts;
using Domain.Entities;
using Repository.Contracts;

namespace Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IGeralRepository _geralRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IGeralRepository geralRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _geralRepository = geralRepository;
        }

        public async Task<Funcionario[]> GetFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioRepository.GetFuncionariosAsync();

                if (funcionarios == null) throw new Exception("Funcionarios não encontrados.");

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcionario> AddFuncionario(Funcionario entity)
        {
            try
            {
                _geralRepository.Add<Funcionario>(entity);

                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _funcionarioRepository.GetFuncionarioByIdAsync(entity.Id);
                }

                throw new Exception("Funcionario não encontrado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Funcionario> UpdateFuncionario(Funcionario entity, long id)
        {
            try
            {
                var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(id);

                if (funcionario == null) throw new Exception("Funcionario não encontrado.");

                _geralRepository.Update(funcionario);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return entity;
                }

                throw new Exception("Funcionario não encontrado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFuncionario(long id)
        {
            try
            {
                var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(id);
                if (funcionario == null) throw new Exception("Funcionario não encontrado.");

                _geralRepository.Delete(funcionario);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
