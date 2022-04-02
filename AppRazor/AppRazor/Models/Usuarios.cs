using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppRazor.Models
{
    public class Usuarios
    {
        private readonly static string _conn = @"Data Source=DESKTOP-45J2BHI\SQLEXPRESS01;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }


        public bool Login()
        {
            var result = false;
            var sql = "SELECT Id, Nome FROM Usuarios WHERE Email = '" + Email + "' AND Senha = '" + Senha + "'";

            //try
            //{
            using (var cn = new SqlConnection(_conn))
            {
                cn.Open();
                using (var cmd = new SqlCommand(sql, cn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                Id = Convert.ToInt32(dr["Id"]);
                                Nome = Convert.ToString(dr["Nome"]);
                                result = true;

                            }
                        }
                    }
                }
            }
            //}
            //catch
            //{
            //    throw;
            //}
            return result;
        }
    }
}
