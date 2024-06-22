using IntegraCliente.Model;

namespace IntegraCliente.Interfaces
{
    public interface IClienteRepository
    {
        ICollection<Cliente> GetClientes();
        Cliente GetCliente(long id);
        bool ClienteExists(long id);
        bool CreateCliente(Cliente cliente);
        bool Save();
    }
}
