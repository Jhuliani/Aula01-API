using Aula01_API.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Aula01_API.Repositories
{


    public class CadastroRepository
    {
        private readonly IConfiguration _configuration;

        public CadastroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cadastro> GetCadastros()
        {
            var query = "SELECT * FROM base854.dbo.clientes";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cadastro>(query).ToList();
        }
        public bool InsertCadastros(Cadastro cadastro)
        {
            var query = "INSERT INTO base854.dbo.clientes VALUES(@cpf, @nome, @dataNascimento, @idade)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cadastro.CPF);
            parameters.Add("nome", cadastro.Nome);
            parameters.Add("dataNascimento", cadastro.Nascimento);
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

        public Cadastro GetCadastroCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new { cpf });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cadastro>(query, parameters);
        }

        public bool PutCadastros(string cpf, Cadastro cadastroNovo)
        {
            var query = "UPDATE base854.dbo.clientes SET cpf=@cpf, nome=@nome, dataNascimento=@dataNascimento, idade=@idade WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("novoCpf", cadastroNovo.CPF);
            parameters.Add("nome", cadastroNovo.Nome);
            parameters.Add("dataNascimento", cadastroNovo.Nascimento);
            parameters.Add("idade", cadastroNovo.Idade);
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;

        }

    }
}
