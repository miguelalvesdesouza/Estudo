﻿using CShp_Dapper1.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace CShp_Dapper1
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            string _con = Configuration["ConnectionStrings:DefaultConnection"];

            Console.WriteLine("\tc - Consultar");
            Console.WriteLine("\ti - Incluir");
            Console.WriteLine("\ta - Atualizar");
            Console.WriteLine("\td - Deletar");
            Console.Write("Sua opção (c,i,d,a) ? ");
            switch (Console.ReadLine())
            {
                case "c":
                    Consultar(_con);
                    break;
                case "i":
                    Incluir(_con);
                    break;
                case "a":
                    Atualizar(_con);
                    break;
                case "d":
                    Deletar(_con);
                    break;
            }
            Console.ReadKey();
        }

        static async void Deletar(string conexao)
        {
            int id = 2;
            using (var db = new SqlConnection(conexao))
            {
                try
                {
                    await db.OpenAsync();
                    var query = @"Delete from Clientes Where ClienteId=" + id;
                    await db.ExecuteAsync(query,new { ClienteId = id });
                    Console.WriteLine($"Cliente excluido com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        static async void Atualizar(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                Cliente model = new Cliente();
                model.Nome = "teste alterado";
                model.Email = "email@teste.com";
                model.Idade = 88;
                model.Pais = "Terra";
                model.ClienteId = 2;

                try
                {
                    await db.OpenAsync();
                    var query = @"Update Clientes Set Nome=@Nome, Idade=@Idade,Email=@Email,Pais=@Pais Where ClienteId=@ClienteId";
                    await db.ExecuteAsync(query, model);
                    Console.WriteLine($"Cliente {model.Nome} incluido com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static async void Incluir(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                Cliente model = new Cliente();
                model.Nome = "teste";
                model.Email = "email@teste.com";
                model.Idade = 99;
                model.Pais = "Terra";
                try
                {
                    await db.OpenAsync();
                    var query = @"Insert Into Clientes(Nome,Idade,Email,Pais) Values(@nome,@idade,@email,@pais)";
                    await db.ExecuteAsync(query, model);
                    Console.WriteLine($"Cliente {model.Nome} incluido com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static async void Consultar(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                await db.OpenAsync();
                var query = "Select Top 10 ClienteId,Nome,Idade,Pais From Clientes";
                var clientes = await db.QueryAsync<Cliente>(query);
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(new string('*', 20));
                    Console.WriteLine("\nID: " + cliente.ClienteId.ToString());
                    Console.WriteLine("Nome : " + cliente.Nome);
                    Console.WriteLine("Idade: " + cliente.Idade.ToString());
                    Console.WriteLine("Pais : " + cliente.Pais + "\n");
                    Console.WriteLine(new string('*', 20));
                }
                Console.ReadLine();
            }
        }
    }
}
