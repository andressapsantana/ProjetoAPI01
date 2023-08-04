using Dapper;
using ProjetoAPI01.Repository.Entities;
using ProjetoAPI01.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI01.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionstring;
        public ClienteRepository (string  connectionstring)
        {
            _connectionstring = connectionstring;
        }

       public void Create(Cliente obj)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute("SP_INSERIRCLIENTE",
                    new
                    {
                        @NOME = obj.Nome,
                        @EMAIL = obj.Email
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Cliente obj)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute("SP_ALTERARCLIENTE",
                    new
                    {
                        @IDCLIENTE = obj.IdCliente,
                        @NOME = obj.Nome,
                        @EMAIL = obj.Email
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Cliente obj)
        {
           using (var connection =new SqlConnection(_connectionstring)) 
            {
                connection.Execute("SP_EXCLUIRCLIENTE",
                    new
                    {
                        @IDCLIENTE = obj.IdCliente
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Cliente> GetAll()
        {
            var query = @"
                          SELECT * FROM CLIENTE
                          ORDER BY DATACADASTRO";
            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection 
                    .Query<Cliente>(query)
                    .ToList();

            }
        }

        public Cliente GetById(Guid id)
        {
            var query = @"
                          SELECT * FROM CLIENTE
                          WHERE IDCLIENTE = @id";
            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection
                    .Query<Cliente>(query, new { id })
                    .FirstOrDefault();

            }
        }

        public Cliente GetByEmail(string email)
        {
            var query = @"
                            SELECT * FROM CLIENTE
                            WHERE EMAIL = @email";

            using (var connection = new SqlConnection (_connectionstring))
            {
                return connection
               .Query<Cliente>(query, new { email })
               .FirstOrDefault();
            }
        }
    }
}
