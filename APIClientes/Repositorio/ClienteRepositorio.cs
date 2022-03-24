using APIClientes.Data;
using APIClientes.Modelo;
using APIClientes.Modelo.DTo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Repositorio
{

    public class ClienteRepositorio : IClienteRepositorio
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ClienteRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ClienteDTo> CreateUpdate(ClienteDTo clienteDTo)
        {
            Cliente cliente = _mapper.Map<ClienteDTo, Cliente>(clienteDTo);

            if (cliente.Id > 0)
            {
                _db.Clientes.Update(cliente);
            }
            else
            {
                await _db.Clientes.AddAsync(cliente);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDTo>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                Cliente cliente = await _db.Clientes.FindAsync(id);
                if (cliente == null) return false;
        
                 _db.Clientes.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ClienteDTo> GetClienteById(int id)
        {
            Cliente cliente = await _db.Clientes.FindAsync(id);

            return _mapper.Map<ClienteDTo>(cliente);
        }

        public async Task<List<ClienteDTo>> GetClientes()
        {
            List<Cliente> lista = await _db.Clientes.ToListAsync();
            
            return _mapper.Map<List<ClienteDTo>>(lista);
        }
    }
}
