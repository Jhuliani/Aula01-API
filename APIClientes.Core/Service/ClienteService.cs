using APIClientes.Core.Interface;
using APIClientes.Core.Model;

namespace APIClientes.Core.Service
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> GetCadastros()
        {
            return _clienteRepository.GetCadastros();
        }
               
        public Cliente GetCadastroCpf(string cpf)
        {
            return _clienteRepository.GetCadastroCpf(cpf);
        }
        public bool PostCadastro(Cliente cliente)
        {
            return _clienteRepository.PostCadastro(cliente);
        }
        public bool PutCadastros(string cpf, Cliente cliente)
        {
            return _clienteRepository.PutCadastros(cpf, cliente);
        }
        public bool DeleteCadastros(string cpf)
        {
            return _clienteRepository.DeleteCadastros(cpf);
        }
    }
}
