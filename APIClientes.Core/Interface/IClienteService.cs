using APIClientes.Core.Model;


namespace APIClientes.Core.Interface
{
    public interface IClienteService
    {
        List<Cliente> GetCadastros();        
        public Cliente GetCadastroCpf(string cpf);
        public bool PostCadastro(Cliente cliente);
        public bool PutCadastros(string cpf, Cliente cliente);
        public bool DeleteCadastros(string cpf);     


    }
}
