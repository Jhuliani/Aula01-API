using Microsoft.Data.SqlClient;
using APIClientes.Core.Model;
using APIClientes.Core.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Aula01_API.Infra.Data.Repositories
{


    public class CadastroRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public CadastroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> GetCadastros()
        {
            var query = "SELECT * FROM base854.dbo.clientes";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cliente>(query).ToList();
        }
        public bool InsertCadastros(Cliente cadastro)
        {
            var query = "INSERT INTO base854.dbo.clientes VALUES(@cpf, @nome, @dataNascimento, @idade)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cadastro.CPF);
            parameters.Add("nome", cadastro.Nome);
            parameters.Add("dataNascimento", cadastro.DataNascimento);
            parameters.Add("idade", cadastro.Idade);
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCadastros(string cpf)
        {
            var query = "DELETE FROM base854.dbo.clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public Cliente GetCadastroCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new { cpf });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

        public bool PutCadastros(string cpf, Cliente cadastroNovo)
        {
            var query = "UPDATE base854.dbo.clientes SET cpf=@cpf, nome=@nome, dataNascimento=@dataNascimento, idade=@idade WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("novoCpf", cadastroNovo.CPF);
            parameters.Add("nome", cadastroNovo.Nome);
            parameters.Add("dataNascimento", cadastroNovo.DataNascimento);
            parameters.Add("idade", cadastroNovo.Idade);
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;

        }

        public bool PostCadastro(Cliente cliente)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";
            DynamicParameters parameters = new(new { cliente.CPF, cliente.Idade, cliente.Nome, cliente.DataNascimento });
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
        }

    }
}
