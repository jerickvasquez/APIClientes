using APIClientes.Modelo.DTo;

namespace APIClientes.Repositorio
{
    public interface IClienteRepositorio
    {

        Task<List<ClienteDTo>> GetClientes();

        Task<ClienteDTo> GetClienteById(int id);

        Task<ClienteDTo> CreateUpdate(ClienteDTo clienteDTo);

        Task<bool> DeleteClienteById(int id);

    }
}
