using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestesRastreabilidade.Models;

namespace TestesRastreabilidade.Repository
{
    public class LoginRepository : ILoginRepository
    {
        IConfiguration _configuration;

        public LoginRepository()
        {

        }   
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ConexaoLogin");
            return connection.ToString();
        }

        public bool Get(string usuario, string senha)
        {
            var connectionString = this.GetConnection();
            LoginModel loginModel = new LoginModel();
            using (var cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    var query = $"SELECT Usuario, Senha FROM Logins where Usuario = '{usuario}' and Senha = '{senha}' ";
                    loginModel = cn.Query<LoginModel>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                }
                return true;
            }
        }
    }
}
