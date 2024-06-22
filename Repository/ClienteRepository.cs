using IntegraCliente.Data;
using IntegraCliente.Interfaces;
using IntegraCliente.Model;

namespace IntegraCliente.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApiDataContext _context;
        public ClienteRepository(ApiDataContext context)
        {
            _context = context;
        }

        public bool ClienteExists(long id)
        {
            return _context.Clientes.Any(c => c.Id == id);
        }

        public bool CreateCliente(Cliente cliente)
        {
            _context.Add(cliente);
            return Save();
        }

        public Cliente GetCliente(long id)
        {
            return _context.Clientes.Where(cli => cli.Id == id).FirstOrDefault();
        }
  
        public ICollection<Cliente> GetClientes()
        {
            return _context.Clientes.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true: false;
        }
    }
}
