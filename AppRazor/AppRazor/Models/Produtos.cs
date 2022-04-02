using AppRazor.DataBase;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SQLite;
//using Microsoft.Data.Sqlite;
using System.Linq;

namespace AppRazor.Models
{
    public class Produtos : Connection
    {
        //private readonly static string _conn = "Data Source=DESKTOP-45J2BHI\\SQLEXPRESS01;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //IConfiguration _configuration;
        //private static SQLiteConnection _conn;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Produtos() { }
        public Produtos(int id, string nome, string descricao)
        {
            //_configuration = configuration;
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
            
        //public SQLiteConnection GetConnection()
        //{

        //    //_conn = "Data Source=DESKTOP-45J2BHI\\SQLEXPRESS01;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    _conn = new SQLiteConnection("Data Source=C:\\bd\\Produtos.sqlite; Version=3;");
        //    //var _conn = new SQLiteConnectionStringBuilder();
        //    //conn.DataSource = "./Produtos.db";
        //    //using(var conn = new SQLiteConnection(_conn.ConnectionString))
        //    //{

        //        _conn.Open();
        //    //}
        //    return _conn;
        //}

        //public static void CriarBancoSQLite()
        //{
        //    try
        //    {
        //        SQLiteConnection.CreateFile(@"c:\bd\Produtos.sqlite");
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public void CriarTabelaSQlite()
        //{
        //    try
        //    {
        //        using (var cmd = GetConnection().CreateCommand())
        //        {
        //            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Produtos(Id int, Nome Varchar(50), Descricao VarChar(80))";
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public  List<Produtos> GetProdutos()
        {
            //var _conn = GetConnection();
            var listaProdutos = new List<Produtos>();
            var sql = "SELECT * FROM Produtos";
            //SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                //using (var cn = new SqlConnection(_conn))
                using(var cn = Bd)
                {
                    cn.Open();
                    listaProdutos = cn.Query<Produtos>(sql).ToList();
                    //da = new SQLiteDataAdapter(sql, _conn);
                    //da.Fill(dt);

                    
                    //using (var comand = new SqlCommand(sql, cn))

                    //{
                    //    using (var leitor = comand.ExecuteReader())
                    //    {
                    //        while (leitor.Read())
                    //        {
                    //            listaProdutos.Add(new Produtos(
                    //                Convert.ToInt32(leitor["Id"]),
                    //                leitor["Nome"].ToString(),
                    //                leitor["Descricao"].ToString()));
                    //        }

                    //    }
                    //}
                }
            }
            catch
            {
                throw;
            }

            return listaProdutos;
        }

        public void Salvar(Produtos produtos)
        {
            //var _conn = GetConnection();
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO Produtos(Nome, Descricao) VALUES (@Nome, @Descricao)";
            }
            else
            {
                sql = "UPDATE Produtos SET Nome=@Nome, Descricao=@Descricao WHERE id=" + Id;
            }

            try
            {
                using (var cn = Bd)
                {
                    cn.Open();
                    //var sql = "INSERT INTO Produtos(Nome, Descricao) VALUES (@Nome, @Descricao)";
                    cn.Execute(sql, produtos);
                    //using (var cmd = new SqlCommand(sql, cn))
                    //{
                    //    cmd.Parameters.AddWithValue("@nome", Nome);
                    //    cmd.Parameters.AddWithValue("@descricao", Descricao);

                    //    cmd.ExecuteNonQuery();
                    //}
                }

            }
            catch
            {
                throw;
            }
        }

        public void GetProdutos(int id)
        {
            //var _conn = GetConnection();
            var sql = "SELECT * FROM Produtos WHERE id=" + id;
            try
            {
                //using (var cn = new SqlConnection(_conn))
                using (var cn = Bd)
                {
                    cn.Open();
                    cn.Execute(sql);
                    //using (var comand = new SqlCommand(sql, cn))
                    //{
                    //    using (var leitor = comand.ExecuteReader())
                    //    {
                    //        if (leitor.HasRows)
                    //        {
                    //            if (leitor.Read())
                    //            {
                    //                Id = id;
                    //                Nome = leitor["nome"].ToString();
                    //                Descricao = leitor["descricao"].ToString();
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            catch
            {
                throw;
            }
        }

        public void Deletar(int id)
        {
            //var _conn = GetConnection();
            var sql = "DELETE FROM Produtos WHERE id=" + id;
            try
            {
                //using (var cn = new SqlConnection(_conn))
                using (var cn = Bd)
                {
                    cn.Open();
                    cn.Execute(sql);
                    //using (var comand = new SqlCommand(sql, cn))
                    //{
                    //    using (var leitor = comand.ExecuteReader())
                    //    {
                    //        if (leitor.HasRows)
                    //        {
                    //            if (leitor.Read())
                    //            {
                    //                Id = id;
                    //                Nome = leitor["nome"].ToString();
                    //                Descricao = leitor["descricao"].ToString();
                    //            }
                    //        }

                    //    }
                    //}
                }
            }
            catch
            {
                throw;
            }
        }

        public  Produtos Procurar(string nome, string filtroNome, string filtroDescricao)
        {
            //var _conn = GetConnection();
            var listaProdutos = new Produtos();
            var sql = "";
            if(filtroNome == "nome")
            {
               sql = $"SELECT * FROM Produtos where Nome like '%{nome}%'";
            }
            else if(filtroDescricao == "descricao")
            {
                sql = $"SELECT * FROM Produtos where Descricao like '%{nome}%'";
            }
            try
            {
                //using (var cn = new SqlConnection(_conn))
                using (var cn = Bd)
                {
                    cn.Open();
                    //using (var comand = new SqlCommand(sql, cn))
                    //{
                    listaProdutos = cn.Query<Produtos>(sql).FirstOrDefault();
                        //using (var leitor = comand.ExecuteReader())
                        //{
                        //    while (leitor.Read())
                        //    {
                        //        listaProdutos.Add(new Produtos(
                        //            Convert.ToInt32(leitor["Id"]),
                        //            leitor["Nome"].ToString(),
                        //            leitor["Descricao"].ToString()));
                        //    }

                        //}
                    //}
                }
            }
            catch
            {
                
                throw;
            }

            return listaProdutos;
        }
    
    }
}
